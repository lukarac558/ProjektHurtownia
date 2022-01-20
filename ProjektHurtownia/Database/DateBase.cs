using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Data.Common;
using System.Security.Cryptography;
using ProjektHurtownia.Classes;

namespace ProjektHurtownia
{
    class DateBase
    {
        public static int idUser = -1;
        public static string permission = "";
        private static DateBase instance = new DateBase();
        private DateBase() { }

        private static DateBase Instance
        {
            get { return instance; }
        }

        public static void Login(string login, string password)
        {
            string query = "SELECT user_id,permission FROM [user] WHERE login=@Login AND password=@Password";

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Login", login);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    SqlDataReader rd = command.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        idUser = rd.GetInt32(0);
                        permission = rd.GetString(1);
                    }
                    else
                        MessageBox.Show("Niepoprawne dane");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public static void LogOut()
        {
            DateBase.idUser = -1;
            permission = "";
        }

        public static void Register(User user)
        {
            string query = $"INSERT INTO [user] (login,password,permission,name,surname,city,street,residence_number,postcode)" +
                    $" VALUES (@Login, @Password,@Permission,@Name,@Surname,@City,@Street,@ResidenceNumber,@Postcode)";

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                try
                {
                    connection.Execute(query, new
                    {
                        Login = user.Login,
                        Password = user.Password,
                        Permission = user.Permission,
                        Name = user.Name,
                        Surname = user.Surname,
                        City = user.City,
                        Street = user.City,
                        ResidenceNumber = user.ResidenceNumber,
                        Postcode = user.Postcode
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public static void AddNewProduct(Product product)
        {
            string query = $"INSERT INTO product(product_name,type_id,discipline_id,unit_quantity,unit_price,provider_id) " +
                $"VALUES (@Name,@Type,@Discipline,@Quantity,@Price,@Provider)";

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                try
                {
                    connection.Execute(query, new
                    {
                        Name = product.ProductName,
                        Type = product.TypeId,
                        Discipline = product.DisciplineId,
                        Quantity = product.UnitQuantity,
                        Price = product.UnitPrice,
                        Provider = product.ProviderId
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public static void AddNewProvider(string provider, int guaranteePeriod)
        {
            string query = $"INSERT INTO provider(provider_name, guarantee_period) VALUES (@Name, @Guarantee)";

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                try
                {
                    connection.Execute(query, new { Name = provider, Guarantee = guaranteePeriod });
                }
                catch (Exception ex)
                {
                    if (ex is SqlException)
                        MessageBox.Show("Podany dostawca istnieje już w bazie.", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public static void AddNewType(string type)
        {
            string query = $"INSERT INTO product_type(product_type) VALUES (@Type)";

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                try
                {
                    connection.Execute(query, new { Type = type });
                }
                catch (Exception ex)
                {
                    if(ex is SqlException)
                        MessageBox.Show("Podany typ istniał już w bazie.", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public static void AddNewDiscipline(string discipline)
        {
            string query = $"INSERT INTO product_discipline(discipline_kind) VALUES (@Discipline)";

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                try
                {
                    connection.Execute(query, new { Discipline = discipline });
                }
                catch (Exception ex)
                {
                    if (ex is SqlException)
                        MessageBox.Show("Podana dyscyplina istniała już w bazie.", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public static void AddNewOrder(Order order)
        {
            string query = $"INSERT INTO [order] (product_id,user_id,count,order_date,guarantee_end,total_cost) VALUES (@ProductId,@UserId,@Count,@OrderDate,@GuaranteeEnd,@Cost)";

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                try
                {
                    connection.Execute(query, new
                    {
                        ProductId = order.IdProduct,
                        UserId = order.IdUser,
                        Count = order.Count,
                        OrderDate = order.OrderDate,
                        GuaranteeEnd = order.GuaranteeEnd,
                        Cost = order.TotalCost             
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public static void UpdateProductCount(int productId, int newUnitQuantity)
        {
            string query = $"UPDATE product SET unit_quantity=@NewUnitQuantity WHERE product_id=@ProductId";

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                try
                {
                    connection.Execute(query, new
                    {
                        newUnitQuantity,
                        ProductId = productId
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public static int GetTypeId(string type)
        {
            string query = "SELECT type_id FROM product_type WHERE product_type=@Type";

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Type", type);

                try
                {
                    connection.Open();
                    SqlDataReader rd = command.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        var typeId = rd.GetInt32(0);
                        return typeId;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return -1; // type didn't find in database
        }

        public static string GetTypeById(int typeId)
        {
            string query = $"SELECT product_type FROM product_type WHERE type_id = @TypeId";

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TypeId", typeId);
                string type = null;

                try
                {
                    connection.Open();
                    SqlDataReader rd = command.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        type = rd.GetString(0);
                    }
                    else
                        MessageBox.Show("Niepoprawne dane");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return type;
            }
        }

        public static int GetDisciplineId(string discipline)
        {
            string query = "SELECT discipline_id FROM product_discipline WHERE discipline_kind=@Discipline";

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Discipline", discipline);

                try
                {
                    connection.Open();
                    SqlDataReader rd = command.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        var typeId = rd.GetInt32(0);
                        return typeId;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return -1; // type didn't find in database
        }

        public static string GetDisciplineById(int disciplineId)
        {
            string query = $"SELECT discipline_kind FROM product_discipline WHERE discipline_id = @DisciplineId";

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DisciplineId", disciplineId);
                string discipline = null;

                try
                {
                    connection.Open();
                    SqlDataReader rd = command.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        discipline = rd.GetString(0);
                    }
                    else
                        MessageBox.Show("Niepoprawne dane");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return discipline;
            }
        }

        public static int GetProviderId(string provider)
        {
            string query = "SELECT provider_id FROM provider WHERE provider_name=@Provider";

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Provider", provider);

                try
                {
                    connection.Open();
                    SqlDataReader rd = command.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        var typeId = rd.GetInt32(0);
                        return typeId;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return -1; // type didn't find in database
        }

        public static Provider GetProviderById(int providerId)
        {
            string query = $"SELECT provider_name,guarantee_period FROM provider WHERE provider_id = @ProviderId";

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProviderId", providerId);
                Provider prov = null;

                try
                {
                    connection.Open();
                    SqlDataReader provider = command.ExecuteReader();
                    if (provider.HasRows)
                    {
                        provider.Read();
                        prov = new Provider(providerId, provider[0].ToString(), (short)provider[1]);
                    }
                    else
                        MessageBox.Show("Nie stnieje dostawca o takim id.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return prov;
            }
        }

        public static Product GetProduct(int productId)
        {
            string query = $"SELECT product_id, product_name, type_id, discipline_id, unit_quantity,unit_price,provider_id FROM product WHERE product_id = @ProductId";

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductId", productId);
                Product pro = null;

                try
                {
                    connection.Open();
                    SqlDataReader product = command.ExecuteReader();
                    if (product.HasRows)
                    {
                        product.Read();
                        pro = new Product(Int32.Parse(product[0].ToString()), product[1].ToString(), Int32.Parse(product[2].ToString()), Int32.Parse(product[3].ToString()),
                                    Int32.Parse(product[4].ToString()), Double.Parse(product[5].ToString()), Int32.Parse(product[6].ToString()));
                    }
                    else
                        MessageBox.Show("Nie istnieje produkt o takim id");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return pro;
            }
        }

        public static List<Product> SearchNotAvailableProducts()
        {
            List<Product> list = new List<Product>();
            string query = $"SELECT product_id, product_name, type_id, discipline_id, unit_price,provider_id FROM product WHERE unit_quantity=0";

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    using (var rd = command.ExecuteReader())
                    {
                        foreach (DbDataRecord product in rd)
                        {
                            Product p = new Product(Int32.Parse(product[0].ToString()), product[1].ToString(), Int32.Parse(product[2].ToString()), Int32.Parse(product[3].ToString()),
                                0, Double.Parse(product[4].ToString()), Int32.Parse(product[5].ToString()));
                            list.Add(p);
                        }
                        return list;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return null;
            }
        }

        public static List<string> GetAllTypes()
        {
            string query = $"SELECT product_type FROM product_type";
            List<string> list = new List<string>();

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    using (var rd = command.ExecuteReader())
                    {
                        foreach (DbDataRecord type in rd)
                        {
                            string productType = type.GetString(0);
                            list.Add(productType);
                        }
                        return list;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return null;
            }
        }

        public static List<string> GetAllDisciplines()
        {
            string query = $"SELECT discipline_kind FROM product_discipline";
            List<string> list = new List<string>();

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    using (var rd = command.ExecuteReader())
                    {
                        foreach (DbDataRecord type in rd)
                        {
                            string productDiscipline = type.GetString(0);
                            list.Add(productDiscipline);
                        }
                        return list;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return null;
            }
        }

        public static List<string> GetAllProviders()
        {
            string query = $"SELECT provider_name FROM provider";
            List<string> list = new List<string>();

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    using (var rd = command.ExecuteReader())
                    {
                        foreach (DbDataRecord type in rd)
                        {
                            string productProvider = type.GetString(0);
                            list.Add(productProvider);
                        }
                        return list;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return null;
            }
        }

        private static string PrepareQuery(string query, List<string> list)
        {
            if (list.Count > 0)
            {
                foreach (var item in list)
                    query += "'" + item + "' OR ";
                query = query.Remove(query.Length - 3, 3);
                query += ')';
            }
            else
                query = "";

            return query;
        }

        public static List<Product> FilterProducts(List<string> selectedTypes, List<string> selectedDisciplines, List<string> selectedProviders, double minimumPrice, double maximumPrice)
        {
            var list = new List<Product>();
            
            string basicQuery = $"SELECT product_id,product_name,p.type_id,p.discipline_id,unit_quantity,unit_price,p.provider_id FROM product p INNER JOIN provider pr ON " +
                $"p.provider_id=pr.provider_id INNER JOIN product_type pt ON p.type_id=pt.type_id INNER JOIN product_discipline pd ON p.discipline_id=pd.discipline_id WHERE (unit_quantity>0) AND ";

            string typeQuery = $"(pt.product_type LIKE ";
            typeQuery = PrepareQuery(typeQuery, selectedTypes);
            string disciplineQuery = $"(pd.discipline_kind LIKE ";
            disciplineQuery = PrepareQuery(disciplineQuery, selectedDisciplines);
            string providerQuery = $"(pr.provider_name LIKE ";
            providerQuery = PrepareQuery(providerQuery, selectedProviders);

            if (typeQuery != "")
                basicQuery += typeQuery;

            if (disciplineQuery != "" && typeQuery != "")
                basicQuery += " AND " + disciplineQuery;
            else if(disciplineQuery != "" && typeQuery == "")
                basicQuery += disciplineQuery;

            if((disciplineQuery !="" || typeQuery !="") && providerQuery !="")
                basicQuery += " AND " + providerQuery;
            else if(disciplineQuery == "" && typeQuery=="" && providerQuery != "")
                basicQuery += providerQuery;

            if (typeQuery == "" && disciplineQuery == "" && providerQuery == "")
                basicQuery += "(unit_price>" + minimumPrice + " AND unit_price<" + maximumPrice + ')';
            else
                basicQuery += "AND (unit_price>" + minimumPrice + " AND unit_price<" + maximumPrice + ')';


            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                SqlCommand command = new SqlCommand(basicQuery, connection);
                try
                {
                    connection.Open();
                    using (var rd = command.ExecuteReader())
                    {
                        foreach (DbDataRecord product in rd)
                        {
                            Product p = new Product(Int32.Parse(product[0].ToString()), product[1].ToString(), Int32.Parse(product[2].ToString()), Int32.Parse(product[3].ToString()),
                                Int32.Parse(product[4].ToString()), Double.Parse(product[5].ToString()), Int32.Parse(product[6].ToString()));
                            list.Add(p);
                        }
                        return list;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return null;
            }
        }
       
        public static List<Product> FilterByProductName(string productName)
        {
            var list = new List<Product>();

            string basicQuery = $"SELECT product_id,product_name,p.type_id,p.discipline_id,unit_quantity,unit_price,p.provider_id FROM product p INNER JOIN provider pr ON " +
                $"p.provider_id=pr.provider_id INNER JOIN product_type pt ON p.type_id=pt.type_id INNER JOIN product_discipline pd ON p.discipline_id=pd.discipline_id" +
                $" WHERE (unit_quantity>0) AND (LOWER(product_name) LIKE LOWER(@ProductName))";
         
            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                SqlCommand command = new SqlCommand(basicQuery, connection);
                command.Parameters.AddWithValue("@ProductName", '%' + productName + '%');

                try
                {
                    connection.Open();
                    using (var rd = command.ExecuteReader())
                    {
                        foreach (DbDataRecord product in rd)
                        {
                            Product p = new Product(Int32.Parse(product[0].ToString()), product[1].ToString(), Int32.Parse(product[2].ToString()), Int32.Parse(product[3].ToString()),
                                Int32.Parse(product[4].ToString()), Double.Parse(product[5].ToString()), Int32.Parse(product[6].ToString()));
                            list.Add(p);
                        }
                        return list;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return null;
            }
        }           

        public static List<Product> OrderProductsByPrice(List<Product> list, string orderBy)
        {
            string products = "(";
            string basicQuery = $"SELECT product_id,product_name,p.type_id,p.discipline_id,unit_quantity,unit_price,p.provider_id FROM product p INNER JOIN provider pr ON " +
                $"p.provider_id=pr.provider_id INNER JOIN product_type pt ON p.type_id=pt.type_id INNER JOIN product_discipline pd ON p.discipline_id=pd.discipline_id WHERE product_id IN ";

            if (list.Count > 0)
            {          
                foreach (var item in list)
                    products += item.ProductId + ", ";
                products = products.Remove(products.Length - 2, 2);
                products += ')';
                list.Clear();
            }

            basicQuery += products + "ORDER BY unit_price " + orderBy;

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                SqlCommand command = new SqlCommand(basicQuery, connection);
                try
                {
                    connection.Open();
                    using (var rd = command.ExecuteReader())
                    {
                        foreach (DbDataRecord product in rd)
                        {
                            Product p = new Product(Int32.Parse(product[0].ToString()), product[1].ToString(), Int32.Parse(product[2].ToString()), Int32.Parse(product[3].ToString()),
                                Int32.Parse(product[4].ToString()), Double.Parse(product[5].ToString()), Int32.Parse(product[6].ToString()));
                            list.Add(p);
                        }
                        return list;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return null;
            }
        }

        public static List<Order> GetUserOrders() // zwraca zamówienia danego użytkownika
        {
            List<Order> list = new List<Order>();
            string query = $"SELECT order_id,product_id,count,order_date,guarantee_end,total_cost FROM [order] WHERE user_id=@UserId";

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", DateBase.idUser);
                try
                {
                    connection.Open();
                    using (var rd = command.ExecuteReader())
                    {
                        foreach (DbDataRecord order in rd)
                        {
                            Order o = new Order(Int32.Parse(order[0].ToString()), Int32.Parse(order[1].ToString()), DateBase.idUser, Int32.Parse(order[2].ToString()),
                               DateTime.Parse(order[3].ToString()), DateTime.Parse(order[4].ToString()), Double.Parse(order[5].ToString()));
                            list.Add(o);
                        }
                        return list;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return null;
            }
        }

        private static bool IsReturnPossible(int orderId) // wyświetla odpowiednie wartości w kolumnie datagridview w zależności od tego co zwraca funkcja
        {
            string query = $"SELECT guarantee_end FROM [order] WHERE order_id=@OrderId";

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderId", orderId);
                try
                {
                    connection.Open();
                    SqlDataReader rd = command.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        DateTime guaranteeEnd = rd.GetDateTime(0);
                        DateTime timeNow = DateTime.Now;

                        DateTime date1 = new DateTime(guaranteeEnd.Year, guaranteeEnd.Month, guaranteeEnd.Day, guaranteeEnd.Hour, guaranteeEnd.Minute, 0);
                        DateTime date2 = new DateTime(timeNow.Year, timeNow.Month, timeNow.Day, timeNow.Hour, timeNow.Minute, timeNow.Second);
                        int result = DateTime.Compare(date1, date2);

                        if (result == 1)
                            return true; // obecna data jest mniejsza od terminu zwrotu
                        else
                            return false; // minął czas zwrotu
                    }
                    else
                        MessageBox.Show("Niepoprawne dane");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;
            }
        }

        public static void CancelOrder(int orderId, int productId, int newUnitQuantity)
        {
            if (IsReturnPossible(orderId))
            {
                string query = $"DELETE FROM [order] WHERE order_id=@OrderId";

                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
                {
                    try
                    {
                        connection.Execute(query, new { OrderId = orderId });
                        UpdateProductCount(productId, newUnitQuantity);
                        MessageBox.Show("Pomyślnie dokonano zwrotu.", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                     MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
                MessageBox.Show("Zwrot niemożliwy, gdyż upłynął termin.", "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
    }
}

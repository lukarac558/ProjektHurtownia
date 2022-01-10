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

namespace ProjektHurtownia
{
    class DateBase
    {
        public static int idUser = -1;
        private static DateBase instance = new DateBase();
        private DateBase() { }

        private static DateBase Instance
        {
            get { return instance; }
        }

        public static void Login(string login, string password)
        {
            string query = "SELECT user_id FROM [user] WHERE login=@Login AND password=@Password";

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

        public static void AddNewProvider(string provider)
        {
            string query = $"INSERT INTO provider(provider_name) VALUES (@NAME)";

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                try
                {
                    connection.Execute(query, new { Name = provider });
                }
                catch (Exception ex)
                {
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
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public static void AddNewOrder(Order order)
        {
            string query = $"INSERT INTO order (product_id,user_id,count,order_date,total_cost,) VALUES (@ProductId,@UserId,@Count,@Date,@Cost)";

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                try
                {
                    connection.Execute(query, new
                    {
                        ProductId = order.IdProduct,
                        UserId = order.IdUser,
                        Count = order.Count,
                        Date = order.OrderDate,
                        Cost = order.TotalCost
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

        public static string GetProviderById(int providerId)
        {
            string query = $"SELECT provider_name FROM provider WHERE provider_id = @ProviderId";

            using (SqlConnection connection = new SqlConnection(Helper.ConnectionValue("HurtowniaDB")))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProviderId", providerId);
                string provider = null;

                try
                {
                    connection.Open();
                    SqlDataReader rd = command.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        provider = rd.GetString(0);
                    }
                    else
                        MessageBox.Show("Niepoprawne dane");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return provider;
            }
        }

        public static Product GetProduct(int productId)
        {
            string query = $"SELECT product_id, product_name, type_id, discipline_id, unit_quantity,unit_price,provider_id FROM product WHERE productId = @ProductId";

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
                        MessageBox.Show("Nieistnieje produkt o takim id");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return pro;
            }
        }

        public static List<Product> SearchAvailableProducts() // zwraca wszystkie dostępne produkty
        {
            List<Product> list = new List<Product>();
            string query = $"SELECT product_id, product_name, type_id, discipline_id, unit_quantity,unit_price,provider_id FROM product WHERE unit_quantity>0";

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

        // public static List<Product> FilterProducts(List<string> selectedTypes, List<string> selectedDisciplines, List<string> selectedProviders, int minimumPrice, int maximumPrice)
        // {

        // }

        /*
        public static List<Product> FilterByProductName(string productName)
        {

        }
               
        public static List<Product> SortProductsByPriceAscending()
        {
        }

        public static List<Product> SortProductsByPriceDescending()
        {

        }
        */
    }
}

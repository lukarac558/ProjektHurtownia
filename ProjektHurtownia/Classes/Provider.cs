using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektHurtownia.Classes
{
    public class Provider
    {
        int providerId;
        string providerName;
        short guaranteePeriod;

        public Provider(int providerId, string providerName, short guaranteePeriod)
        {
            this.providerId = providerId;
            this.providerName = providerName;
            this.guaranteePeriod = guaranteePeriod;
        }

        public int ProviderId { get => providerId; set => providerId = value; }
        public string ProviderName { get => providerName; set => providerName = value; }
        public short GuaranteePeriod { get => guaranteePeriod; set => guaranteePeriod = value; }
    }
}

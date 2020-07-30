using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesforcePushUpgrade.Model
{
    public class Salesforce
    {
        public string Username { get; set; }
        public string Password { get; set; }        
        public string Token { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AuthToken { get; set; }
        public string InstanceUrl { get; set; }
    }
}

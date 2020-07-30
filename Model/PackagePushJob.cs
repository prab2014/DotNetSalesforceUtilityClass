using System;

namespace SalesforcePushUpgrade.Model
{
    public class PackagePushJob
    {       
        public string PackagePushRequestId { get; set; }       
        public string SubscriberOrganizationKey { get; set; }        
        public string Status { get; set; }
        public string Id { get; set; }
        public DateTime SystemModstamp { get; set; }
    }
}

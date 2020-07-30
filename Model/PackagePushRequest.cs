using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesforcePushUpgrade.Model
{
    public class PackagePushRequest
    {       
        public string PackageVersionId { get; set; }        
        public DateTime ScheduledStartTime { get; set; }        
        public string Status { get; set; }
        public string Id { get; set; }
        public DateTime SystemModstamp { get; set; }
    }
}

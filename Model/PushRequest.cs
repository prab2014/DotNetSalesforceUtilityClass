using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesforcePushUpgrade.Model
{
    public class PushRequest
    {
        public string DesiredVersion { get; set; }
        public string PackageVersionId { get; set; }
        public DateTime ScheduledStartTime { get; set; }
        public string AccessToken { get; set; }
        public string InstanceUrl { get; set; }
        public string PushReqId { get; set; }
        /// <summary>
        /// The status of the push. Valid values are:  Created(default),Scheduled(pending),In Progress,Succeeded,Failed,Aborthed(Canceled)
        /// </summary>
        public string Status { get; set; }

        public string ApiVersion { get; set; }
    }
}

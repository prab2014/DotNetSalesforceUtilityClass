using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesforcePushUpgrade.Model
{
    public class PackagePushRequest
    {
        /// <summary>
        /// The non-beta, non-deprecated package version that the package is being upgraded to.
        /// </summary>
        public string PackageVersionId { get; set; }
        /// <summary>
        /// The date and time (UTC) at which the push request is processed
        /// </summary>
        public DateTime ScheduledStartTime { get; set; }
        /// <summary>
        /// The status of the push. Valid values are:  Created(default),Scheduled(pending),In Progress,Succeeded,Failed,Aborthed(Canceled)
        /// </summary>
        public string Status { get; set; }

        public string Id { get; set; }
        public DateTime SystemModstamp { get; set; }
    }
}

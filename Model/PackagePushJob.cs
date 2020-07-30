using System;

namespace SalesforcePushUpgrade.Model
{
    public class PackagePushJob
    {
        /// <summary>
        /// The ID of the parent push request record which must have been created by packagepushrequest.
        /// </summary>
        public string PackagePushRequestId { get; set; }
        /// <summary>
        /// The organization key of the org where the package is upgraded. This references orgKey in PackageSubscriber
        /// </summary>
        public string SubscriberOrganizationKey { get; set; }
        /// <summary>
        /// The default value of Created is used. Scheduled(Pending), Created(default),Failed,In Progress,Aborted(canceled),Succeeded
        /// </summary>
        public string Status { get; set; }

        public string Id { get; set; }
        public DateTime SystemModstamp { get; set; }
    }
}

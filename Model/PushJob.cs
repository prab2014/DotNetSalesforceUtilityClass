namespace SalesforcePushUpgrade.Model
{
    public class PushJob
    {
        public string PushRequestJobId { get; set; }
        public string OrgKey { get; set; }
        public string AccessToken { get; set; }
        public string InstanceUrl { get; set; }
        public string Status { get; set; }
        public string PushJobId { get; set; }
        public string ApiVersion { get; set; }
    }
}

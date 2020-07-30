using Newtonsoft.Json;
using SalesforcePushUpgrade.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace SalesforcePushUpgrade
{
    public class SalesforceUtility
    {
        public static string SFDCLoginUrl = "https://login.salesforce.com/services/oauth2/token";
        public static string SFDCQueryUrl = "/query/?q=";       
        public static string SFDCPushRequestUrl = "/sobjects/packagepushrequest/";
        public static string SFDCPushJobUrl = "/sobjects/packagepushjob/";
        public static string OauthAuthorizeUrl = "https://login.salesforce.com/services/oauth2/authorize";
        public static string SFDCServiceUrl = "/services/data";

        public static Salesforce Login(Salesforce sfdc) {
            Salesforce sfdcout = new Salesforce();
            String jsonResponse;
            try {
                using(var client = new HttpClient()) {
                    var request = new FormUrlEncodedContent(new Dictionary<string, string>
                        {
                {"grant_type", "password"},
                {"client_id", sfdc.ClientId},
                {"client_secret", sfdc.ClientSecret},
                {"username", sfdc.Username},
                {"password", sfdc.Password + sfdc.Token}
            }
                    );
                    request.Headers.Add("X-PrettyPrint", "1");
                    var response = client.PostAsync(SFDCLoginUrl, request).Result;
                    jsonResponse = response.Content.ReadAsStringAsync().Result;
                }
                var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse);
                sfdcout = sfdc;
                sfdcout.AuthToken = values["access_token"];
                sfdcout.InstanceUrl = values["instance_url"];
                return sfdcout;

            } catch(Exception) {

                throw;
            }

        }

        public static string InvokeSOQLQuery(string soqlQuery, string token, string instance, string apiVer) {
            try {
                var client = new HttpClient();
                string url = instance + apiVer + SFDCQueryUrl + soqlQuery;
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("Authorization", "Bearer " + token);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Add("X-PrettyPrint", "1");
                var response = client.SendAsync(request).Result;
                return response.Content.ReadAsStringAsync().Result;
            } catch(Exception) {

                throw;
            }
        }

        public static string PostPackagePushRequest(PushRequest pushRequest) {
            string requestID = string.Empty;
            try {
                using(var client = new HttpClient()) {
                    string url = pushRequest.InstanceUrl + pushRequest.ApiVersion + SFDCPushRequestUrl;
                    var request = new HttpRequestMessage(HttpMethod.Post, url);
                    request.Headers.Add("Authorization", "Bearer " + pushRequest.AccessToken);
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    PackagePushRequest pr = new PackagePushRequest();
                    if(pushRequest.ScheduledStartTime != null && pushRequest.ScheduledStartTime != DateTime.MinValue)
                        pr.ScheduledStartTime = pushRequest.ScheduledStartTime;
                    pr.PackageVersionId = pushRequest.PackageVersionId;
                    string jsonbody = JsonConvert.SerializeObject(pr);
                    request.Content = new StringContent(jsonbody, Encoding.UTF8, "application/json");
                    var response = client.SendAsync(request).Result;
                    requestID = response.Content.ReadAsStringAsync().Result;
                }

            } catch(Exception) {

                throw;
            }
            return requestID;

        }

        public static string PostPackagePushJob(PushJob pushJob) {
            string pushJobId = string.Empty;
            try {
                using(var client = new HttpClient()) {
                    string url = pushJob.InstanceUrl + pushJob.ApiVersion + SFDCPushJobUrl;
                    var request = new HttpRequestMessage(HttpMethod.Post, url);
                    request.Headers.Add("Authorization", "Bearer " + pushJob.AccessToken);
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    PackagePushJob pJ = new PackagePushJob();
                    pJ.SubscriberOrganizationKey = pushJob.OrgKey;
                    pJ.PackagePushRequestId = pushJob.PushRequestJobId;
                    string jsonbody = JsonConvert.SerializeObject(pJ);
                    request.Content = new StringContent(jsonbody, Encoding.UTF8, "application/json");
                    var response = client.SendAsync(request).Result;
                    pushJobId = response.Content.ReadAsStringAsync().Result;
                }

            } catch(Exception) {

                throw;
            }
            return pushJobId;

        }

        public static string PatchPackagePushRequest(PushRequest pushRequest) {
            string requestID = string.Empty;
            try {
                using(var client = new HttpClient()) {
                    string url = pushRequest.InstanceUrl + pushRequest.ApiVersion + SFDCPushRequestUrl + pushRequest.PushReqId;
                    var request = new HttpRequestMessage(HttpMethod.Patch, url);
                    request.Headers.Add("Authorization", "Bearer " + pushRequest.AccessToken);
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    PackagePushRequest pr = new PackagePushRequest();
                    pr.Status = pushRequest.Status;
                    if(pushRequest.ScheduledStartTime != null && pushRequest.ScheduledStartTime != DateTime.MinValue)
                        pr.ScheduledStartTime = pushRequest.ScheduledStartTime;
                    string jsonbody = JsonConvert.SerializeObject(pr);
                    request.Content = new StringContent(jsonbody, Encoding.UTF8, "application/json");
                    var response = client.SendAsync(request).Result;
                    requestID = response.Content.ReadAsStringAsync().Result;
                }

            } catch(Exception) {

                throw;
            }
            return requestID;

        }


    }
}

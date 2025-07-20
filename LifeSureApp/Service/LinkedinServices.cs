using LifeSureApp.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace LifeSureApp.Service
{
    public class LinkedinServices
    {

        private readonly string apiUrl = "https://linkedin-data-scraper-api1.p.rapidapi.com/profile/detail?username={0}";
        private readonly string apiKey = "6693216b71msha5551e4926298a0p124851jsn4012c7ff4b8f";
        private readonly string apiHost = "linkedin-data-scraper-api1.p.rapidapi.com";

        public async Task<LinkedinViewModel> GetUserInfo(string username)
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(string.Format(apiUrl, username)),
                };
                request.Headers.Add("x-rapidapi-key", apiKey);
                request.Headers.Add("x-rapidapi-host", apiHost);

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();

                    try
                    {
                        var obj = JObject.Parse(body);
                        var basicInfo = obj["data"]?["basic_info"];

                        return new LinkedinViewModel
                        {
                            Username = username,
                            FollowersCount = (int)(basicInfo?["follower_count"] ?? 0),
                            PublicIdentifier = (string)(basicInfo?["public_identifier"] ?? username)
                        };
                    }
                    catch (Exception ex)
                    {
                        return new LinkedinViewModel
                        {
                            Username = username,
                            FollowersCount = 0,
                            PublicIdentifier = username
                        };
                    }
                }
            }
        }
    }
}
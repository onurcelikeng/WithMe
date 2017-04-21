using Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WithMe.Service.Helpers
{
    public sealed class FacebookHelper
    {
        FacebookClient Client;


        public static FacebookHelper Instance(string accessToken)
        {
            return new FacebookHelper(accessToken); 
        }

        public FacebookHelper(string accessToken)
        {
            Client = new FacebookClient(accessToken);
        }

        
        public async Task<byte[]> GetProfileImage(string userid)
        {
            using (HttpClient http = new HttpClient()
            {
                BaseAddress = new Uri("https://graph.facebook.com/")
            })
            {
                try
                {
                    var data = await http.GetAsync("/" + userid + "/picture?heigth=2000&width=2000&access_token=" + Client.AccessToken);
                    if (data != null && data.IsSuccessStatusCode)
                    {
                        return await data.Content.ReadAsByteArrayAsync();
                    }
                }

                catch (Exception ex)
                {
                    System.Diagnostics.Trace.Fail(ex.Message);
                }
            }

            return null;
        }
    }
}
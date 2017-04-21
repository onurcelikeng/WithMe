using Facebook;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WithMe.Service.Entities.Tables;
using WithMe.Service.Models;
using Newtonsoft.Json;

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


        public FacebookUserModel GetUser()
        {
            var fbuser = Client.Get("me", new { fields = "id,name,first_name,middle_name,last_name,email" });
            return JsonConvert.DeserializeObject<FacebookUserModel>(JsonConvert.SerializeObject(fbuser));
        }
    }
}
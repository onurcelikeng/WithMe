using Microsoft.Owin.Security.OAuth;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WithMe.Service.Entities.Tables;
using WithMe.Service.Helpers;
using WithMe.Service.Repositories;

namespace WithMe.Service.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private Repository<User> UserRepo = new Repository<User>();


        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return base.ValidateClientAuthentication(context);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var FBuser = FacebookHelper.Instance(context.UserName).GetUser();
            var user = UserRepo.List().Where(a => a.Email == FBuser.email).SingleOrDefault();

            if(user == null)
            {
                var model = new User()
                {
                    FBid = FBuser.id,
                    FirstName = FBuser.first_name,
                    LastName = FBuser.last_name,
                    Email = FBuser.email,
                    Image = "image",
                    DeviceName = "device_name",
                    DeviceNumber = "device_number"
                };

                var result = UserRepo.Add(model);
                if(result == true)
                {
                    var newuser = UserRepo.List().Where(a => a.Email == FBuser.email).SingleOrDefault();

                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim("Id", newuser.Id.ToString()));
                    identity.AddClaim(new Claim("Email", newuser.Email));
                    context.Validated(identity);
                }
            }

            else
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("Id", user.Id.ToString()));
                identity.AddClaim(new Claim("Email", user.Email));
                context.Validated(identity);
            }

            await base.GrantResourceOwnerCredentials(context);
        }
    }
}
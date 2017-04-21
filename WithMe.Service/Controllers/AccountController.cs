using System.Web.Http;
using WithMe.Service.Entities.Tables;
using WithMe.Service.Helpers;
using WithMe.Service.Models;
using WithMe.Service.Repositories;

namespace WithMe.Service.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : BaseController
    {
        private Repository<User> UserRepo = new Repository<User>();


        [HttpGet]
        [Route("me")]
        public IHttpActionResult GetMe()
        {
            int userId = 1;
            var user = UserRepo.Find(userId);

            if(user != null)
            {
                var model = new UserModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Image = user.Image
                };

                return Ok(model);
            }

            return Error("böyle bir kullanıcı yok.");
        }
    }
}
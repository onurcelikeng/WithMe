using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WithMe.Service.Entities.Tables;
using WithMe.Service.Repositories;

namespace WithMe.Service.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private Repository<User> UserRepo = new Repository<User>();

        [HttpGet]
        [Route("me")]
        public IHttpActionResult GetMe()
        {
            return Ok();
        }
    }
}
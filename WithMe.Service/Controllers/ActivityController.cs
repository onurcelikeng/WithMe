using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WithMe.Service.Entities.Tables;
using WithMe.Service.Helpers;
using WithMe.Service.Models;
using WithMe.Service.Models.ReqModels;
using WithMe.Service.Repositories;

namespace WithMe.Service.Controllers
{
    [RoutePrefix("api/activities")]
    public class ActivityController : BaseController
    {
        private Repository<Activity> ActivityRepo = new Repository<Activity>();


        [HttpGet]
        [Route("request")]
        public IHttpActionResult GetRequestedActivities()
        {
            int userId = 1;

            List<Activity> activities = ActivityRepo.List().Where(a => a.ReqUserId == userId).OrderByDescending(a => a.CreateDate).ToList();

            var list = activities.Select(a => new ActivityModel()
            {
                ActivityId = a.Id,
                UserId = a.ResUserId,
                UserName = string.Concat(a.ResUser.FirstName, " ", a.ResUser.LastName),
                Description = a.Description,
                Date = a.CreateDate
            });

            return Result(list);
        }

        [HttpGet]
        [Route("response")]
        public IHttpActionResult GetResponsedActivities()
        {
            int userId = 1;

            List<Activity> activities = ActivityRepo.List().Where(a => a.ResUserId == userId).OrderByDescending(a => a.CreateDate).ToList();

            var list = activities.Select(a => new ActivityModel()
            {
                ActivityId = a.Id,
                UserId = a.ReqUserId,
                UserName = string.Concat(a.ReqUser.FirstName, " ", a.ReqUser.LastName),
                Description = a.Description,
                Date = a.CreateDate
            });

            return Result(list);
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult AddActivity(ActivityReqModel model)
        {
            var activity = new Activity()
            {
               ReqUserId = model.ReqUserId,
               ResUserId = model.ResUserId,
               CategoryId = model.CategoryId,
               Description = model.Description,
               CreateDate = model.CreateTime
            };

            var response = ActivityRepo.Add(activity);

            if (response == true)
                return Success("Yoruumuz başarıyla eklendi.");
            else
                return Error("Bir hata oluştu.");
        }
    }
}
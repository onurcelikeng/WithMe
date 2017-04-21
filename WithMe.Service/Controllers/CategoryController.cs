using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WithMe.Service.Entities.Tables;
using WithMe.Service.Helpers;
using WithMe.Service.Models;
using WithMe.Service.Repositories;

namespace WithMe.Service.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoryController : BaseController
    {
        private Repository<Category> CategoryRepo = new Repository<Category>();


        [HttpGet]
        [Route("")]
        public IHttpActionResult GetCategories()
        {
            try
            {
                List<Category> categories = CategoryRepo.List();

                var list = categories.Select(c => new CategoryModel()
                {
                    Id = c.Id,
                    Category = c.Name,
                    Image = c.Image
                }).ToList();

                return Result(list);
            }

            catch (System.Exception)
            {
                return Error("bir hata oluştu");
            }
        }
    }
}
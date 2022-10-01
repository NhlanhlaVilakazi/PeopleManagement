using Microsoft.AspNetCore.Mvc;
using PeopleManagement.Business.EnumBusiness;
using PeopleManagement.Business.PersonsBusiness;
using X.PagedList;

namespace PeopleManagement.Controllers
{
    public class PersonsController : Controller
    {
        [HttpGet]
        public ActionResult Index(int? page, string searchString)
        {
            var business = new PersonBusiness();
            var results = business.GetPersons(searchString).ToPagedList(page ?? 1, (int)PageSizeEnum.size);
            return View(results);
        }
    }
}

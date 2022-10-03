using Microsoft.AspNetCore.Mvc;

namespace PeopleManagement.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

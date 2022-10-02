using Microsoft.AspNetCore.Mvc;
using PeopleManagement.Business.EnumBusiness;
using PeopleManagement.Business.PersonsBusiness;
using PeopleManagement.Models.Person;
using X.PagedList;

namespace PeopleManagement.Controllers
{
    public class PersonsController : Controller
    {
        public IActionResult Index(int? page, string searchString)
        {
            var business = new PersonBusiness();
            var results = business.GetPersons(searchString).ToPagedList(page ?? 1, (int)PageSizeEnum.size);
            return View(results);
        }

        public IActionResult PersonDetails(int personCode)
        {
            var business = new PersonBusiness();
            var person = business.GetPersonAndAccountInfo(personCode);
            return View(person);
        }


        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Edit(PersonViewModel personModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Some error occured, please try again later.");
                return View(personModel);
            }
            var business = new PersonBusiness();
            business.EditPerson(personModel);
            return RedirectToAction("Index");
        }

        public IActionResult DeletePerson(int personCode)
        {
            var business = new PersonBusiness();
            int affectedRows = business.DeletePerson(personCode);
            if(affectedRows > 0) return View("Index");
            ModelState.AddModelError("", "");
            return View("Index");
        }

        public IActionResult AddPerson()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddPerson(PersonViewModel personModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Some error occured, please try again later.");
                return View(personModel);
            }
            var business = new PersonBusiness();
            business.AddPerson(personModel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult CheckIfPersonAlreadyExist(string idNumber)
        {
            var business = new PersonBusiness();
            var exist = business.CheckIfPersonAlreadyExist(idNumber);
            return Json(exist);
        }

    }
}

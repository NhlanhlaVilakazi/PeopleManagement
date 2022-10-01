using Microsoft.AspNetCore.Mvc;
using PeopleManagement.Business.EnumBusiness;
using PeopleManagement.Business.PersonsBusiness;
using PeopleManagement.Models.Person;
using X.PagedList;

namespace PeopleManagement.Controllers
{
    public class PersonsController : Controller
    {
        public ActionResult Index(int? page, string searchString)
        {
            var business = new PersonBusiness();
            var results = business.GetPersons(searchString).ToPagedList(page ?? 1, (int)PageSizeEnum.size);
            return View(results);
        }

        public ActionResult PersonDetails(int personCode)
        {
            var business = new PersonBusiness();
            var pesron = business.GetPersonAndAccountInfo(personCode);
            return View(pesron);
        }

        public ActionResult Edit(int personCode)
        {
            var business = new PersonBusiness();
            var pesron = business.GetPersonByCode(personCode);
            return View(pesron);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Edit(PersonViewModel personModel)
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

        public ActionResult DeletePerson(int personCode)
        {
            var business = new PersonBusiness();
            int affectedRows = business.DeletePerson(personCode);
            if(affectedRows > 0) return View("Index");
            ModelState.AddModelError("", "");
            return View("Index");
        }

        public ActionResult AddPerson()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult AddPerson(PersonViewModel personModel)
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

    }
}

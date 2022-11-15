using Microsoft.AspNetCore.Mvc;
using PeopleManagement.Business.EnumBusiness;
using PeopleManagement.Business.PersonsBusiness;
using PeopleManagement.Models.Person;
using PeopleManagement.Repository.Interface;
using X.PagedList;

namespace PeopleManagement.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IPersonRepository _personRepository;
        private readonly PersonBusiness _personBusiness;

        public PersonsController(IPersonRepository personRepo)
        {
            _personRepository = personRepo;
            _personBusiness = new PersonBusiness(_personRepository);
        }
        public IActionResult Index(int? page, string searchString)
        { 
            var results = _personBusiness.GetPersons(searchString).ToPagedList(page ?? 1, (int)PageSizeEnum.size);
            return View(results);
        }

        public IActionResult PersonDetails(int personCode)
        {
            var person = _personBusiness.GetPersonAndAccountInfo(personCode);
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
            _personBusiness.EditPerson(personModel);
            return RedirectToAction("Index");
        }

        public IActionResult DeletePerson(int personCode)
        {
            int affectedRows = _personBusiness.DeletePerson(personCode);
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
            _personBusiness.AddPerson(personModel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult CheckIfPersonAlreadyExist(string idNumber, bool isUpdate)
        {
            var exist = _personBusiness.CheckIfPersonAlreadyExist(idNumber, isUpdate);
            return Json(exist);
        }

    }
}

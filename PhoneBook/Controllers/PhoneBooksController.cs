using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook_.Controllers
{

    [Microsoft.AspNetCore.Mvc.Route("PhoneBook")]
    public class PhoneBooksController : Controller
    {
        public PhoneBooksController(Data.IUnitOfWork unitOfWork) : base()
        {
            _unitOfWork = unitOfWork;
        }

        protected Data.IUnitOfWork _unitOfWork { get; set; }




        [Microsoft.AspNetCore.Mvc.Route("PhoneBookDetail")]
        public IActionResult Index()
        {
            var Users = _unitOfWork.UserRepository.GetAll();

            var PhoneBook = _unitOfWork.PhoneBookRepository.GetAll();

            List<Models.User> userlist = Users as List<Models.User>;



            List<Models.PhoneBook> phonelist = PhoneBook as List<Models.PhoneBook>;




            var contact = (from u in userlist.AsQueryable()
                           join
                           p in phonelist.AsQueryable() on u.Id equals p.UserId
                           select new
                           {
                               
                               p.UserId,
                               u.Fname,
                               u.Lname,
                               u.NationalID,
                               p.PhoneNo,
                               p.Id
                           }).ToList();




            TempData["data"] = contact;
            TempData["data"] = JsonConvert.SerializeObject(TempData["data"]);

            return RedirectToAction("Show", "Home");

        }

        [Microsoft.AspNetCore.Mvc.Route("Edit")]
        public IActionResult Edit(int Id, int PhoneId)
        {


            var User = _unitOfWork.UserRepository.GetById(Id);

            var PhoneBook = _unitOfWork.PhoneBookRepository.GetById(PhoneId);

            List<Models.User> userlist = new List<Models.User>();
            userlist.Add(User);



            List<Models.PhoneBook> phonelist = new List<Models.PhoneBook>();

            phonelist.Add(PhoneBook);

            var contact = (from u in userlist.AsQueryable()
                          join
                          p in phonelist.AsQueryable()
                          on u.Id equals p.UserId

                          select new {
                              p.UserId,
                              u.Fname,
                              u.Lname,
                              u.NationalID,
                              p.PhoneNo,
                              p.Id

                          }).ToList();

            TempData["data"] = contact;
            TempData["data"] = JsonConvert.SerializeObject(TempData["data"]);

            return RedirectToAction("Edit", "Home");           
        }

        [HttpPost]
        public IActionResult FinalEdit(Models.ViewModels.Contact Contact)
        {
            Models.User User = new Models.User { Id = Contact.UserId, Fname = Contact.Fname, Lname = Contact.Lname, NationalID = Contact.NationalID, User_PhoneBooks = null };
            Models.PhoneBook phoneBook = new Models.PhoneBook { Id = Contact.Id, PhoneNo = Contact.PhoneNo, UserId = Contact.UserId };


            _unitOfWork.UserRepository.Update(User);
            _unitOfWork.Save();
            _unitOfWork.PhoneBookRepository.Update(phoneBook);
            _unitOfWork.Save();

            return RedirectToAction("Index","home");
        }


    }
}

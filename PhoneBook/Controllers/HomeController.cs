using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PhoneBook.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(Data.IUnitOfWork unitOfWork) : base()
        {
            _unitOfWork = unitOfWork;
        }

        protected Data.IUnitOfWork _unitOfWork { get; }

        public IActionResult Index()
        {

            return RedirectToAction("Index", "PhoneBooks");
        }


        public IActionResult Show()
        {

            var data = JsonConvert.DeserializeObject<List<Models.ViewModels.Contact>>(TempData["data"].ToString());

            ViewData["Model"] = data;


            return View();
        }


        public IActionResult Edit()
        {

            var data = JsonConvert.DeserializeObject<List<Models.ViewModels.Contact>>(TempData["data"].ToString());

          

            List<Models.ViewModels.Contact> c = data as List<Models.ViewModels.Contact>;

            ViewData["ModelEdit"] = c;

            Models.ViewModels.Contact ctemp = new Models.ViewModels.Contact();


            foreach (var item in c)
            {
                ctemp = item;
            }

            return View(ctemp);

        }
    }
}

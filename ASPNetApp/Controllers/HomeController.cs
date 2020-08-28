using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetApp.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly DataManager DataManager;

        public HomeController(DataManager dataManager)
        {
            DataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(DataManager);
        }

        public IActionResult Contacts()
        {
            return View(DataManager.TextFields.GetTextFieldByCodeWord("PageContacts"));
        }


    }
}

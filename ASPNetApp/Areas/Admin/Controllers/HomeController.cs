using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetApp.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DataManager DataManager;


        public HomeController(DataManager dataManager)
        {
            DataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(DataManager.ProjectItems.GetAllProjectItems());
        }
    }
}

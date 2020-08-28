using ASPNetApp.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetApp.Controllers
{
    public class ProjectController: Controller
    {
        private readonly DataManager DataManager;

        public ProjectController(DataManager dataManager)
        {
            DataManager = dataManager;
        }

    }
}

using ASPNetApp.Domain;
using ASPNetApp.Domain.Entities;
using ASPNetApp.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectItemsController : Controller
    {
        private readonly DataManager DataManager;
        private readonly IWebHostEnvironment HostingEnvironment;

        public ProjectItemsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            DataManager = dataManager;
            HostingEnvironment = hostingEnvironment;
        }

        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new ProjectItem() : DataManager.ProjectItems.GetProjectItemById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(ProjectItem projectModel, IFormFile urlToPreview)
        {
            if (ModelState.IsValid)
            {
                if (urlToPreview != null)
                {
                    projectModel.UrlToPreview = urlToPreview.FileName;
                    using (var stream = new FileStream(Path.Combine(HostingEnvironment.WebRootPath, "images/", projectModel.UrlToPreview), FileMode.Create))
                    {
                        urlToPreview.CopyTo(stream);
                    }
                }
                DataManager.ProjectItems.SaveProjectItem(projectModel);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(projectModel);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            DataManager.ProjectItems.DeleteProjectItem(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }

    }
}

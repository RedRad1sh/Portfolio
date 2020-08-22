using ASPNetApp.Domain;
using ASPNetApp.Domain.Entities;
using ASPNetApp.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TextFieldsController : Controller
    {
        public readonly DataManager DataManager;

        public TextFieldsController(DataManager dataManager)
        {
            DataManager = dataManager;
        }

        public IActionResult Edit(string codeWord)
        {
            var entity = DataManager.TextFields.GetTextFieldByCodeWord(codeWord);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(TextField textFieldModel)
        {
            if(ModelState.IsValid)
            {
                DataManager.TextFields.SaveTextField(textFieldModel);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(textFieldModel);
        }
    }
}

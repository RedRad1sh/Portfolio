using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetApp.Domain.Entities
{
    public class ProjectItem : EntityBase
    {
        [Required(ErrorMessage = "Заполните название проекта")]
        [Display(Name = "Название")]
        public override string Title { get; set; }

        [Display(Name = "Краткое описание")]
        public override string ShortDescription { get; set; }

        [Display(Name = "Описание")]
        public override string Description { get; set; }

        [Display(Name = "Используемые технологии")]
        public string Technologies { get; set; }

        [Display(Name = "Ключевое слово")]
        public string CodeWord { get; set; }
    }
}

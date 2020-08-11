using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetApp.Domain.Entities
{
    public class TextField: EntityBase
    {
        [Display(Name ="Ключевое слово")]
        public string CodeWord { get; set; }

        [Display(Name = "Название страницы")]
        public override string Title { get; set; }

        [Display(Name = "Содержание страницы")]
        public override string Text { get; set; }
    }
}

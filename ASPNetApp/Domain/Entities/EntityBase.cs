using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetApp.Domain.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase() => AddingDate = DateTime.UtcNow;

        [Required]
        public Guid Id { get; set; }

        [Display(Name ="Название")]
        public virtual string Title { get; set; }

        [Display(Name = "Краткое описание")]
        public virtual string ShortDescription { get; set; }

        [Display(Name = "Описание")]
        public virtual string Description { get; set; }

        [Display(Name = "Соддержание")]
        public virtual string Text { get; set; }

        [Display(Name = "Ссылка на картинку")]
        public virtual string UrlToPreview { get; set; }

        [Display(Name = "SEO метатег Title")]
        public string MetaTitle { get; set; }

        [Display(Name = "SEO метатег Description")]
        public string MetaDescription { get; set; }

        [Display(Name = "SEO метатег Keywords")]
        public string MetaKeywords { get; set; }

        [Display(Name = "Время добавления")]
        public DateTime AddingDate { get; set; }
    }
}

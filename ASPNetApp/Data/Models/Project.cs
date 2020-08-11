using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetApp.Data.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string NameOfProject { get; set; }

        public string ShortDescription { get; set; }

        public string ExtendedDescription { get; set; }

        public List<string> Technologies { get; set; }

        public string UrlToPreview { get; set; }
    }
}

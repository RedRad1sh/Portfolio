using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPNetApp.Domain.Repositories.Abstract;

namespace ASPNetApp.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IProjectItemsRepository ProjectItems { get; set; }
    
        public DataManager(ITextFieldsRepository textFields, IProjectItemsRepository projectItems)
        {
            TextFields = textFields;
            ProjectItems = projectItems;
        }
    }
}

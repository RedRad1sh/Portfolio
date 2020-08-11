using ASPNetApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetApp.Domain.Repositories.Abstract
{
    public interface IProjectItemsRepository
    {


        IQueryable<ProjectItem> GetAllProjectItems();

        ProjectItem GetProjectItemById(Guid Id);

        ProjectItem GetProjectItemByCodeWord(string codeWord);

        void SaveProjectItem(ProjectItem projectItem);

        void DeleteProjectItem(Guid Id);


    }
}

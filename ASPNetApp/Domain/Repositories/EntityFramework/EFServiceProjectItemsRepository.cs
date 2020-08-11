using ASPNetApp.Domain.Entities;
using ASPNetApp.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetApp.Domain.Repositories.EntityFramework
{
    public class EFServiceProjectItemsRepository : IProjectItemsRepository
    {
        private readonly AppDbContext Context;

        public EFServiceProjectItemsRepository(AppDbContext context)
        {
            Context = context;
        }

        public void DeleteProjectItem(Guid id)
        {
            Context.ProjectItems.Remove(new ProjectItem() { Id = id });
            Context.SaveChanges();
        }

        public IQueryable<ProjectItem> GetAllProjectItems()
        {
            return Context.ProjectItems;

        }

        public ProjectItem GetProjectItemByCodeWord(string codeWord)
        {
            return Context.ProjectItems.FirstOrDefault(x => x.CodeWord == codeWord);
        }

        public ProjectItem GetProjectItemById(Guid id)
        {
            return Context.ProjectItems.FirstOrDefault(x => x.Id == id);
        }

        public void SaveProjectItem(ProjectItem projectItem)
        {
            if (projectItem.Id == default)
                Context.Entry(projectItem).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            else
                Context.Entry(projectItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPNetApp.Domain.Entities;
using ASPNetApp.Domain.Repositories.Abstract;

namespace ASPNetApp.Domain.Repositories.EntityFramework
{
    public class EFServiceTextFieldsRepository: ITextFieldsRepository
    {
        private readonly AppDbContext Context;

        public EFServiceTextFieldsRepository(AppDbContext context)
        {
            Context = context;
        }

        public void DeleteTextField(Guid id)
        {
            Context.TextFields.Remove(new TextField() { Id = id });
            Context.SaveChanges();
        }


        public TextField GetTextFieldByCodeWord(string codeWord)
        {
            return Context.TextFields.FirstOrDefault(x => x.CodeWord == codeWord);
        }

        public TextField GetTextFieldById(Guid id)
        {
            return Context.TextFields.FirstOrDefault(x => x.Id == id);
        }

        public void SaveTextField(TextField TextField)
        {
            if (TextField.Id == default)
                Context.Entry(TextField).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            else
                Context.Entry(TextField).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
        }

        IQueryable<TextField> ITextFieldsRepository.GetAllTextFields()
        {
            return Context.TextFields;
        }
    }

}


using ASPNetApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetApp.Domain.Repositories.Abstract
{
    public interface ITextFieldsRepository
    {
        IQueryable<TextField> GetAllTextFields();

        TextField GetTextFieldById(Guid Id);

        TextField GetTextFieldByCodeWord(string codeWord);

        void SaveTextField(TextField textField);

        void DeleteTextField(Guid id);
    }
}

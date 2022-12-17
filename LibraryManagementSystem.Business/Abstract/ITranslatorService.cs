using LibraryManagementSystem.Core.Utilities.Results;
using LibraryManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Business.Abstract
{
    public interface ITranslatorService
    {
        IDataResult<List<Translator>> GetAll();
        IDataResult<Translator> GetById(int id);
        IResult Add(Translator translator);
        IResult Update(Translator translator);
        IResult Delete(Translator translator);
    }
}

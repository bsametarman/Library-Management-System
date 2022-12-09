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
        List<Translator> GetAll();
        Translator Get(int id);
        void Add(Translator translator);
        void Update(Translator translator);
        void Delete(Translator translator);
    }
}

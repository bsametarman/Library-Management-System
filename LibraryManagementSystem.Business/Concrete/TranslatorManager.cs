using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.DataAccess.Abstract;
using LibraryManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Business.Concrete
{
    public class TranslatorManager : ITranslatorService
    {
        private ITranslatorDal _translatorDal;

        public TranslatorManager(ITranslatorDal translatorDal)
        {
            _translatorDal = translatorDal;
        }

        public void Add(Translator translator)
        {
            _translatorDal.Add(translator);
        }

        public void Delete(Translator translator)
        {
            _translatorDal.Delete(translator);
        }

        public Translator Get(int id)
        {
            return _translatorDal.Get(t => t.TranslatorId == id);
        }

        public List<Translator> GetAll()
        {
            return _translatorDal.GetAll();
        }

        public void Update(Translator translator)
        {
            _translatorDal.Update(translator);
        }
    }
}

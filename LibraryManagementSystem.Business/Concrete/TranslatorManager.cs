using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Core.Utilities.Results;
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

        public IResult Add(Translator translator)
        {
            _translatorDal.Add(translator);
            return new SuccessResult("Başarıyla eklendi !!!");
        }

        public IResult Delete(Translator translator)
        {
            _translatorDal.Delete(translator);
            return new SuccessResult("Başarıyla silindi");
        }

        public IDataResult<Translator> Get(int id)
        {
            return new SuccessDataResult<Translator>(_translatorDal.Get(t => t.TranslatorId == id), "Başarıyla listelendi !!!");
        }

        public IDataResult<List<Translator>> GetAll()
        {
            return new SuccessDataResult<List<Translator>>(_translatorDal.GetAll(), "Başarıyla listelendi !!!");
        }

        public IResult Update(Translator translator)
        {
            _translatorDal.Update(translator);
            return new SuccessResult("Başarıyla güncellendi !!!");
        }
    }
}

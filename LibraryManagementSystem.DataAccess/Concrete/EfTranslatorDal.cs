using LibraryManagementSystem.Core.DataAccess.EntityFramework;
using LibraryManagementSystem.DataAccess.Abstract;
using LibraryManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DataAccess.Concrete
{
    public class EfTranslatorDal : EfEntityRepositoryBase<Translator, LibraryContext>, ITranslatorDal
    {
    }
}

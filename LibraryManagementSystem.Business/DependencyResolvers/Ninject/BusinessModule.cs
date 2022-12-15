using LibraryManagementSystem.Business.Abstract;
using LibraryManagementSystem.Business.Concrete;
using LibraryManagementSystem.DataAccess.Abstract;
using LibraryManagementSystem.DataAccess.Concrete;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {

            Bind<DbContext>().To<LibraryContext>().InSingletonScope();

            Bind<IAuthorService>().To<AuthorManager>().InSingletonScope();
            Bind<IAuthorDal>().To<EfAuthorDal>().InSingletonScope();

            Bind<IBookService>().To<BookManager>().InSingletonScope();
            Bind<IBookDal>().To<EfBookDal>().InSingletonScope();

            Bind<IEmployeeService>().To<EmployeeManager>().InSingletonScope();
            Bind<IEmployeeDal>().To<EfEmployeeDal>().InSingletonScope();

            Bind<IGenreService>().To<GenreManager>().InSingletonScope();
            Bind<IGenreDal>().To<EfGenreDal>().InSingletonScope();

            Bind<IPublisherService>().To<PublisherManager>().InSingletonScope();
            Bind<IPublisherDal>().To<EfPublisherDal>().InSingletonScope();

            Bind<ITranslatorService>().To<TranslatorManager>().InSingletonScope();
            Bind<ITranslatorDal>().To<EfTranslatorDal>().InSingletonScope();

            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();

        }
    }
}

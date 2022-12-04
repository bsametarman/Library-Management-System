﻿using LibraryManagementSystem.Core.DataAccess;
using LibraryManagementSystem.Core.DataAccess.EntityFramework;
using LibraryManagementSystem.DataAccess.Concrete;
using LibraryManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DataAccess.Abstract
{
    public interface IBookDal : IEntityRepository<Book>
    {
    }
}

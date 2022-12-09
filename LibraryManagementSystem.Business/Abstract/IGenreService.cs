﻿using LibraryManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Business.Abstract
{
    public interface IGenreService
    {
        List<Genre> GetAll();
        Genre Get(int id);
        void Add(Genre genre);
        void Update(Genre genre);
        void Delete(Genre genre);
    }
}

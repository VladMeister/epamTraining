﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity item);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Save();
    }
}

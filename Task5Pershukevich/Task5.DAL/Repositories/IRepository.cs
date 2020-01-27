﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        int Add(TEntity item);
        void Delete(TEntity item);
        TEntity GetById(int? id);
        IEnumerable<TEntity> GetAll();
        void Save();
    }
}

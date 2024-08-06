﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        public IQueryable<T> FindAll(bool trackChanges);
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}

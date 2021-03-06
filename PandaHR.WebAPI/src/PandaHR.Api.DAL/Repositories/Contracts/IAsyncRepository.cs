﻿using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PandaHR.Api.DAL.Repositories.Contracts
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task<int> SaveAsync();
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
                                   Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                   Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                   bool disableTracking = true,
                                   bool ignoreQueryFilters = false);
      
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null,
                                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                       Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                       bool disableTracking = true,
                                       bool ignoreQueryFilters = false);

        Task<T> GetByIdAsync(Guid id);
    }
}

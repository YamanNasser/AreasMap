﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AreasMap.Repository.Core.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        bool Any(Expression<Func<TEntity, bool>> predicate);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        Task BulkInsertAsync(IEnumerable<TEntity> entity);
        Task BulkInsertIncludeGraphAsync(IEnumerable<TEntity> entity);
        Task BulkMergeAsync(IEnumerable<TEntity> entity);
        Task BulkMergeIncludeGraphAsync(IEnumerable<TEntity> entity);
        Task BulkUpdateAsync(IEnumerable<TEntity> entity);
        Task BulkUpdateIncludeGraphAsync(IEnumerable<TEntity> entity);
        long Count(Expression<Func<TEntity, bool>> predicate);

        long Count();

        Task<long> CountAsync();

        Task<long> CountAsync(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity Get(string id);

        IEnumerable<TEntity> GetAll();

        void Remove(string id);

        TEntity Single(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
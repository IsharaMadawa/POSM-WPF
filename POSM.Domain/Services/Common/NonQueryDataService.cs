using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using POSM.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace POSM.EntityFramework.Services.Common
{
    public class NonQueryDataService<T> where T : class
    {
        private readonly POSMContextFactory _contextFactory;

        public NonQueryDataService(POSMContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using (POSMContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }

        public async Task<T> Update(T entity)
        {
            using (POSMContext context = _contextFactory.CreateDbContext())
            {
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }

        public async Task<bool> Delete(T entity)
        {
            using (POSMContext context = _contextFactory.CreateDbContext())
            {
                T entityToRemove = await context.Set<T>().FirstOrDefaultAsync((e) => e == entity);
                context.Set<T>().Remove(entityToRemove);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            using (var context = new POSMContext())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .ToList<T>();
            }
            return list;
        }

        public virtual IList<T> GetList(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            using (var context = new POSMContext())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .ToList<T>();
            }
            return list;
        }

        public virtual T GetSingle(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;
            using (var context = new POSMContext())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                item = dbQuery
                    .AsNoTracking() //Don't track any changes for the selected item
                    .FirstOrDefault(where); //Apply where clause
            }
            return item;
        }

        /* rest of code omitted */
    }
}

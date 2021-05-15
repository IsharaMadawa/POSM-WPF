using Microsoft.EntityFrameworkCore;
using POSM.EntityFramework.Models;
using POSM.EntityFramework.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace POSM.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : class
    {
        private readonly POSMContextFactory _contextFactory;
        private readonly NonQueryDataService<T> _nonQueryDataService;

        public GenericDataService(POSMContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<T>(contextFactory);
        }

        public async Task<T> Create(T entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

		public async Task<bool> Delete(T entity)
		{
            return await _nonQueryDataService.Delete(entity);
        }

		public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
		{
            return _nonQueryDataService.GetSingle(where, navigationProperties);
        }

		public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
		{
            return _nonQueryDataService.GetAll(navigationProperties);
        }

		public IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
		{
            return _nonQueryDataService.GetList(where, navigationProperties);
        }

		public async Task<T> Update(T entity)
        {
            return await _nonQueryDataService.Update(entity);
        }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POSM.EntityFramework.Services.Common
{
    public interface IDataService<T> where T : class
    {
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);

        IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);

        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task<bool> Delete(T entity);
    }
}

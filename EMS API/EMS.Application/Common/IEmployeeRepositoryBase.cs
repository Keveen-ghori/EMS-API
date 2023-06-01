using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Common
{
    public interface IEmployeeRepositoryBase<T>
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);
        IQueryable<T> GetById(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

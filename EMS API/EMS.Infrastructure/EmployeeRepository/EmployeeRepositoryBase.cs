using EMS.Application.Common;
using EMS.Data.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Infrastructure.EmployeeRepository
{
    public class EmployeeRepositoryBase<T>: IEmployeeRepositoryBase<T> where T: class
    {
        private readonly EmployeeManagementContext context;

        public EmployeeRepositoryBase(EmployeeManagementContext context)
        {
            this.context = context;
        }

        public void Create(T entity)
        {
            this.context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return this.context.Set<T>().Where(expression).AsNoTracking();
        }

        public IQueryable<T> GetById(Expression<Func<T, bool>> expression)
        {
            return this.context.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            this.context.Set<T>().Update(entity);
        }
    }
}

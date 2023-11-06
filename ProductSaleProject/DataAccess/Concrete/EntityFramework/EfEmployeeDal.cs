using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEmployeeDal : IEmployeeDal
    {
        public Task<bool> AddAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> Get(Expression<Func<Employee, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetAll(Expression<Func<Employee, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}

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
    public class EfCustomerDal : ICustomerDal
    {
        public Task<bool> AddAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Get(Expression<Func<Customer, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}

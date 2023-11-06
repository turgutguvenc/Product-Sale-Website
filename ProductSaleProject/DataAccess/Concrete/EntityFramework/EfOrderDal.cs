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
    public class EfOrderDal : IOrderDal
    {
        public Task<bool> AddAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<Order> Get(Expression<Func<Order, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAll(Expression<Func<Order, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}

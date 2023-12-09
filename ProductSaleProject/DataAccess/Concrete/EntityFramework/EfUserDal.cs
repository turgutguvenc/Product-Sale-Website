using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : IUserDal
    {
        private readonly NorthwindDbContext _context;
        public EfUserDal(NorthwindDbContext context)
        {
            _context = context; 
        }
        public async Task<bool> AddAsync(User entity)
        {
            var user = await _context.Users.FindAsync(entity.Id);
            if(user == null)
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
            }

            return user == null;
        }

        public async Task<bool> UpdateAsync(User entity)
        {
            var userToUpdate = await _context.Users.FirstOrDefaultAsync(u => u.Id == entity.Id);
            if(userToUpdate != null)
            {
                userToUpdate.FirstName = entity.FirstName;  
                userToUpdate.LastName = entity.LastName;
                userToUpdate.Status = entity.Status;
                userToUpdate.Email = entity.Email;  
                await _context.SaveChangesAsync();  
            }
            return userToUpdate != null;
        }

        public async Task<bool> DeleteAsync(User entity)
        {
            var userToDelete = await _context.Users.FirstOrDefaultAsync(u=> u.Id == entity.Id);
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                await _context.SaveChangesAsync();
            }
            return userToDelete != null;
        }

        public async Task<User> Get(Expression<Func<User, bool>> filter)
        {
            return await _context.Users.FirstOrDefaultAsync(filter);
        }
 

        public async Task<List<User>> GetAll(Expression<Func<User, bool>> filter = null)
        {
            if(filter == null)
            {
                return await _context.Users.ToListAsync();
            }
            else
            {
                return await _context.Users.Where(filter).ToListAsync();
            }
        }

        public async Task<List<OperationClaim>> GetClaims(User user)
        {
            var result = from operationClaim in _context.OperationClaims
                         join userOperationClaim in _context.UserOperationClaims
                         on operationClaim.Id equals userOperationClaim.Id
                         where userOperationClaim.UserId == user.Id
                         select new OperationClaim()
                         {
                             Id = operationClaim.Id,
                             Name = operationClaim.Name
                         };
            return await result.ToListAsync();

        }

        public async Task<bool> SaveChangesAsync()
        {
          return (await _context.SaveChangesAsync() >= 0);
        }

    }
}

using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class UserRepository : IUserRepository
    {

        UserDatabase _dbContext;
        private DbSet<User> _dbSet;

        public UserRepository(UserDatabase dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<User>();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var allUsers = await _dbSet.ToListAsync();
            return allUsers;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _dbSet.FindAsync(id);
            return user;
        }

        public async Task<User> InsertUserAsync(User user)
        {
            await _dbSet.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _dbSet.Update(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            var userToDelete = await _dbSet.FindAsync(id);
            _dbSet.Remove(userToDelete);
            await _dbContext.SaveChangesAsync();
            return userToDelete;
        }

    }
}

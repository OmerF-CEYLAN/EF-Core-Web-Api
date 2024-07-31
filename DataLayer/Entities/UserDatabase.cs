using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class UserDatabase : DbContext
    {

        public UserDatabase(DbContextOptions<UserDatabase> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(user =>
            {
                
                user.OwnsOne(x => x.Company);

                user.OwnsOne(x => x.Adress, address =>
                {
                    address.OwnsOne(a => a.Geo);
                });

            });

        }

        public DbSet<User> Users { get; set; }


    }
}

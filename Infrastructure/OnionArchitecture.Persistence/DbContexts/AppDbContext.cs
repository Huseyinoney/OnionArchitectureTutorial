using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Common;
using OnionArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistence.DbContexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        //veritabanı bağlantısı eklenecek
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().OwnsOne(x => x.Location);
            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var data = ChangeTracker.Entries<EntityBase>();

            foreach (var item in data)
            {
                if(item.State == EntityState.Added)
                {
                    item.Entity.CreatedDate = DateTime.UtcNow;
                }
                else if (item.State == EntityState.Modified)
                {
                    item.Entity.UpdatedDate = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}

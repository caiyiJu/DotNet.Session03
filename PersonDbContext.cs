using DotNet.Session03.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DotNet.Session03
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }

        public override int SaveChanges()
        {
            var selectedEntities = ChangeTracker.Entries()
                                    .Where(x => x.Entity is Person && (x.State == EntityState.Deleted));

            foreach (var entity in selectedEntities)
            {

                ((Person)entity.Entity).IsDeleted = true;
                entity.State = EntityState.Modified;
            }

            return base.SaveChanges();
        }
    }
}


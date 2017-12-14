using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.RepositoryModel;

namespace DataAccess
{
    public class PortalContext : DbContext
    {
        public PortalContext()
            : base("RndConnection")
        {
        }

        public PortalContext(string connectionString)
            : base(connectionString)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<RefreshToken> RefreshToken { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}

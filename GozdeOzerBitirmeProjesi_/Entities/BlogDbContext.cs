using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GozdeOzerBitirmeProjesi_.Entities
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext():base ("BlogDBConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogDbContext, Migrations.Configuration>("BlogDbConnection"));

        }
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<User> Users { get; set; }

        
    }
}
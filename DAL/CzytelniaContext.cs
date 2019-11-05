using seminarium.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace seminarium.DAL
{
    public class CzytelniaContext:DbContext

    {

        public CzytelniaContext() : base("CzytelniaContext")
        {
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryBook> CategoryBooks { get; set; }
        public DbSet<PublishingBook> PublishingBooks { get; set; }
        public DbSet<PublishingHouse> PublishingHouses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
using ContenManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ContenManagementSystem.DAL
{
    public class LeftFooterContext:DbContext
    {
        public LeftFooterContext() : base("DefaultConnection") {}
        public DbSet<LeftFooterModel> leftFooterModel { get; set; }
        public DbSet<feedBackPage> feedBackPages { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<ContenManagementSystem.Models.Page> Pages { get; set; }
    }
}
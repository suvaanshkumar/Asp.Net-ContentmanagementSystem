using ContenManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ContenManagementSystem.DAL
{
    public class CompanyContext : DbContext
    {
        public CompanyContext() : base("DefaultConnection") {}

        public DbSet<CompanyDescClass> CompanyDescClasses { get; set; }
        public DbSet<CompanyEmployee> Employees{ get; set; }
        public DbSet<CompanyOpenHours> OpenHours { get; set; }
        public DbSet<FrequentQuestion> faqs { get; set; }
    }
}
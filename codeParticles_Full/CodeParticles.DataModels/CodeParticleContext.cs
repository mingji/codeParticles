using CodeParticles.DataModels.Mappings;
using CodeParticles.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParticles.DataModels
{
    public class CodeParticleContext : DbContext
    {
        static CodeParticleContext()
        {

        }

        public CodeParticleContext()
            : base("Name=CodeParticles_Business")
        {
        }

        public DbSet<CodeElement> CodeElements { get; set; }
        //public DbSet<Tag> Tags { get; set; }
        //public DbSet<Language> Languages { get; set; }
        //public DbSet<Rejex> Rejects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CodeElementMap());
        }
    }
}

using CodeParticles.DataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParticles.DataModels.Mappings
{
    public class CodeElementMap : EntityTypeConfiguration<CodeElement>
    {
        public CodeElementMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Created).HasColumnType("datetime");
            this.Property(t => t.Text).HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("CodeElemnt");
            this.Property(t => t.Id).HasColumnName("ID");
            this.Property(t => t.Created).HasColumnName("CreatedDate");
            this.Property(t => t.Text).HasColumnName("Text");
        }
    }
}

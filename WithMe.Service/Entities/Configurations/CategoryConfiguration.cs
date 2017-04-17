using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WithMe.Service.Entities.Tables;

namespace WithMe.Service.Entities.Configurations
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration() : this("dbo")
        {

        }

        public CategoryConfiguration(string schema)
        {
            ToTable(schema + ".CategoryTable");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName(@"Name").IsRequired().HasColumnType("nvarchar").HasMaxLength(40);
            Property(x => x.Image).HasColumnName(@"Image").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
        }
    }
}
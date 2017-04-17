using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WithMe.Service.Entities.Tables;

namespace WithMe.Service.Entities.Configurations
{
    public class LoggingConfiguration : EntityTypeConfiguration<Logging>
    {
        public LoggingConfiguration() : this("dbo")
        {

        }

        public LoggingConfiguration(string schema)
        {
            ToTable(schema + ".LoggingTable");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Table).HasColumnName(@"Table").IsRequired().HasColumnType("nvarchar").HasMaxLength(40);
            Property(x => x.Operation).HasColumnName(@"Operation").IsRequired().HasColumnType("nvarchar").HasMaxLength(40);
            Property(x => x.CreateDate).HasColumnName(@"CreateDate").IsRequired().HasColumnType("datetime");
        }
    }
}
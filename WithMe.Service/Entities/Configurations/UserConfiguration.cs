using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WithMe.Service.Entities.Tables;

namespace WithMe.Service.Entities.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration() : this("dbo")
        {

        }

        public UserConfiguration(string schema)
        {
            ToTable(schema + ".UserTable");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.FBid).HasColumnName(@"FBid").IsRequired().HasColumnType("nvarchar").HasMaxLength(40);
            Property(x => x.FirstName).HasColumnName(@"FirstName").IsRequired().HasColumnType("nvarchar").HasMaxLength(40);
            Property(x => x.LastName).HasColumnName(@"LastName").IsRequired().HasColumnType("nvarchar").HasMaxLength(40);
            Property(x => x.Email).HasColumnName(@"Email").IsRequired().HasColumnType("nvarchar").HasMaxLength(40);
            Property(x => x.Image).HasColumnName(@"Image").IsRequired().HasColumnType("nvarchar").HasMaxLength(40);
            Property(x => x.DeviceName).HasColumnName(@"DeviceName").IsRequired().HasColumnType("nvarchar").HasMaxLength(40);
            Property(x => x.DeviceNumber).HasColumnName(@"DeviceNumber").IsRequired().HasColumnType("nvarchar").HasMaxLength(40);
        }
    }
}
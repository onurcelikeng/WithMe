using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WithMe.Service.Entities.Tables;

namespace WithMe.Service.Entities.Configurations
{
    public class ActivityConfiguration : EntityTypeConfiguration<Activity>
    {
        public ActivityConfiguration() : this("dbo")
        {

        }

        public ActivityConfiguration(string schema)
        {
            ToTable(schema + ".ActivityTable");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CategoryId).HasColumnName(@"CategoryId").IsOptional().HasColumnType("int");
            Property(x => x.ReqUserId).HasColumnName(@"ReqUserId").IsOptional().HasColumnType("int");
            Property(x => x.ResUserId).HasColumnName(@"ResUserId").IsOptional().HasColumnType("int");
            Property(x => x.Description).HasColumnName(@"Description").IsRequired().HasColumnType("nvarchar").HasMaxLength(140);
            Property(x => x.CreateDate).HasColumnName(@"CreateDate").IsRequired().HasColumnType("datetime");

            HasOptional(a => a.Category).WithMany(b => b.Activitys).HasForeignKey(c => c.CategoryId).WillCascadeOnDelete(false);
            HasOptional(a => a.ReqUser).WithMany(b => b.ReqActivities).HasForeignKey(c => c.ResUserId).WillCascadeOnDelete(false);
            HasOptional(a => a.ResUser).WithMany(b => b.ResActivities).HasForeignKey(c => c.ReqUserId).WillCascadeOnDelete(false);
        }
    }
}
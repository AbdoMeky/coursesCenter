using coursesCenter.Models.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace coursesCenter.Models.data.config
{
    public class ManagerConfig : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(60);
            builder.Property(x => x.Address).HasColumnType("VARCHAR").HasMaxLength(100);
            builder.HasOne(x=>x.Departrment).WithOne(x=>x.Manager).HasForeignKey<Manager>(x=>x.DepartmentId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(x => x.ApplicationUser).WithOne(x => x.Manager).HasForeignKey<Manager>(x => x.ApplicationUserId).OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("Managers");
        }
    }
}

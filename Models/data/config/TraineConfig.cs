using coursesCenter.Models.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace coursesCenter.Models.data.config
{
    public class TraineConfig : IEntityTypeConfiguration<Traine>
    {
        public void Configure(EntityTypeBuilder<Traine> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(60).IsRequired();
            builder.Property(x => x.Address).HasColumnType("VARCHAR").HasMaxLength(100).IsRequired();
            builder.HasOne(x=>x.Departrment).WithMany(x=>x.Traines).HasForeignKey(x=>x.DepartmentId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(x=>x.ApplicationUser).WithOne(x=>x.Traine).HasForeignKey<Traine>(x=>x.ApplicationUserId).OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("Traines");
        }
    }
}

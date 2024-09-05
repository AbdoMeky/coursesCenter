using coursesCenter.Models.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace coursesCenter.Models.data.config
{
    public class DepartmentConfig : IEntityTypeConfiguration<Departrment>
    {
        public void Configure(EntityTypeBuilder<Departrment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(30);
            builder.ToTable("Departments");
        }
    }
}

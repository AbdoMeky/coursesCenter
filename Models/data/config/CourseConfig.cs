using coursesCenter.Models.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace coursesCenter.Models.data.config
{
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(30).IsRequired();
            builder.HasOne(x => x.Departrment).WithMany(x => x.Courses).HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.SetNull);
            builder.ToTable("Courses");
        }
    }
}

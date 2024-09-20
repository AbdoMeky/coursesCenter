using coursesCenter.Models.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace coursesCenter.Models.data.config
{
    public class InstructorConfig : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("VARCHAR").HasMaxLength(60);
            builder.Property(x => x.Address).HasColumnType("VARCHAR").HasMaxLength(100);
            builder.HasOne(x => x.Course).
                WithMany(x => x.Instructors).
                HasForeignKey(x => x.CourseId).
                OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(x => x.Departrment).
                WithMany(x => x.Instructors).
                HasForeignKey(x => x.DepartmentId).
                OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(x => x.ApplicationUser).WithOne(x => x.Instructor).HasForeignKey<Instructor>(x =>x.ApplicationUserId).OnDelete(DeleteBehavior.Cascade).IsRequired();
            builder.ToTable("Instructors");

        }
    }
}

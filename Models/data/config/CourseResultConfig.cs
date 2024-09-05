using coursesCenter.Models.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace coursesCenter.Models.data.config
{
    public class CourseResultConfig : IEntityTypeConfiguration<CourseResult>
    {
        public void Configure(EntityTypeBuilder<CourseResult> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Course).WithMany(x=>x.courseResults).HasForeignKey(x=>x.CourseId).OnDelete(DeleteBehavior.Cascade).IsRequired();
            builder.HasOne(x => x.Traine).WithMany(x => x.CourseResults).HasForeignKey(x => x.TraineId).OnDelete(DeleteBehavior.Cascade).IsRequired();
            builder.ToTable("CourseResults");
        }
    }
}

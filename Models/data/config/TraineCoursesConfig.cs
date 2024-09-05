using coursesCenter.Models.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace coursesCenter.Models.data.config
{
    public class TraineCoursesConfig : IEntityTypeConfiguration<TraineCourse>
    {
        public void Configure(EntityTypeBuilder<TraineCourse> builder)
        {
            builder.HasKey(x => new {x.TraineId,x.CourseId});
            builder.HasOne(x => x.Course).WithMany(x => x.Trainecourses).HasForeignKey(x => x.CourseId).OnDelete(DeleteBehavior.Cascade).IsRequired();
            builder.HasOne(x => x.Traine).WithMany(x => x.TraineCourses).HasForeignKey(x => x.TraineId).OnDelete(DeleteBehavior.Cascade).IsRequired();
            builder.ToTable("TraineCourses");
        }
    }
}

namespace coursesCenter.Models.entities
{
    public class TraineCourse
    {
        public int CourseId {  get; set; }
        public Course? Course { get; set; }
        public int TraineId { get; set; }
        public Traine? Traine { get; set; }
    }
}

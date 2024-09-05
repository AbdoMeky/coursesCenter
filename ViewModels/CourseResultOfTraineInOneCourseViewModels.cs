namespace coursesCenter.ViewModels
{
    public class CourseResultOfTraineInOneCourseViewModels
    {

        public string TraineName {  get; set; }
        public string CourseName { get; set; }
        public List<decimal>results { get; set; }
        public CourseResultOfTraineInOneCourseViewModels()
        {
            results = new List<decimal>();
        }
    }
}

namespace coursesCenter.ViewModels
{
    public class CourseResultForCourseViewModel
    {
        public string CourseName {  get; set; }
        public List<TraineDegree>results { get; set; }
        public CourseResultForCourseViewModel()
        {
            results = new List<TraineDegree>();
        }
    }

    public class TraineDegree
    {
        public string Name {  get; set; }
        public decimal Degree {  get; set; }
        public TraineDegree(string Name,decimal Degree)
        {
            this.Name = Name;
            this.Degree = Degree;
        }
    }
}

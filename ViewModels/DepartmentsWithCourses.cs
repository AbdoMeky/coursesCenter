namespace coursesCenter.ViewModels
{
    public class DepartmentsWithCourses
    {
        public string Department {  get; set; }
        public List<string> Courses { get; set; }=new List<string>();
    }
}

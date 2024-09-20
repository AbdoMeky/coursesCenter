namespace coursesCenter.ViewModels
{
    public class OneTraineResultViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public List<string>? Courses { get; set; } = new List<string>();
        public List<double>? Result { get; set; }=new List<double>();
    }
}

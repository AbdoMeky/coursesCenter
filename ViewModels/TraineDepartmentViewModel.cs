namespace coursesCenter.ViewModels
{
    public class TraineDepartmentViewModel
    {
        public int Id {  get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public List<string>? Courses{ get; set; }=new List<string>();
    }
}

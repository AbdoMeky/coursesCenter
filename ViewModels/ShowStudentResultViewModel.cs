namespace coursesCenter.ViewModels
{
    public class Result
    {
        public Result(decimal Grade,string Cours,string Color)
        {
            this.Grade = Grade;
            this.Cours = Cours; 
            this.Color = Color;
        }
        public decimal? Grade { get; set; }
        public string? Cours { get; set; }
        public string? Color { get; set; }
    }
    public class ShowStudentResultViewModel
    {
        public String Name { get; set; }
        public List<Result>? Results { get; set; }=new List<Result>();

    }
    
}

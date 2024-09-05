using Microsoft.AspNetCore.Mvc;

namespace coursesCenter.Models.entities
{
    public class CourseResult
    {
        public int Id { get; set; }
        [Remote(action:"CheckDegree",controller:"CourseResult",AdditionalFields ="CourseId",ErrorMessage ="the result you enter not between 0 and maximum degree of course")]
        public Decimal Degree { get; set; }
        public int? DepartmentId { get; set; }
        public Departrment? Departrment { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public int TraineId { get; set; }
        public Traine? Traine { get; set; }
    }
}

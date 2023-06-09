using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Course
    {
        [Key]
        [Column("courseId")]
        //课程id
        public int id { get; set; }

        [Column("courseName")]
        // 课程名称
        public string courseName { get; set; } = null!;
        [Column("teacherId")]
        //上课老师
        public int teacherId { get; set; }
        [Column("startTime")]
        //上课时间 填1，2，3，4，为第几节开始
        public DateTime startTime { get; set; }
        [Column("endTime")]
        //上课时间 填1，2，3，4，为第几节结束
        public DateTime endTime { get; set; }
        public string url { get; set; }
    }
}

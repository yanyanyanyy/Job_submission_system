using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobSubmissionSystem.Models
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
        public string teacherId { get; set; } = null!;
        [Column("teacherName")]
        //老师姓名
        public string teacherName { get; set; } = null!;
        [Column("week")]
        //上课时间 填1，2，3，4，为第几周
        public int week { get; set; }
        [Column("startTime")]
        //上课时间 填1，2，3，4，为第几节开始
        public int startTime { get; set; }
        [Column("endTime")]
        //上课时间 填1，2，3，4，为第几节结束
        public int endTime { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Task
        //老师发布的作业
    {
        
        [Column("id")]
        public int Id { get; set; }
        [Column("courseId")]
        //所属课程id
        public int courseId { get; set; }

        [Column("name")]
        // 课程名称
        public string userName { get; set; } = null!;
        
        [Column("desc")]
        //作业描述
        public string desc { get; set; }
        [Column("startTime")]
        //开始时间
        public DateTime startTime { get; set; }
        [Column("endTime")]
        //截止日期
        public DateTime endTime { get; set; }
    }
}

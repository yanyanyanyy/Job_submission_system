using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobSubmissionSystem.Models
{
    public class TaskForStudent
        //学生提交的作业
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("taskId")]
        //所属课程id
        public int taskId { get; set; }

        [Column("url")]
        //作业地址，具体到文件
        public int url { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class JobLibrary
        //学生的作业库
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

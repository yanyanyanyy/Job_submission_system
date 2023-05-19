using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobSubmissionSystem.Models
{
    public partial class Student
    {
        [Key]
        [Column("userId")]
        //用户id，与User中的Id相同
        public int id { get; set; }

        [Column("studentId")]
        // 学号
        public string studentId { get; set; } = null!;
        [Column("name")]
        // 用户名，真实姓名
        public string userName { get; set; } = null!;
        [Column("college ")]
        //所在学院
        public string college { get; set; } = null!;
    }
}

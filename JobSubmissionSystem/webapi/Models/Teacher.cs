using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public partial class Teacher
    {
        [Key]
        [Column("userId")]
        //用户id，与User中的Id相同
        public int Id { get; set; }

        [Column("name")]
        // 用户名，真实姓名
        public string userName { get; set; } = null!;
    }
}

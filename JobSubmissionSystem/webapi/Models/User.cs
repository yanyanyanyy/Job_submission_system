using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public partial class User
    {
        // 登录验证使用
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("userName")]
        public string userName { get; set; } = null!;

        [Column("userPassword")]
        public string password { get; set; } = null!;
    }
}

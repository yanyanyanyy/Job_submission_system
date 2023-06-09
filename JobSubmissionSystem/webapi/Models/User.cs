using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public partial class User
    {
        // 登录验证使用
        [Key]
        [Column("UserId")]
        public int UserId { get; set; }

        [Column("Username")]
        public string Username { get; set; } = null!;

        [Column("Password")]
        public string password { get; set; } = null!;
        [Column("UserType")]
        public int UserType { get; set; } = -1;
    }
}

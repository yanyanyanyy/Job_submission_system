using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public partial class User
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("userName")]
        public string userName { get; set; } = null!;

        [Column("userPassword")]
        public string password { get; set; } = null!;
    }
}

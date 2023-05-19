using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobSubmissionSystem.Models
{
    public partial class User
    {
        [Key]
        [Column("userId")]
        public int Id { get; set; }

        [Column("userName")]
        public string userName { get; set; } = null!;

        [Column("userPassword")]
        public string Password { get; set; } = null!;
    }
}

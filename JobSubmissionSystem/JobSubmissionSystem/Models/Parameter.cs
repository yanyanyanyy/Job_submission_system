using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JobSubmissionSystem.Models
{
    public partial class Parameter
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("auto")]
        public string Auto { get; set; } = null!;

        [Column("plcaddress")]
        public string Plcaddress { get; set; } = null!;

        [Column("type")]
        public string Type { get; set; } = null!;

        [Column("swith")]
        public string Swith { get; set; } = null!;

        [Column("ceiling")]
        public string Ceiling { get; set; } = null!;

        [Column("limit")]
        public string Limit { get; set; } = null!;
    }

}

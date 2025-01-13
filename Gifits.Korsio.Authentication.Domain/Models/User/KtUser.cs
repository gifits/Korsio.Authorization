using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gifits.Korsio.Authorization.Domain.Models.User
{
    [Table("kt_users")]
    public class KtUser
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}

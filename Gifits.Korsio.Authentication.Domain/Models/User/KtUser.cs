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
        [Column("password_hash")]
        public string PasswordHash { get; set; }
        [Column("email_verified")]
        public bool EmailVerified { get; set; }
        //Audit
        [Column("create_date")]
        public DateTime CreateDate { get; set; }
        [Column("create_user_id")]
        public int CreateUserId { get; set; }
        [Column("update_date")]
        public DateTime? UpdateDate { get; set; }
        [Column("update_user_id")]
        public int? UpdateUserId { get; set; }
        [Column("delete_date")]
        public DateTime? DeleteDate { get; set; }
        [Column("delete_user_id")]
        public int? DeleteUserId { get; set; }
    }
}

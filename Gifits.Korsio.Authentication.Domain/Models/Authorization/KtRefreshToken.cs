using Gifits.Korsio.Authorization.Domain.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gifits.Korsio.Authorization.Domain.Models.Authorization
{
    [Table("kt_refresh_tokens")]
    public class KtRefreshToken
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Id))]
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresOnUtc { get; set; }

        public KtUser User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RepositoryModel
{
    public class RefreshToken
    {
        public Guid RefreshTokenId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ClientId { get; set; }

        public DateTime ExpiresUtc { get; set; }

        public DateTime IssuedUtc { get; set; }

        [Required]
        public string ProtectedTicket { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}

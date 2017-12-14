using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class RefreshTokenModel
    {
        public Guid RefreshTokenId { get; set; }
        public string ClientId { get; set; }
        public DateTime ExpiresUtc { get; set; }
        public DateTime IssuedUtc { get; set; }
        public string ProtectedTicket { get; set; }
        public Guid UserId { get; set; }
    }
}

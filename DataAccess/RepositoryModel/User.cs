using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.RepositoryModel
{
    public class User
    {
        public User()
        {
            CreatedDate = DateTime.UtcNow;
        }

        public Guid UserId { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string LoginName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Gender { get; set; }
        public int StatusId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}

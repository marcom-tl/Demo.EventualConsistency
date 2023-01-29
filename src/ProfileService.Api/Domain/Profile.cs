using System.ComponentModel.DataAnnotations;

namespace ProfileService.Api.Domain
{
    public class Profile
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        /// <summary>
        /// Date Of Birth
        /// </summary>
        public DateTime Dob { get; set; }
        
        public string Email { get; set; }
    }
}

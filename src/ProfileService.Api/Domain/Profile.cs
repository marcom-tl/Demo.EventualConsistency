using System.ComponentModel.DataAnnotations;

namespace ProfileService.Api.Domain
{
    public class Profile
    {
        public string Uuid { get; set; }
        public string FistName { get; set; }

        public string LastName { get; set; }

        /// <summary>
        /// Date Of Birth
        /// </summary>
        public DateTime Dob { get; set; }
        
        public string Email { get; set; }
    }
}

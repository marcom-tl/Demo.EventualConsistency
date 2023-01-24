namespace ProfileService.Api.Models
{
    public class ProfileModel
    {
        public int Id { get; set; }
        public string FistName { get; set; }

        public string LastName { get; set; }

        /// <summary>
        /// Date Of Birth
        /// </summary>
        public DateTime Dob { get; set; }

        public string Email { get; set; }
    }
}

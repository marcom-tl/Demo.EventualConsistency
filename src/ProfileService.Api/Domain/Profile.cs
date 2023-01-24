namespace ProfileService.Api.Domain
{
    public class Profile
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

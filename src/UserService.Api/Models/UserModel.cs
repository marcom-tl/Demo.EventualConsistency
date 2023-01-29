namespace UserService.Api.Models
{
    public class UserModel
    {
        public string Uuid { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public bool Disabled { get; set; }
    }
}

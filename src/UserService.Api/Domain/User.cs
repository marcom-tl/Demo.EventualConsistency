namespace UserService.Api.Domain
{
    public class User
    {
        public string Uuid { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public bool Disabled { get; set; }

    }
}

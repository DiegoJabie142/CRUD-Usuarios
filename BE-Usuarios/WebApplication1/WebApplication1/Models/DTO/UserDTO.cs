namespace WebApplication1.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; } //PK
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string PathPhoto { get; set; }
    }
}

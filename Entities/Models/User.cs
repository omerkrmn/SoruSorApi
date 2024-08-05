namespace Entities.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }
        public int Age { get; set; }
        public string? ProfilePictureUrl { get; set; }

        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}

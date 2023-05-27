namespace Molla_template_with_backend.Models
{
    public class TeamMember:BaseEntity
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}

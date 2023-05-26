namespace Molla_template_with_backend.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool SoftDelete { get; set; }
    }
}

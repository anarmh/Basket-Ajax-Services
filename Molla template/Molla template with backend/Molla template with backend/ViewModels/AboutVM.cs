using Molla_template_with_backend.Models;

namespace Molla_template_with_backend.ViewModels
{
    public class AboutVM
    {
        public IEnumerable<TeamMember> TeamMembers { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
    }
}

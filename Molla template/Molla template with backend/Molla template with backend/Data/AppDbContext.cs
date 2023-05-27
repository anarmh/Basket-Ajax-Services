using Microsoft.EntityFrameworkCore;
using Molla_template_with_backend.Models;

namespace Molla_template_with_backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderInfo> SliderInfos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BlogAuthor> BlogAuthors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
    }   
}

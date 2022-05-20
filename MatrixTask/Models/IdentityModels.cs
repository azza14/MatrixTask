using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MatrixTask.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Property> Properties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
               .HasMany<Property>(s => s.Tags)
               .WithMany(c => c.Products)
               .Map(cs =>
               {
                   cs.MapLeftKey("ProductId");
                   cs.MapRightKey("PropertyId");
                   cs.ToTable("ProductTags");
               });

            modelBuilder.Entity<Category>()
               .HasMany<Property>(s => s.Tags)
               .WithMany(c => c.Categories)
               .Map(cs =>
               {
                   cs.MapLeftKey("CategoryId");
                   cs.MapRightKey("PropertyId");
                   cs.ToTable("CategoryTags");
               });

            base.OnModelCreating(modelBuilder);
        }
    }
}
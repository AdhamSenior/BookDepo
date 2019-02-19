using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Bookstore.UI.Models
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

    public bool IsDelete { get; set; }

    public virtual ICollection<Book> BuyerBooks { get; set; }

    public virtual ICollection<Book> SellerBooks { get; set; }

  }

  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    public ApplicationDbContext()
        : base("DefaultConnection", throwIfV1Schema: false)
    {
    }

    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Book>()
               .HasOptional(s => s.Buyer)
               .WithMany(g => g.BuyerBooks)
               .HasForeignKey(s => s.BuyerId);

      modelBuilder.Entity<Book>()
         .HasOptional(s => s.Seller)
         .WithMany(g => g.SellerBooks)
         .HasForeignKey(s => s.SellerId);
    }

    public static ApplicationDbContext Create()
    {
      return new ApplicationDbContext();
    }

  }
}
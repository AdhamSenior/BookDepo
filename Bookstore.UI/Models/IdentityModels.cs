using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.DynamicFilters;
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

    public string FullName { get; set; }

    public bool IsDeleted { get; set; }

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

    public override int SaveChanges()
    {

      try
      {
        return base.SaveChanges();
      }
      catch (DbEntityValidationException e)
      {

        var sb = new StringBuilder();

        foreach (var eve in e.EntityValidationErrors)
        {
          sb.AppendLine(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State));

          foreach (var ve in eve.ValidationErrors)
          {
            sb.AppendLine(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
          }
        }

        throw new DbEntityValidationException(sb.ToString(), e);
      }
    }

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

      modelBuilder.Filter("IsDeleted", (Book a) => a.IsDeleted, false);
      modelBuilder.Filter("IsDeleted", (ApplicationUser a) => a.IsDeleted, false);
    }

    public static ApplicationDbContext Create()
    {
      return new ApplicationDbContext();
    }

  }
}
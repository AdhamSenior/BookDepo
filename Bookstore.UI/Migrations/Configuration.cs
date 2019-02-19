namespace Bookstore.UI.Migrations
{

  using Bookstore.UI.Models;
  using Microsoft.AspNet.Identity;
  using Microsoft.AspNet.Identity.EntityFramework;
  using System;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;

  internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = true;
      AutomaticMigrationDataLossAllowed = true;
    }

    protected override void Seed(ApplicationDbContext db)
    {
      if (!db.Roles.Any())
      {
        var manager = new ApplicationRoleManager(new RoleStore<IdentityRole>(db));

        manager.Create(new IdentityRole
        {
          Name = RoleList.Admin
        });

        manager.Create(new IdentityRole
        {
          Name = RoleList.Buyer
        });

        manager.Create(new IdentityRole
        {
          Name = RoleList.Seller
        });
      }

      if (!db.Users.Any())
      {
        var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
        var user1 = new ApplicationUser
        {
          Id = Guid.NewGuid().ToString(),
          Email = "admin@example.com",
          UserName = "admin@example.com",
          EmailConfirmed = true
        };
        manager.Create(user1, "admin@123456");
        manager.AddToRole(user1.Id, RoleList.Admin);

        var user2 = new ApplicationUser
        {
          Id = Guid.NewGuid().ToString(),
          Email = "seller@example.com",
          UserName = "seller@example.com",
          EmailConfirmed = true
        };
        manager.Create(user2, "seller@123456");
        manager.AddToRole(user2.Id, RoleList.Seller);

        var user3 = new ApplicationUser
        {
          Id = Guid.NewGuid().ToString(),
          Email = "buyer@example.com",
          UserName = "buyer@example.com",
          EmailConfirmed = true
        };
        manager.Create(user3, "buyer@123456");
        manager.AddToRole(user3.Id, RoleList.Buyer);

      }


      var buyer = db.Users.FirstOrDefault(a => a.Email == "buyer@example.com");
      var seller = db.Users.FirstOrDefault(a => a.Email == "seller@example.com");

      var books = new[]
      {
          new Book
        {
          Name = "Harry Potter",
          Author = "McMillan",
          Condition = "New",
          Discription = "the best book ever",
          ISBN = "11-22-33-44-55",
          Price = 25m,
          PublishYear = new DateTime(2015, 10, 10).ToShortDateString(),
          CoverImagePath = "~/Images/Covers/1.jpg",
          BuyerId=buyer.Id,
          SellerId=seller.Id
        },new Book
        {
          Name = "Harry Potter 2",
          Author = "McMillan",
          Condition = "New",
          Discription = "the best book ever",
          ISBN = "11-22-33-44-55",
          Price = 15m,
          PublishYear = new DateTime(2015, 10, 10).ToShortDateString(),
          CoverImagePath = "~/Images/Covers/2.jpg",
          BuyerId=buyer.Id,
          SellerId=seller.Id
        },new Book
        {
          Name = "Harry Potter 3",
          Author = "McMillan",
          Condition = "New",
          Discription = "the best book ever",
          ISBN = "11-22-33-44-55",
          Price = 25m,
          PublishYear = new DateTime(2015, 10, 10).ToShortDateString(),
          CoverImagePath = "~/Images/Covers/3.jpg",
          BuyerId=buyer.Id,
          SellerId=seller.Id
        },new Book
        {
          Name = "Harry Potter 4",
          Author = "McMillan",
          Condition = "New",
          Discription = "the best book ever",
          ISBN = "11-22-33-44-55",
          Price = 15m,
          PublishYear = new DateTime(2015, 10, 10).ToShortDateString(),
          CoverImagePath = "~/Images/Covers/4.jpg",
          BuyerId=buyer.Id,
          SellerId=seller.Id
        },new Book
        {
          Name = "Harry Potter 5",
          Author = "McMillan",
          Condition = "New",
          Discription = "the best book ever",
          ISBN = "11-22-33-44-55",
          Price = 25m,
          PublishYear = new DateTime(2015, 10, 10).ToShortDateString(),
          CoverImagePath = "~/Images/Covers/5.jpeg",
          BuyerId=buyer.Id,
          SellerId=seller.Id
        },new Book
        {
          Name = "Lord of rings",
          Author = "Smith",
          Condition = "New",
          Discription = "the best book ever",
          ISBN = "11-22-33-44-55",
          Price = 55m,
          PublishYear = new DateTime(2015, 10, 10).ToShortDateString(),
          CoverImagePath = "~/Images/Covers/6.jpg",
          BuyerId=buyer.Id,
          SellerId=seller.Id
        },new Book
        {
          Name = "From good to great",
          Author = "Jacobson",
          Condition = "New",
          Discription = "the best book ever",
          ISBN = "11-22-33-44-55",
          Price = 10m,
          PublishYear = new DateTime(2015, 10, 10).ToShortDateString(),
          CoverImagePath = "~/Images/Covers/9.jpg",
          BuyerId=buyer.Id,
          SellerId=seller.Id
        },new Book
        {
          Name = "Hobbit",
          Author = "Jacobson",
          Condition = "New",
          Discription = "the best book ever",
          ISBN = "11-22-33-44-55",
          Price = 100m,
          PublishYear = new DateTime(2015, 10, 10).ToShortDateString(),
          CoverImagePath = "~/Images/Covers/7.jpg",
          BuyerId=buyer.Id,
          SellerId=seller.Id
        },new Book
        {
          Name = "New Land",
          Author = "Smith",
          Condition = "New",
          Discription = "the best book ever",
          ISBN = "11-22-33-44-55",
          Price = 25m,
          PublishYear = new DateTime(2015, 10, 10).ToShortDateString(),
          CoverImagePath = "~/Images/Covers/10.jpg",
          BuyerId=buyer.Id,
          SellerId=seller.Id
        },new Book
        {
          Name = "Home Land",
          Author = "McMillon",
          Condition = "New",
          Discription = "the best book ever",
          ISBN = "11-22-33-44-55",
          Price = 100m,
          PublishYear = new DateTime(2015, 10, 10).ToShortDateString(),
          CoverImagePath = "~/Images/Covers/8.jpg",
          BuyerId=buyer.Id,
          SellerId=seller.Id
        }
      };
      db.Books.AddOrUpdate(a => a.Name, books);
    }
  }
}

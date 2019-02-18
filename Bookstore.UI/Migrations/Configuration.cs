namespace Bookstore.UI.Migrations
{
  using Bookstore.UI.BookContext;
  using Bookstore.UI.Models;
  using System;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;

  internal sealed class Configuration : DbMigrationsConfiguration<BookstoreEntities>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = true;
      AutomaticMigrationDataLossAllowed=true;
    }

    protected override void Seed(BookstoreEntities db)
    {
      var books = new[]
      {
          new BookModel
        {
          Name = "Harry Potter",
          Author = "McMillan",
          Condition = "New",
          Discription = "the best book ever",
          Status = true,
          ISBN = "dfdsfd",
          Price = 25m,
          PublishYear = new DateTime(2015, 10, 10).ToShortDateString(),
          CoverImagePath = "~/Images/Covers/1.jpg"
        },new BookModel
        {
          Name = "Harry Potter 2",
          Author = "McMillan",
          Condition = "New",
          Discription = "the best book ever",
          Status = true,
          ISBN = "dfdsfd",
          Price = 15m,
          PublishYear = new DateTime(2015, 10, 10).ToShortDateString(),
          CoverImagePath = "~/Images/Covers/2.jpg"
        },new BookModel
        {
          Name = "Harry Potter 3",
          Author = "McMillan",
          Condition = "New",
          Discription = "the best book ever",
          Status = true,
          ISBN = "dfdsfd",
          Price = 25m,
          PublishYear = new DateTime(2015, 10, 10).ToShortDateString(),
          CoverImagePath = "~/Images/Covers/3.jpg"
        },new BookModel
        {
          Name = "Harry Potter 4",
          Author = "McMillan",
          Condition = "New",
          Discription = "the best book ever",
          Status = true,
          ISBN = "dfdsfd",
          Price = 15m,
          PublishYear = new DateTime(2015, 10, 10).ToShortDateString(),
          CoverImagePath = "~/Images/Covers/4.jpg"
        },new BookModel
        {
          Name = "Harry Potter 5",
          Author = "McMillan",
          Condition = "New",
          Discription = "the best book ever",
          Status = true,
          ISBN = "dfdsfd",
          Price = 25m,
          PublishYear = new DateTime(2015, 10, 10).ToShortDateString(),
          CoverImagePath = "~/Images/Covers/5.jpeg"
        },new BookModel
        {
          Name = "Lord of rings",
          Author = "Smith",
          Condition = "New",
          Discription = "the best book ever",
          Status = true,
          ISBN = "dfdsfd",
          Price = 55m,
          PublishYear = new DateTime(2015, 10, 10).ToShortDateString(),
          CoverImagePath = "~/Images/Covers/6.jpg"
        },new BookModel
        {
          Name = "From good to great",
          Author = "Jacobson",
          Condition = "New",
          Discription = "the best book ever",
          Status = true,
          ISBN = "dfdsfd",
          Price = 10m,
          PublishYear = new DateTime(2015, 10, 10).ToShortDateString(),
          CoverImagePath = "~/Images/Covers/9.jpg"
        },new BookModel
        {
          Name = "Hobbit",
          Author = "Jacobson",
          Condition = "New",
          Discription = "the best book ever",
          Status = true,
          ISBN = "dfdsfd",
          Price = 100m,
          PublishYear = new DateTime(2015, 10, 10).ToShortDateString(),
          CoverImagePath = "~/Images/Covers/7.jpg"
        },new BookModel
        {
          Name = "New Land",
          Author = "Smith",
          Condition = "New",
          Discription = "the best book ever",
          Status = true,
          ISBN = "dfdsfd",
          Price = 25m,
          PublishYear = new DateTime(2015, 10, 10).ToShortDateString(),
          CoverImagePath = "~/Images/Covers/10.jpg"
        },new BookModel
        {
          Name = "Home Land",
          Author = "McMillon",
          Condition = "New",
          Discription = "the best book ever",
          Status = true,
          ISBN = "dfdsfd",
          Price = 100m,
          PublishYear = new DateTime(2015, 10, 10).ToShortDateString(),
          CoverImagePath = "~/Images/Covers/8.jpg"
        }
      };
      db.Book.AddOrUpdate(a => a.Name, books);
    }
  }
}

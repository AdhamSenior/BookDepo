namespace IdentitySample.Migrations
{
    using IdentitySample.BookContext;
    using IdentitySample.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IdentitySample.BookContext.BookstoreEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IdentitySample.BookContext.BookstoreEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //AddData(context);
        }

        private void AddData(BookstoreEntities db)
        {
            db.Book.Add(new BookModel
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
            });
            db.Book.Add(new BookModel
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
            });
            db.Book.Add(new BookModel
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
            });
            db.Book.Add(new BookModel
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
            });
            db.Book.Add(new BookModel
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
            });
            db.Book.Add(new BookModel
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
            });
            db.Book.Add(new BookModel
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
            });
            db.Book.Add(new BookModel
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
            });
            db.Book.Add(new BookModel
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
            });
            db.Book.Add(new BookModel
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
            });
            db.SaveChanges();
        }
    }
}

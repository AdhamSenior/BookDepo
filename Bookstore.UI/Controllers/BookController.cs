using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookstore.UI.Models;


namespace TestBookstore.Web.Controllers
{
    
    public class BookController : Controller
    {
        public ActionResult BookList(string searchString, int pageNumber = 1, int bookPerPage = 6)
        {
            List<BookModel> activeBooks = null;

            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                if (!string.IsNullOrWhiteSpace(searchString))
                {
                    ViewBag.totalCount = dbContext.Book.Where(book => book.Status == true && book.Name.Contains(searchString)).Count();
                    activeBooks = dbContext.Book.Where(book => book.Status == true && book.Name.Contains(searchString)).
                    OrderBy(b => b.Id).Skip(bookPerPage * (pageNumber - 1)).
                    Take(bookPerPage).ToList();
                }
                else
                {
                    ViewBag.totalCount = dbContext.Book.Where(book => book.Status == true).Count();
                    activeBooks = dbContext.Book.Where(book => book.Status == true).
                    OrderBy(b => b.Id).Skip(bookPerPage * (pageNumber - 1)).
                    Take(bookPerPage).ToList();
                }
            }

            return View(activeBooks);
        }
        

        public ActionResult HiddenBookList()
        {
            List<BookModel> allHiddenBook = null;
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                allHiddenBook = dbContext.Book.Where(book => book.Status == false).ToList();
            }

            return View("BookList", allHiddenBook);
        }


        public ActionResult ShowBookDetails(int id)
        {
            BookModel target = null;
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                target = dbContext.Book.SingleOrDefault(t => t.Id == id);
            }
            return View(target);
        }


        public ActionResult ShowBookByPrice(int minPrice, int MaxPrice)
        {
            List<BookModel> selectedBooks = null;
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                selectedBooks = dbContext.Book.Where(book => book.Price >= minPrice && book.Price < MaxPrice && book.Status == true).ToList();
            }
            return View("BookList", selectedBooks);
        }

        [Authorize(Roles ="Admin")]
        public ActionResult AddBook()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddBook(BookModel book)
        {
            if (ModelState.IsValid)
            {
                book.Status = true;
                book.CoverImagePath = "~/Images/Covers/DefaultBookCover.jpg";
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    if (this.Request.Files != null && this.Request.Files.Count > 0 && this.Request.Files[0].ContentLength > 0)
                    {
                        string fileName = Path.GetFileName(this.Request.Files[0].FileName);
                        string filePathOfWebsite = "~/Images/Covers/" + fileName;
                        book.CoverImagePath = filePathOfWebsite;
                        this.Request.Files[0].SaveAs(this.Server.MapPath(filePathOfWebsite));
                    }
                    dbContext.Entry(book).State = System.Data.Entity.EntityState.Added;
                    dbContext.SaveChanges();
                }
                return RedirectToAction("BookList", new { pageNumber = 1 });
            }
            return View(book);
        }


        [Authorize(Roles = "Admin")]
        public ActionResult DeleteBook(int id)
        {
            BookModel target = null;
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                target = dbContext.Book.SingleOrDefault(t => t.Id == id);
                target.Status = false;
                dbContext.Entry(target).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
            }
            return RedirectToAction("BookList", new { pageNumber = 1 });
        }


        [Authorize(Roles = "Admin")]
        public ActionResult EditBook(int id)
        {
            BookModel target = null;
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                target = dbContext.Book.SingleOrDefault(t => t.Id == id);
            }
            return View(target);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditBook(BookModel book)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    if (this.Request.Files != null && this.Request.Files.Count > 0 && this.Request.Files[0].ContentLength > 0)
                    {
                        string fileName = Path.GetFileName(this.Request.Files[0].FileName);
                        string filePathOfWebsite = "~/Images/Covers/" + fileName;
                        book.CoverImagePath = filePathOfWebsite;
                        this.Request.Files[0].SaveAs(this.Server.MapPath(filePathOfWebsite));
                    }
                    dbContext.Entry(book).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                }
                return RedirectToAction("BookList", new { pageNumber = 1 });
            }
            return View(book);
        }
    }
}
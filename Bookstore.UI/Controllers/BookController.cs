using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookstore.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PagedList;

namespace Bookstore.UI.Controllers
{

  public class BookController : Controller
  {

    private ApplicationDbContext _dbContext;

    public BookController()
    {
    }

    public BookController(ApplicationDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public ApplicationDbContext DbContext
    {
      get
      {
        return _dbContext ?? HttpContext.GetOwinContext().Get<ApplicationDbContext>();
      }
      private set
      {
        _dbContext = value;
      }
    }

    public ActionResult Index(string search, int? minPrice, int? maxPrice, int page = 1)
    {
      var size = 20;
      var query = DbContext.Books.Where(book => !book.IsDelete);

      if (!string.IsNullOrWhiteSpace(search))
      {
        query = query.Where(book => book.Name.Contains(search));
      }

      if (minPrice.HasValue && !maxPrice.HasValue)
      {
        query = query.Where(book => book.Price >= minPrice.Value);
      }

      if (!minPrice.HasValue && maxPrice.HasValue)
      {
        query = query.Where(book => book.Price <= maxPrice.Value);
      }

      if (minPrice.HasValue && maxPrice.HasValue)
      {
        query = query.Where(book => book.Price >= minPrice.Value && book.Price <= maxPrice.Value);
      }

      ViewBag.Search = search;
      ViewBag.MinPrice = minPrice;
      ViewBag.MaxPrice = maxPrice;

      return View(query.OrderByDescending(b => b.Id).ToPagedList(page, size));
    }

    [Authorize(Roles = RoleList.Buyer)]
    public ActionResult Offer(int page = 1)
    {
      var size = 20;
      var userId = User.Identity.GetUserId();
      var query = DbContext.Books.Where(book => !book.IsDelete && book.BuyerId == userId);

      return View(query.OrderByDescending(b => b.Id).ToPagedList(page, size));
    }

    public ActionResult Details(int id)
    {
      var model = DbContext.Books.Where(t => t.Id == id).Include(a => a.Seller).FirstOrDefault();

      return View(model);
    }

    [Authorize(Roles = RoleList.Seller)]
    public ActionResult Add()
    {
      return View();
    }

    [Authorize(Roles = RoleList.Seller)]
    [HttpPost]
    public ActionResult Add(Book model)
    {
      if (ModelState.IsValid)
      {
        model.SellerId = User.Identity.GetUserId();
        model.CoverImagePath = "~/Images/Covers/DefaultBookCover.jpg";

        if (Request.Files != null && Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
        {
          var fileName = Path.GetFileName(Request.Files[0].FileName);
          var filePathOfWebsite = "~/Images/Covers/" + fileName;
          model.CoverImagePath = filePathOfWebsite;
          Request.Files[0].SaveAs(Server.MapPath(filePathOfWebsite));
        }
        DbContext.Entry(model).State = EntityState.Added;
        DbContext.SaveChanges();

        return RedirectToAction("Index");
      }
      return View(model);
    }

    [Authorize(Roles = RoleList.Buyer)]
    [HttpPost]
    public ActionResult Order(int id)
    {
      var model = DbContext.Books.SingleOrDefault(t => t.Id == id);

      if (model != null && !model.Offered)
      {
        TempData["success"] = "Order Submission Successful!";

        model.Offered = true;
        model.OfferDate = DateTime.Now;
        model.BuyerId = User.Identity.GetUserId();

        DbContext.Entry(model).State = EntityState.Modified;
        DbContext.SaveChanges();
      }

      return RedirectToAction("Details", new { id });
    }

    [Authorize(Roles = RoleList.Seller)]
    public ActionResult Delete(int id)
    {

      var model = DbContext.Books.SingleOrDefault(t => t.Id == id);

      model.IsDelete = true;
      DbContext.Entry(model).State = EntityState.Modified;
      DbContext.SaveChanges();

      return RedirectToAction("Index");
    }

    [Authorize(Roles = RoleList.Seller)]
    public ActionResult Edit(int id)
    {
      var model = DbContext.Books.SingleOrDefault(t => t.Id == id);

      return View(model);
    }

    [Authorize(Roles = RoleList.Seller)]
    [HttpPost]
    public ActionResult Edit(Book model)
    {
      if (!ModelState.IsValid)
        return View(model);

      model.SellerId = User.Identity.GetUserId();

      if (Request.Files != null && Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
      {
        var fileName = Path.GetFileName(Request.Files[0].FileName);
        var filePathOfWebsite = "~/Images/Covers/" + fileName;
        model.CoverImagePath = filePathOfWebsite;
        Request.Files[0].SaveAs(Server.MapPath(filePathOfWebsite));
      }
      DbContext.Entry(model).State = EntityState.Modified;
      DbContext.SaveChanges();

      return RedirectToAction("Index");
    }

  }
}
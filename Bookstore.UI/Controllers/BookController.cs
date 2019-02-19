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
      var size = 10;
      var query = DbContext.Books.Where(a => a.BuyerId == null && a.Offered == null);

      if (!string.IsNullOrWhiteSpace(search))
      {
        query = query.Where(a => a.Name.Contains(search));
      }

      if (minPrice.HasValue && !maxPrice.HasValue)
      {
        query = query.Where(a => a.Price >= minPrice.Value);
      }

      if (!minPrice.HasValue && maxPrice.HasValue)
      {
        query = query.Where(a => a.Price <= maxPrice.Value);
      }

      if (minPrice.HasValue && maxPrice.HasValue)
      {
        query = query.Where(a => a.Price >= minPrice.Value && a.Price <= maxPrice.Value);
      }

      ViewBag.Search = search;
      ViewBag.MinPrice = minPrice;
      ViewBag.MaxPrice = maxPrice;

      return View(query.OrderByDescending(a => a.Id).ToPagedList(page, size));
    }

    [Authorize(Roles = RoleList.Buyer)]
    public ActionResult Offer(int page = 1)
    {
      var size = 10;
      var userId = User.Identity.GetUserId();
      var query = DbContext.Books.Where(a => a.BuyerId == userId).Include(a => a.Seller);

      return View(query.OrderByDescending(b => b.Id).ToPagedList(page, size));
    }

    [Authorize(Roles = RoleList.Seller)]
    public ActionResult Deal(int page = 1)
    {
      var size = 10;
      var query = DbContext.Books.Where(a => a.BuyerId != null || a.Offered != null).Include(a => a.Buyer);

      return View(query.OrderByDescending(b => b.Id).ToPagedList(page, size));
    }

    public ActionResult Details(int id)
    {
      var model = DbContext.Books.Where(t => t.Id == id).Include(a => a.Buyer).Include(a => a.Seller).FirstOrDefault();

      if (model == null)
        return HttpNotFound();

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
        model.CreatedDate = DateTime.Now;
        model.ModifiedDate = DateTime.Now;

        if (Request.Files != null && Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
        {
          var fileName = Path.GetFileName(Request.Files[0].FileName);
          var filePathOfWebsite = "~/Images/Covers/" + fileName;
          model.CoverImagePath = filePathOfWebsite;
          Request.Files[0].SaveAs(Server.MapPath(filePathOfWebsite));
        }

        DbContext.Books.Add(model);
        DbContext.SaveChanges();

        return RedirectToAction("Index");
      }
      return View(model);
    }

    [Authorize(Roles = RoleList.Buyer)]
    [HttpPost]
    public ActionResult Order(int id)
    {
      var model = DbContext.Books.FirstOrDefault(t => t.Id == id);

      if (model == null)
        return HttpNotFound();

      if (model.Offered == null && model.BuyerId == null)
      {
        model.BuyerId = User.Identity.GetUserId();

        DbContext.SaveChanges();

        TempData["message"] = "Order submission successful!";
      }

      return RedirectToAction("Details", new { id });
    }

    [Authorize(Roles = RoleList.Seller)]
    [HttpPost]
    public ActionResult Accept(int id)
    {
      var model = DbContext.Books.FirstOrDefault(t => t.Id == id);

      if (model == null)
        return HttpNotFound();

      if (model.Offered == null && model.BuyerId != null)
      {
        model.Offered = true;
        model.OfferDate = DateTime.Now;

        DbContext.SaveChanges();

        TempData["message"] = "Order accepted.";
      }

      return RedirectToAction("Details", new { id });
    }

    [Authorize(Roles = RoleList.Seller)]
    [HttpPost]
    public ActionResult Available(int id)
    {
      var model = DbContext.Books.FirstOrDefault(t => t.Id == id);

      if (model == null)
        return HttpNotFound();

      if (model.Offered == false && model.BuyerId != null)
      {
        model.Offered = null;
        model.OfferDate = null;
        model.BuyerId = null;

        DbContext.SaveChanges();

        TempData["message"] = "Book is available for buyers.";
      }

      return RedirectToAction("Details", new { id });
    }

    [Authorize(Roles = RoleList.Seller)]
    [HttpPost]
    public ActionResult Reject(int id)
    {
      var model = DbContext.Books.FirstOrDefault(t => t.Id == id);

      if (model == null)
        return HttpNotFound();

      if (model.Offered == null && model.BuyerId != null)
      {
        model.Offered = false;

        DbContext.SaveChanges();

        TempData["message"] = "Order rejected!";
      }

      return RedirectToAction("Details", new { id });
    }

    [Authorize(Roles = RoleList.Seller)]
    public ActionResult Delete(int id)
    {

      var model = DbContext.Books.FirstOrDefault(t => t.Id == id);

      if (model == null)
        return HttpNotFound();

      model.IsDeleted = true;
      DbContext.SaveChanges();

      return RedirectToAction("Index");
    }

    [Authorize(Roles = RoleList.Seller)]
    public ActionResult Edit(int id)
    {
      var model = DbContext.Books.FirstOrDefault(t => t.Id == id);

      if (model == null)
        return HttpNotFound();

      return View(model);
    }

    [Authorize(Roles = RoleList.Seller)]
    [HttpPost]
    public ActionResult Edit(Book model)
    {
      if (!ModelState.IsValid)
        return View(model);

      var ent = DbContext.Books.Find(model.Id);
      if (ent != null)
      {
        ent.SellerId = User.Identity.GetUserId();
        ent.ModifiedDate = DateTime.Now;
         
        if (Request.Files != null && Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
        {
          var fileName = Path.GetFileName(Request.Files[0].FileName);
          var filePathOfWebsite = "~/Images/Covers/" + fileName;
          ent.CoverImagePath = filePathOfWebsite;
          Request.Files[0].SaveAs(Server.MapPath(filePathOfWebsite));
        }

        DbContext.SaveChanges();
      }

      return RedirectToAction("Index");
    }

  }
}
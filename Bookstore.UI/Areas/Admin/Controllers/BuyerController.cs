using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Bookstore.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Bookstore.UI.Areas.Admin.Controllers
{
  [Authorize(Roles = RoleList.Admin)]
  public class BuyerController : Controller
  {
    private ApplicationDbContext _dbContext;

    private ApplicationUserManager _userManager;

    public BuyerController()
    {
    }

    public BuyerController(ApplicationUserManager userManager, ApplicationDbContext dbContext)
    {
      UserManager = userManager;
      DbContext = dbContext;
    }

    public ApplicationUserManager UserManager
    {
      get =>
        _userManager ?? HttpContext.GetOwinContext()
          .GetUserManager<ApplicationUserManager>();
      private set => _userManager = value;
    }

    public ApplicationDbContext DbContext
    {
      get => _dbContext ?? HttpContext.GetOwinContext().Get<ApplicationDbContext>();
      private set => _dbContext = value;
    }

    public async Task<ActionResult> Index()
    {
      var query = await UserManager.Users.ToArrayAsync();

      return View(query.Where(w => UserManager.IsInRole(w.Id, RoleList.Buyer)));
    }

    public async Task<ActionResult> Delete(string id)
    {
      if (id == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

      var user = await UserManager.FindByIdAsync(id);
      if (user == null)
        return HttpNotFound();

      user.IsDeleted = true;

      await UserManager.UpdateAsync(user);

      //var books = DbContext.Books.Where(a => a.BuyerId == id);

      //foreach (var item in books)
      //{
      //  item.IsDeleted = true;

      //  DbContext.Entry(item).State = EntityState.Modified;
      //}

      //await DbContext.SaveChangesAsync();

      return RedirectToAction("Index");
    }
     
  }
}
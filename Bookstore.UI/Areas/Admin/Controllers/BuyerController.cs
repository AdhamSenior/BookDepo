using Bookstore.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bookstore.UI.Areas.Admin.Controllers
{
  [Authorize(Roles = RoleList.Admin)]
  public class BuyerController : Controller
  {
    public BuyerController()
    {
    }

    public BuyerController(ApplicationUserManager userManager)
    {
      UserManager = userManager;
    }

    private ApplicationUserManager _userManager;
    public ApplicationUserManager UserManager
    {
      get
      {
        return _userManager ?? HttpContext.GetOwinContext()
            .GetUserManager<ApplicationUserManager>();
      }
      private set
      {
        _userManager = value;
      }
    }

    public async Task<ActionResult> Index()
    {
      var query = await UserManager.Users.ToArrayAsync();

      return View(query.Where(w => UserManager.IsInRole(w.Id, RoleList.Buyer) && !w.IsDelete));
    }


    public async Task<ActionResult> Delete(string id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var user = await UserManager.FindByIdAsync(id);
      if (user == null)
      {
        return HttpNotFound();
      }
      return View(user);
    }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(string id)
    {
      if (ModelState.IsValid)
      {
        if (id == null)
        {
          return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        var user = await UserManager.Users.Where(w => w.Id == id).Include(a => a.BuyerBooks).FirstOrDefaultAsync();
        if (user == null)
        {
          return HttpNotFound();
        }

        user.IsDelete = true;

        foreach (var item in user.BuyerBooks)
        {
          item.IsDelete = true;
        }

        await UserManager.UpdateAsync(user);

        return RedirectToAction("Index");
      }
      return View();
    }
  }
}

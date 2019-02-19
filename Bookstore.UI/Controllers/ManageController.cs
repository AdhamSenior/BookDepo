using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Bookstore.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Bookstore.UI.Controllers
{
  [Authorize]
  public class ManageController : Controller
  {
    public enum ManageMessageId
    {
      AddPhoneSuccess,
      ChangePasswordSuccess,
      SetTwoFactorSuccess,
      SetPasswordSuccess,
      RemoveLoginSuccess,
      RemovePhoneSuccess,
      Error
    }

    private ApplicationSignInManager _signInManager;
    private ApplicationUserManager _userManager;

    public ManageController()
    {
    }

    public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
    {
      UserManager = userManager;
      SignInManager = signInManager;
    }

    public ApplicationSignInManager SignInManager
    {
      get => _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
      private set => _signInManager = value;
    }

    public ApplicationUserManager UserManager
    {
      get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
      private set => _userManager = value;
    }

    //
    // GET: /Manage/Index
    public ActionResult Index(ManageMessageId? message)
    {
      ViewBag.StatusMessage =
        message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
        : message == ManageMessageId.Error ? "An error has occurred."
        : "";
      return View();
    }

    //
    // GET: /Manage/ChangePassword
    public ActionResult ChangePassword()
    {
      return View();
    }

    //
    // POST: /Manage/ChangePassword
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
    {
      if (!ModelState.IsValid) return View(model);
      var result =
        await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
      if (result.Succeeded)
      {
        var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
        if (user != null) await SignInManager.SignInAsync(user, false, false);
        return RedirectToAction("Index", new {Message = ManageMessageId.ChangePasswordSuccess});
      }

      AddErrors(result);
      return View(model);
    }


    protected override void Dispose(bool disposing)
    {
      if (disposing && _userManager != null)
      {
        _userManager.Dispose();
        _userManager = null;
      }

      base.Dispose(disposing);
    }


    private void AddErrors(IdentityResult result)
    {
      foreach (var error in result.Errors) ModelState.AddModelError("", error);
    }
  }
}
using System.DirectoryServices.AccountManagement;
using System.Web.Mvc;

namespace KRD.RepoBrowser.Web.Controllers
{
  public class HomeController : Controller
  {
    /*
    public string UserFullName()
    {
      using (var context = new PrincipalContext(ContextType.Domain))
      {
        var principal = UserPrincipal.FindByIdentity(context, User.Identity.Name);

        return principal != null ? string.Format("{0} {1}", principal.GivenName, principal.Surname) : string.Empty;
      }
    }
      */
    
    [ChildActionOnly]
    public string UserName()
    {
      using (var context = new PrincipalContext(ContextType.Domain))
      {
        var principal = UserPrincipal.FindByIdentity(context, User.Identity.Name);

        return principal != null
          ? string.Format("{0} {1}", principal.GivenName, principal.Surname)
          : string.Empty;
      }
    }

    
    public ActionResult Index()
    {
      ViewBag.Login = "Użytkownik:  " + UserName();
      return View();
    }
  }
}



using System.DirectoryServices.AccountManagement;
using System.Web.Mvc;

namespace KRD.RepoBrowser.Web.Controllers
{
  public class HomeController : Controller
  {
    
    public string UserFullName()
    {
      using (var context = new PrincipalContext(ContextType.Domain))
      {

        var principal = UserPrincipal.FindByIdentity(context, User.Identity.Name);
        var fullName = "";

        if (principal != null)
        {
          return fullName = string.Format("{0} {1}", principal.GivenName, principal.Surname);
          //return ViewBag.Login = string.Format("{0} {1}", principal.GivenName, principal.Surname);
        }
        else
        {
          return fullName;
        }
        
      }
    }
    
    

    public ActionResult Index()
    {
      ViewBag.Login = UserFullName();
      //UserFullName();
      
      return View();
    }
  }
}
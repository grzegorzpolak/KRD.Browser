
using System.DirectoryServices.AccountManagement;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Ajax.Utilities;
using ServiceStack.ServiceHost;

namespace KRD.RepoBrowser.Web.Controllers
{
  public class HomeController : Controller
  {
    /*
    public var UserFullName()
    {
      using (var context = new PrincipalContext(ContextType.Domain))
      {

        var principal = UserPrincipal.FindByIdentity(context, User.Identity.Name);
        

        if (principal != null)
        {

          //return fullName = string.Format("{0} {1}", principal.GivenName, principal.Surname);


        }

      }
    }
    */

    var user = Membership.GetUser(); //Gets currently logged in user
    var roles = Roles.GetRolesForUser(user.UserName); //Gets array of role names assigned to user

    public ActionResult Index()
    {
      //ViewBag.Login = "fdfdfdfsdfsdfsdfsdffs";
      //ViewBag.Login = UserFullName();
      ViewBag.Login = User.Identity.Name;
      
      return View();
    }
  }
}
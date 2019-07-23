using System.Web.Mvc;

namespace Users.Web.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
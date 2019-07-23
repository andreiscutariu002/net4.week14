using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using Users.BusinessLogic;
using Users.Data;
using Users.Web.Models;

namespace Users.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _repo;

        public UserController()
        {
            _repo = new UserRepository(ConnectionManager.GetConnection());
        }

        [HttpGet]
        public ActionResult Index()
        {
            var allUsers = _repo.GetAll();
            var userListModels = allUsers.Select(x => new UserListViewModel
            {
                Id = x.Id,
                Email = x.Email,
                UserName = x.Username
            }).ToList();

            return View(userListModels);
        }
    }
}
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
            var connection = new SqlConnection
            {
                ConnectionString = "Data Source=.; Initial Catalog=week14;Integrated Security=True;"
            };

            connection.Open();

            _repo = new UserRepository(connection);
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
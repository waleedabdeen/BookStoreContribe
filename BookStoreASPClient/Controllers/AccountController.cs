using System.Threading.Tasks;
using System.Web.Mvc;
using BookStoreASPClient.Models;
using BookStoreASPClient.Modules.ApiModule;

namespace BookStoreASPClient.Controllers
{
    public class AccountController : Controller
    {
        BookstoreService bookstoreService;

        public AccountController()
        {
            bookstoreService = new BookstoreService();
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // Post: Account/Login
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await bookstoreService.GetToken(model.Email, model.Password);
                if (result.StartsWith("ERROR"))
                {
                    ModelState.AddModelError("", result);
                    return View(model);
                }
                AccessToken.Set(result);
                return RedirectToAction("Index", "Book");
            }
            return View(model);
        }

        // GET: Account/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterAccountViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await bookstoreService.RegiserNewAccount(model.Email, model.Password);
                    if (string.IsNullOrEmpty(result))
                    {
                        ModelState.AddModelError("", "Wrong username or password!");
                        return View(model);
                    }
                    else if (result.StartsWith("ERROR"))
                    {
                        ModelState.AddModelError("", result);
                        return View(model);
                    }
                    else
                    {
                        ViewBag.Message = result;
                        ViewBag.IsError = false;
                        return RedirectToAction("Login");
                    }
                }
                
                // TODO: Add insert logic here
                return View(model);

            }
            catch
            {
                return View(model);
            }
        }
    }
}

using System.Web.Mvc;

namespace BookStoreAPI.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            ViewBag.Title = "Home Page";
            
            return "Bookstore server is Online!";
        }

    }
}

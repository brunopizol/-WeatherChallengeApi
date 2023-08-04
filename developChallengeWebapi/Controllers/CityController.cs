using Microsoft.AspNetCore.Mvc;

namespace developChallenge.Web.Api.Controllers
{
    public class CityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

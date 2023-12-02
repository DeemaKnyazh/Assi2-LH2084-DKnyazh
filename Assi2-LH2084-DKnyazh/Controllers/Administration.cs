using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assi2_LH2084_DKnyazh.Controllers
{
    [Authorize(Roles = "Administrator")]

    public class Administration : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

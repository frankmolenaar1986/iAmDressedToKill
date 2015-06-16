using System.Web.Mvc;

namespace iAmDressedToKill.Controllers
{
    public class IAmServiceController : Controller
    {
        public ActionResult Verified()
        {
			return View();
        }

		public ActionResult Failure()
		{
			return View();
		}
    }
}
using ParkFacilAdm.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ParkFacilAdm.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ParkFacilAdmEntities db = new ParkFacilAdmEntities();
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult LoadMenu()
        {
            var menu = from a in db.MenuTemp
                               select a;
            return View(menu.ToList());
        }


    }
}
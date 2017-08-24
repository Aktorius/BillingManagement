using System.Web.Mvc;
using BillingManagement.Web.Models;

namespace BillingManagement.Web.Controllers
{
    public class SitesController : Controller
    {
        public ActionResult Create()
        {
            var model = new Site();
            return View(model);
        }
    }
}
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

        [HttpPost]
        public ActionResult Create(Site model)
        {
            return View(model);
        }

        public ActionResult Edit(int companyId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Site model)
        {

            return View(model);
        }

        public ActionResult Delete(int siteId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Site model)
        {
            return View(model);
        }
    }
}
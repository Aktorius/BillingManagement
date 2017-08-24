using System.Web.Mvc;
using BillingManagement.Web.Models;

namespace BillingManagement.Web.Controllers
{
    public class BillingsController : Controller
    {
        public ActionResult Create()
        {
            var model = new Billing();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Billing model)
        {
            return View(model);
        }

        public ActionResult Edit(int billingId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Billing model)
        {

            return View(model);
        }

        public ActionResult Delete(int billingId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Billing model)
        {
            return View(model);
        }
    }
}
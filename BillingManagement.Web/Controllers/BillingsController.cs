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
    }
}
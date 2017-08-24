using System.Web.Mvc;
using BillingManagement.Web.Models;

namespace BillingManagement.Web.Controllers
{
    public class CompaniesController : Controller
    {
        public ActionResult Create()
        {
            var model = new Company();
            return View(model);
        }
    }
}
using System.Web.Mvc;
using BillingManagement.Web.Services;

namespace BillingManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICompanyService _companyService;

        public HomeController()
            : this(new CompanyService()) { }

        public HomeController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public ActionResult Index()
        {
            var companies = _companyService.GetAllCompanies();
            return View(companies);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
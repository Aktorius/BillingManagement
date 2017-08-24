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

            foreach (var company in companies)
            {
                company.SitesList = _companyService.GetSitesForCompany(company.Id);

                foreach (var site in company.SitesList)
                {
                    site.Billings = _companyService.GetBillingsForSite(site.Id);
                }
            }

            return View(companies);
        }
    }
}
using System;
using System.Web.Mvc;
using BillingManagement.Web.Models;
using BillingManagement.Web.Services;

namespace BillingManagement.Web.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompaniesController() : this(new CompanyService())
        {
        }

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public ActionResult Create()
        {
            var model = new Company();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Company model)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(model.Name))
                {
                    ModelState.AddModelError("Company name cannot be empty", "Company name cannot be empty");
                    return View(model);
                }
            }

            return View(model);
        }
    }
}
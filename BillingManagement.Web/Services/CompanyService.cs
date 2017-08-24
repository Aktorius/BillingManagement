using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using BillingManagement.Business.Repositories;
using BillingManagement.Web.Models;

namespace BillingManagement.Web.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ISiteRepository _siteRepository;

        public CompanyService() 
            : this(new CompanyRepository(),
                  new SiteRepository()) { }

        public CompanyService(ICompanyRepository companyRepository,
                              ISiteRepository siteRepository)
        {
            _companyRepository = companyRepository;
            _siteRepository = siteRepository;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            var companies = _companyRepository.GetAllCompanies().ToList();

            if(companies.Count == 0)
                return new List<Company>();

            return companies.Select(company => new Company()
            {
                Id = company.CompanyId,
                Name = company.Name
            }).ToList();
        }

        public IEnumerable<Site> GetSitesForCompany(int companyId)
        {
            throw new System.NotImplementedException();
        }
    }
}
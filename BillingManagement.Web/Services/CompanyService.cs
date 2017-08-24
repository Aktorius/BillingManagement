using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using BillingManagement.Business.Repositories;
using BillingManagement.Web.Models;

namespace BillingManagement.Web.Services
{
    public class CompanyService : ICompanyService
    {
        private ICompanyRepository _companyRepository;

        public CompanyService() 
            : this(new CompanyRepository()) { }

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
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
    }
}
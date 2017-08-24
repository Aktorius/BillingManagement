using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }
    }
}
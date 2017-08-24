using System.Collections.Generic;
using BillingManagement.Web.Models;

namespace BillingManagement.Web.Services
{
    public interface ICompanyService
    {
        Models.Company GetCompany(int companyId); 
        IEnumerable<Company> GetAllCompanies();
        IEnumerable<Site> GetSitesForCompany(int companyId);
        IEnumerable<Billing> GetBillingsForSite(int siteId);
        bool CreateCompany (string companyName);
        bool EditCompany(Company company);
    }
}

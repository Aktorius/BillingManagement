using System.Collections.Generic;
using BillingManagement.Web.Models;

namespace BillingManagement.Web.Services
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetAllCompanies();
        IEnumerable<Site> GetSitesForCompany(int companyId);
        IEnumerable<Billing> GetBillingsForSite(int siteId);
        bool CreateCompany (string companyName);
        bool EditCompany(int companyId);
        bool DeleteCompany(int companyId);
    }
}

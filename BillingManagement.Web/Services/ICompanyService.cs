using System.Collections.Generic;
using BillingManagement.Web.Models;

namespace BillingManagement.Web.Services
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetAllCompanies();
        IEnumerable<Site> GetSitesForCompany(int companyId);
    }
}

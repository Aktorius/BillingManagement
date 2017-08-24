using System.Collections.Generic;
using BillingManagement.Database.Models;

namespace BillingManagement.Business.Repositories
{
    public interface ISiteRepository : IRepository<Site>
    {

        IEnumerable<Site> GetSitesForCompany(int companyId);
    }
}

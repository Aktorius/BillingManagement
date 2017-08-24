using System.Collections.Generic;
using BillingManagement.Database.Models;

namespace BillingManagement.Business.Repositories
{
    public interface IBillingRepository : IRepository<Billing>
    {
        IEnumerable<Billing> GetBillingsForSite(int siteId);
    }
}

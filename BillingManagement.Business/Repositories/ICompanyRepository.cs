using System.Collections.Generic;
using BillingManagement.Database.Models;

namespace BillingManagement.Business.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        IEnumerable<Company> GetAllCompanies();
    }
}

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BillingManagement.Database.DataAccess;
using BillingManagement.Database.Models;

namespace BillingManagement.Business.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DatabaseContext _ctx;

        public CompanyRepository()
        {
            _ctx = new DatabaseContext();
            _ctx.Database.Connection.Open();
        }

        public Company FindById(int id)
        {
            return _ctx.Companies.FirstOrDefault(x => x.CompanyId == id);

        }

        public bool Add(Company entity)
        {
            _ctx.Companies.Add(entity);
            return _ctx.SaveChanges() > 0;

        }

        public bool Update(Company entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            return _ctx.SaveChanges() > 0;

        }

        public bool Delete(Company entity)
        {
            _ctx.Companies.Remove(entity);
            return _ctx.SaveChanges() > 0;

        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _ctx.Companies.ToList();
        }

        public bool CompanyExists(string companyName)
        {
            return _ctx.Companies.FirstOrDefault(x => x.Name == companyName) != null;
        }
    }
}

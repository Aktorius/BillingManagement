using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BillingManagement.Database.DataAccess;
using BillingManagement.Database.Models;

namespace BillingManagement.Business.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public Company FindById(int id)
        {
            Company company;
            using (var ctx = new DatabaseContext())
            {
                ctx.Database.Connection.Open();
                company = ctx.Companies.FirstOrDefault(x => x.CompanyId == id);
            }
            return company;
        }

        public bool Add(Company entity)
        {
            int res;
            using (var ctx = new DatabaseContext())
            {
                ctx.Database.Connection.Open();
                ctx.Companies.Add(entity);
                res = ctx.SaveChanges();
            }
            return res > 0;
        }

        public bool Update(Company entity)
        {
            int res;
            using (var ctx = new DatabaseContext())
            {
                ctx.Database.Connection.Open();
                ctx.Entry(entity).State = EntityState.Modified;
                res = ctx.SaveChanges();
            }
            return res > 0;
        }

        public bool Delete(Company entity)
        {
            int res;
            using (var ctx = new DatabaseContext())
            {
                ctx.Database.Connection.Open();
                ctx.Companies.Remove(entity);
                res = ctx.SaveChanges();
            }
            return res > 0;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            var companies = new List<Company>();
            using (var ctx = new DatabaseContext())
            {
                ctx.Database.Connection.Open();
                companies = ctx.Companies.ToList();
            }
            return companies;
        }
    }
}

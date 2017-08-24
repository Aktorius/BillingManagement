using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BillingManagement.Database.DataAccess;
using BillingManagement.Database.Models;

namespace BillingManagement.Business.Repositories
{
    public class SiteRepository : ISiteRepository
    {
        private readonly DatabaseContext _ctx;

        public SiteRepository()
        {
            _ctx = new DatabaseContext();
            _ctx.Database.Connection.Open();
        }

        public Site FindById(int id)
        {
            return _ctx.Sites.FirstOrDefault(x => x.SiteId == id);

        }

        public bool Add(Site entity)
        {

            _ctx.Sites.Add(entity);
            return _ctx.SaveChanges() > 0;

        }

        public bool Update(Site entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            return _ctx.SaveChanges() > 0;

        }

        public bool Delete(Site entity)
        {
            _ctx.Sites.Remove(entity);
            return _ctx.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public IEnumerable<Site> GetSitesForCompany(int companyId)
        {
            return _ctx.Sites.Where(x => x.CompanyKey == companyId);

        }
    }
}

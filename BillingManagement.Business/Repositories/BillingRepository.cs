using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BillingManagement.Database.DataAccess;
using BillingManagement.Database.Models;

namespace BillingManagement.Business.Repositories
{
    public class BillingRepository : IBillingRepository
    {
        private readonly DatabaseContext _ctx;

        public BillingRepository()
        {
            _ctx = new DatabaseContext();
            _ctx.Database.Connection.Open();
        }

        public Billing FindById(int id)
        {
            return _ctx.Billings.FirstOrDefault(x => x.BillingId == id);
        }

        public bool Add(Billing entity)
        {
            _ctx.Billings.Add(entity);
            return _ctx.SaveChanges() > 0;

        }

        public bool Update(Billing entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            return _ctx.SaveChanges() > 0;

        }

        public bool Delete(Billing entity)
        {
            _ctx.Billings.Remove(entity);
            return _ctx.SaveChanges() > 0;

        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public IEnumerable<Billing> GetBillingsForSite(int siteId)
        {
            return _ctx.Billings.Where(x => x.SiteKey == siteId);

        }
    }
}

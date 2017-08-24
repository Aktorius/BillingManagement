using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BillingManagement.Database.DataAccess;
using BillingManagement.Database.Models;

namespace BillingManagement.Business.Repositories
{
    public class BillingRepository : IBillingRepository
    {
        public Billing FindById(int id)
        {
            Billing billing;
            using (var ctx = new DatabaseContext())
            {
                ctx.Database.Connection.Open();
                billing = ctx.Billings.FirstOrDefault(x => x.BillingId == id);
            }
            return billing;
        }

        public bool Add(Billing entity)
        {
            int res;
            using (var ctx = new DatabaseContext())
            {
                ctx.Database.Connection.Open();
                ctx.Billings.Add(entity);
                res = ctx.SaveChanges();
            }
            return res > 0;
        }

        public bool Update(Billing entity)
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

        public bool Delete(Billing entity)
        {
            int res;
            using (var ctx = new DatabaseContext())
            {
                ctx.Database.Connection.Open();
                ctx.Billings.Remove(entity);
                res = ctx.SaveChanges();
            }
            return res > 0;
        }

        public IEnumerable<Billing> GetBillingsForSite(int siteId)
        {
            using (var ctx = new DatabaseContext())
            {
                ctx.Database.Connection.Open();
                return ctx.Billings.Where(x => x.SiteKey == siteId);
            }
        }
    }
}

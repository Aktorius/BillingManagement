using System.Data.Entity;
using System.Linq;
using BillingManagement.Database.DataAccess;
using BillingManagement.Database.Models;

namespace BillingManagement.Business.Repositories
{
    public class SiteRepository : ISiteRepository
    {
        public Site FindById(int id)
        {
            Site site;
            using (var ctx = new DatabaseContext())
            {
                ctx.Database.Connection.Open();
                site = ctx.Sites.FirstOrDefault(x => x.SiteId == id);
            }
            return site;
        }

        public bool Add(Site entity)
        {
            int res;
            using (var ctx = new DatabaseContext())
            {
                ctx.Database.Connection.Open();
                ctx.Sites.Add(entity);
                res = ctx.SaveChanges();
            }
            return res > 0;
        }

        public bool Update(Site entity)
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

        public bool Delete(Site entity)
        {
            int res;
            using (var ctx = new DatabaseContext())
            {
                ctx.Database.Connection.Open();
                ctx.Sites.Remove(entity);
                res = ctx.SaveChanges();
            }
            return res > 0;
        }
    }
}

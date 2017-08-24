using BillingManagement.Web.Models;

namespace BillingManagement.Web.Services
{
    public interface ISiteService
    {
        bool CreateSite(Site site);
        bool EditSite(int siteId);
        bool DeleteSite(int siteId);
    }
}

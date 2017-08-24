using BillingManagement.Web.Models;

namespace BillingManagement.Web.Services
{
    public interface IBillingService
    {
        bool CreateBilling(Billing billing);
        bool EditBilling(int billingId);
        bool DeleteBilling(int billingId);
    }
}

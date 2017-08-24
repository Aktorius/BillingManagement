using System;

namespace BillingManagement.Web.Models
{
    public class Billing
    {
        public int Id { get; set; }

        public string Notes { get; set; }


        public string BillingPhone { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public int SiteId { get; set; }
    }
}
using System.Collections.Generic;

namespace BillingManagement.Web.Models
{
    public class Site
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public bool MainSite { get; set; }

        public int CompanyId { get; set; }
    }
}
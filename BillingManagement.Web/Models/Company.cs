using System.Collections.Generic;

namespace BillingManagement.Web.Models
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Site> SitesList { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BillingManagement.Database.Models;

namespace BillingManagement.Database.Models
{
    public class Site
    {
        [Key]
        public int SiteId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public bool MainSite { get; set; }

        public int CompanyKey { get; set; }

        [ForeignKey("CompanyKey")]
        public virtual Company Company { get; set; }

        public virtual ICollection<Billing> Billings { get; set; }
    }
}

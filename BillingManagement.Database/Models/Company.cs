using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BillingManagement.Database.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public virtual ICollection<Site> Sites { get; set; }
    }
}
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingManagement.Database.Models
{
    public class Billing
    {
        [Key]
        public int BillingId { get; set; }
        public string Notes { get; set; }

        [Required]
        public string BillingPhone { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime DateFrom { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime DateTo { get; set; }

        public int SiteKey { get; set; }

        [ForeignKey("SiteKey")]
        public virtual Site Site { get; set; }
    }
}

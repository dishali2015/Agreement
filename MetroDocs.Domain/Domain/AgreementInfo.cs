using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroDocs.Domain
{
    [Table("AgreementInfo")]
    public class AgreementInfo
    {
        public AgreementInfo()
        {
            AgreementDocument = new List<AgreementDocument>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int AgreementInfoId { get; set; }

        [Required]
        [ForeignKey("Agreement")]
        public int AgreementId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal RentAmountPerMonth { get; set; }
        [Required]
        public decimal SecurityDeposit { get; set; }

        [Required]
        public DateTime RenewalDate { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string RenewalUserId { get; set; }

        public Agreement Agreement { get; set; }
       
        public virtual ICollection<AgreementDocument> AgreementDocument { get; set; }

    }
}

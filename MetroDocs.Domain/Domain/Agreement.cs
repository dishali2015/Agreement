using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroDocs.Domain
{  
    [Table("Agreement")]
    public class Agreement
    {
        public Agreement()
        {
            LandLordContact = new ContactInfo();
            TenantContact = new ContactInfo();
            AgreementInfo = new List<AgreementInfo>();            
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int AgreementId { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(250)]
        public string PremisesAddress1 { set; get; }
        [Column(TypeName = "VARCHAR")]
        [MaxLength(250)]
        public string PremisesAddress2 { set; get; }
        [Column(TypeName = "VARCHAR")]
        [MaxLength(250)]
        public string PremisesAddress3 { set; get; }
        [Column(TypeName = "VARCHAR")]
        [MaxLength(250)]
        public string PremisesCity { set; get; }
        [Column(TypeName = "VARCHAR")]
        [MaxLength(10)]
        public string PremisesPincode { set; get; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(1000)]
        public string PremisesDescription { set; get; }
                
        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(250)]
        public string PaymentMethod { get; set; }
       
        [ForeignKey("LandLordContact")]
        public int? LandLordContactId { get; set; }
        public ContactInfo LandLordContact { get; set; }

        [ForeignKey("TenantContact")]
        public int? TenantContactId { get; set; }
        public ContactInfo TenantContact { get; set; }

        [Required]
        public DateTime EntryDate { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string UserId { get; set; }

        public virtual ICollection<AgreementInfo> AgreementInfo { get; set; }
        
    }

   

}

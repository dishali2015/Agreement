using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroDocs.Domain
{
    [Table("ContactInfo")]
    public class ContactInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ContactId { set; get; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(250)]
        public string ContactName { set; get; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(250)]
        public string Address1 { set; get; }
        [Column(TypeName = "VARCHAR")]
        [MaxLength(250)]
        public string Address2 { set; get; }
        [Column(TypeName = "VARCHAR")]
        [MaxLength(250)]
        public string Address3 { set; get; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(250)]
        public string City { set; get; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(10)]
        public string Pincode { set; get; }
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string EMail { set; get; }

        [MaxLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string PhoneNumber { set; get; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string MobileNumber { set; get; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string AadharNumber { set; get; }

        [Required]
        [MaxLength(15)]
        [Column(TypeName = "VARCHAR")]
        public string PAN { set; get; }

        [InverseProperty("LandLordContact")]
        public ICollection<Agreement> AgreementLandlord { get; set; }
        [InverseProperty("TenantContact")]
        public ICollection<Agreement> AgreementTenant { get; set; }
    }
}

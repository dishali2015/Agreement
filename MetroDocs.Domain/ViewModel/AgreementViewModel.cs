using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace MetroDocs.Domain.ViewModel
{
    public class AgreementDataInputViewModel
    {
        public AgreementDataInputViewModel()
        {          
            LandLordContact = new ContactInfoViewModel();
            TenantContact = new ContactInfoViewModel();
            AgreementViewModel = new AgreementViewModel();
            AgreementInfo = new AgreementInfoViewModel();
      
        }
        public AgreementViewModel AgreementViewModel { get; set; }
        public ContactInfoViewModel LandLordContact { get; set; }
        public ContactInfoViewModel TenantContact { get; set; }
        public AgreementInfoViewModel AgreementInfo { get; set; }
      
    }
    public class AgreementViewModel
    {
        
        public int? AgreementId { get; set; }

        [Display(Name = "Address1")]
        [Required]
        [StringLength(250)]
        public string PremisesAddress1 { set; get; }

        [Display(Name = "Address2")]
        [Required]
        [StringLength(250)]
        public string PremisesAddress2 { set; get; }

        [Display(Name = "Address3")]
       // [Required]
        [StringLength(250)]
        public string PremisesAddress3 { set; get; }

        [Display(Name = "City")]
        [Required]
        [StringLength(250)]
        public string PremisesCity { set; get; }

        [Display(Name = "Pincode")]
        [Required]
        [StringLength(6)]
        public string PremisesPincode { set; get; }

        [Display(Name = "Detail of the Premises")]
        [Required]     
        [StringLength(1000)]
        public string PremisesDescription { set; get; }
    }

    public class ContactInfoViewModel
    {
        public int? ContactId { set; get; }
        [Required]
        [Display(Name = "Contact Name")]
        [StringLength(250)]
        public string ContactName { set; get; }

        [Display(Name = "Address1")]
        [Required]
        [StringLength(250)]
        public string Address1 { set; get; }

        [Display(Name = "Address2")]
        [Required]
        [StringLength(250)]
        public string Address2 { set; get; }

        [Display(Name = "Address3")]
       // [Required]
        [StringLength(250)]
        public string Address3 { set; get; }

        [Display(Name = "City")]
        [Required]
        [StringLength(250)]
        public string City { set; get; }

        [Display(Name = "PIN Code")]
        [Required]
        [StringLength(6)]
        public string Pincode { set; get; }

        [Display(Name = "E-Mail")]
        [StringLength(100)]
        public string EMail { set; get; }

        [Display(Name = "Phone Number")]
        [StringLength(50)]
        public string PhoneNumber { set; get; }

        [Display(Name = "Mobile Number")]
        [Required]
        [StringLength(50)]
        public string MobileNumber { set; get; }

        [Display(Name = "Aadhar Number")]
        [Required]
        [StringLength(12)]
        [RegularExpression(@"^([0-9]){12}$", ErrorMessage = "Invalid Aadhar number")]
        public string AadharNumber { set; get; }

        [Display(Name = "PAN")]
        [Required]
        [StringLength(10)]
        [RegularExpression(@"^[A-Za-z]{5}[0-9]{4}[A-Za-z]{1}$", ErrorMessage = "Invalid PAN")]        
        public string PAN { set; get; }
    }

    public class AgreementInfoViewModel
    {
        public int? AgreementInfoId { get; set; }

        [Display(Name = "Start Date of Agreement")]
        [Required]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date of Agreement")]
        [Required]
        public DateTime EndDate { get; set; }

        [Display(Name = "Rent Amount per Month")]
        [Required]
        [Range(1, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal RentAmountPerMonth { get; set; }

        [Display(Name = "Security Deposit")]
        [Required]
        [Range(1, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal SecurityDeposit { set; get; }

        [Display(Name = "Payment Method")]
        [Required]
        [MaxLength(250)]
        public string PaymentMethod { get; set; }
       
        [Required]
        [Display(Name = "Upload Document")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase[] UploadDocuments { get; set; }
    }
   
}

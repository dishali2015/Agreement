using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace MetroDocs.Domain.ViewModel
{
    public class AgreementRenewal
    {        
        [Required]      
        public int AgreementInfoId { get; set; }
        [Required]
        public int AgreementId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Rent Amount Per Month")]
        public decimal? RentAmountPerMonth { get; set; }
        [Required]
        [Display(Name = "Security Deposit")]
        public decimal? SecurityDeposit { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/mmm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RenewalStartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/mmm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? RenewalEndDate { get; set; }
        [Required]
        [Display(Name = "Rent Amount Per Month")]
        public decimal? RenewalRentAmountPerMonth { get; set; }
        [Required]
        [Display(Name = "Security Deposit")]
        public decimal? RenewalSecurityDeposit { get; set; }

        [Required]
        [Display(Name = "Documents")]
        public HttpPostedFileBase UploadDocuments { set; get; }
    }
}

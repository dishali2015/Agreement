using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MetroDocs.Models.Customer;
using MetroDocs.Models.Audit;

namespace MetroDocs.Models
{   
    [Table("IdentityProofMaster")]
    public class IdentityProof
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 IdentityProofId { set; get; }
        [Display(Name = "Identity Proof")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(500)]
        public string IdentityProofName { set; get; }
    }
  
   
    [Table("DiscountStructureMaster")]
    public class DiscountStructure
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 DiscountStructureId { set; get; }
        [Display(Name = "Discount Structure")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(500)]
        public string DiscountStructureName { set; get; }
    }
  

    [Table("SalesExecutiveMaster")]
    public class SalesExecutive
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 SalesExecutiveId { set; get; }
        [Display(Name = "Sales Executive Name")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(500)]
        public string SalesExecutiveName { set; get; }
    }

    [Table("DepositMethodMaster")]
    public class DepositMethod
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 DepositMethodId { set; get; }
        [Display(Name = "Deposit Method Name")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(500)]
        public string DepositMethodName { set; get; }       
   
    }

    [Table("StateMaster")]
    public class StateMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 StateId { set; get; }
        [Display(Name = "State Name")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(500)]
        public string StateName { set; get; }

        [Display(Name = "State Code")]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(10)]
        public string StateCode { set; get; }
    }

    [Table("RejectReasonMaster")]
    public class RejectReasonMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 ReasonId { set; get; }
        [Column(TypeName = "VARCHAR")]
        [Display(Name = "Reason Description")]
        [MaxLength(1000)]
        public string ReasonDescription { set; get; }        
    }

    [Table("CheckListMaster")]
    public class CheckListMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 CheckListId { set; get; }
        [Display(Name = "Check List Description")]
        [MaxLength(1500)]
        [Column(TypeName = "VARCHAR")]
        [Required]
        public string CheckListDescription { set; get; }
    }

    [Table("SegmentMaster")]
    public class SegmentMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 SegmentId { set; get; }
        [Display(Name = "Segment Description")]
        [MaxLength(500)]
        [Required]
        [Column(TypeName = "VARCHAR")]
        public string SegmentDescription { set; get; }
    }
    public class DepartmentSummary
    {        
        public string Rolename { get; set; }
        public Int32 Processed { get; set; }
        public Int32 NotProcessed { get; set; }
    }
    public class SegmentSummary
    {        
        public string SegmentDescription { get; set; }
        public Int32 Processed { get; set; }
        public Int32 NotProcessed { get; set; }
    }

    public class Dashboard
    {       
        public Int32 CustomerId { get; set; }
        public string Name { get; set; }
        public Int32 CityId { get; set; }
        public Int32 ClientCode { get; set; }
        public string SegmentDescription { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string CityName { get; set; }
        public string Location { get; set; }
        public string Taluk { get; set; }
        public Int32 Admin { get; set; }
        public Int32 CreditControl { get; set; }
        public Int32 Isolve { get; set; }
        public Int32 IT { get; set; }
        public Int32 Marketing { get; set; }
        public Int32 Material { get; set; }
        public Int32 Sales { get; set; }
        public Int32 SBUHead { get; set; }

        public Int32 AdminTAT { get; set; }
        public Int32 CreditControlTAT { get; set; }
        public Int32 IsolveTAT { get; set; }
        public Int32 ITTAT { get; set; }
        public Int32 MarketingTAT { get; set; }
        public Int32 MaterialTAT { get; set; }
        public Int32 SalesTAT { get; set; }
        public Int32 SBUHeadTAT { get; set; }

    }
    [Table("CustomerDocumetUpload")]
    public class CustomerDocumetUpload
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 UploadId { set; get; }

        [Required]
        public Int32 CustomerId { set; get; }

        [ForeignKey("CustomerId")]
        public virtual CustomerRegister CustomerRegister { get; set; }

        [Required]
        public Int32 DocumentTypeId { set; get; }
       
        [MaxLength(500)]
        [Required]
        [Column(TypeName = "VARCHAR")]
        public string FileName { set; get; }

        [MaxLength(25)]
        [Required]
        [Column(TypeName = "VARCHAR")]
        public string FileType { set; get; }
       
        [NotMapped]
        public HttpPostedFileBase PostedDocument { set; get; }
    }

    [Table("AuditDocumetUpload")]
    public class AuditDocumetUpload
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 UploadId { set; get; }

        [Required]
        public Int32 AuditId { set; get; }

        [ForeignKey("AuditId")]
        public virtual AuditDoc AuditDoc { get; set; }

        [Required]
        public Int32 DocumentTypeId { set; get; }

        [MaxLength(500)]
        [Required]
        [Column(TypeName = "VARCHAR")]
        public string FileName { set; get; }

        [MaxLength(25)]
        [Required]
        [Column(TypeName = "VARCHAR")]
        public string FileType { set; get; }

        [NotMapped]
        public HttpPostedFileBase PostedDocument { set; get; }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace MetroDocs.Domain
{
    [Table("AgreementDocument")]
    public class AgreementDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int DocumentId { get; set; }   
       
        [ForeignKey("AgreementInfo")]
        public int AgreementInfoId { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(500)]
        public string DocumentName { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50)]
        public string DocumentType { get; set; } //pdf/JPG/PNG

        [NotMapped]
        public HttpPostedFileBase PostedDocument { set; get; }
      
       public AgreementInfo AgreementInfo { get; set; }

    }
}

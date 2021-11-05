using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroDocs.Domain
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
}

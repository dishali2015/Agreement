using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetroDocs.Domain
{
    [Table("SMTPMailConfig")]
    public class SMTPMailConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 SMTPConfigID { set; get; }

        [Required]
        [MaxLength(75)]
        [Column(TypeName = "VARCHAR")]
        public string Host { set; get; }

        [Required]
        [Column(TypeName = "int")]
        public Int32 Port { set; get; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string FromId { set; get; }


        [MaxLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string DisplayName { set; get; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string UserName { set; get; }

        [Required]
        [MaxLength(25)]
        [Column(TypeName = "VARCHAR")]
        public string Password { set; get; }
    }
}

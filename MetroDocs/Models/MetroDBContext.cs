using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MetroDocs.Domain;

namespace MetroDocs.Models
{
    public class MetroDBContext: DbContext
    {
        public MetroDBContext() : base("name=MetroDB")
        {
            Database.SetInitializer(new MetroDBInitializer());
        }

      
        public DbSet<IdentityProof> IdentityProofs { set; get; }
        //public DbSet<AddressProof> AddressProofs { set; get; }
       
       
        public DbSet<DiscountStructure> DiscountStructures { set; get; }       
        
        public DbSet<CustomerRegister> CustomerRegister { set; get; }

        public DbSet<DepositMethod> DepositMethod { set; get; }
        public DbSet<StateMaster> StateMaster { set; get; }
        public DbSet<SalesExecutive> SalesExecutive { set; get; }

        // Audit
        public DbSet<AuditDoc> AuditDoc { set; get; }
        public DbSet<AuditCheckList> AuditCheckList { set; get; }
        public DbSet<AuditRejection> AuditRejection { set; get; }

        public DbSet<RejectReasonMaster> RejectReasonMaster { set; get; }

        public DbSet<CheckListMaster> CheckListMaster { set; get; }
        public DbSet<SegmentMaster> SegmentMaster { set; get; }

        public DbSet<CustomerDocumetUpload> CustomerDocumetUpload { set; get; }

        public DbSet<AuditDocumetUpload> AuditDocumetUpload { set; get; }
        
    }
}
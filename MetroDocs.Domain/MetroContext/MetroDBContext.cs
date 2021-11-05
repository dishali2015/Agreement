using System.Data.Entity;

namespace MetroDocs.Domain.MetroContext
{
    public class MetroDBContext : DbContext
    {
        public MetroDBContext() : base("name=MetroDB")
        {
            Database.SetInitializer(new MetroDBInitializer());
        }
        public DbSet<IdentityProof> IdentityProofs { set; get; }
        public DbSet<SMTPMailConfig> SMTPMailConfig { set; get; }

        // Agreement
        public DbSet<Agreement> Agreement { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<AgreementInfo> AgreementInfo { get; set; }
        public DbSet<AgreementDocument> AgreementDocument { get; set; }
    }
}

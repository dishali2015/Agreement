using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDocs.Domain.ViewModel
{
   public  class AgreementList
    {
        public Int64 SlNo { get; set; }
        public int AgreementId { get; set; }
        public string PremisesAddress1 { get; set; }
        public string PremisesAddress2 { get; set; }
        public string PremisesAddress3 { get; set; }
        public string PremisesCity { get; set; }
        public decimal SecurityDeposit { get; set; }
        public decimal RentAmountPerMonth { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EntryDate { get; set; }
        public string UserName { get; set; }
    }
}

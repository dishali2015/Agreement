using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDocs.Domain.ViewModel
{
   public class AgreementExpiryStatus
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
        public int DaysToExpiry { set; get; }
        public int DaysOverDue { set; get; }
        public string CSSClass { 
            get
            {
                if(DaysOverDue>0 || DaysToExpiry == 0)
                {
                    return "agreementexpired";
                }
                else if(DaysToExpiry<=7)
                {
                    return "agreement-1-7-days";
                }
                else if (DaysToExpiry <= 15)
                {
                    return "agreement-8-15-days";
                }
                else if (DaysToExpiry <= 31)
                {
                    return "agreement-16-31-days";
                }
                return "";                           
            } 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroDocs.Domain.ViewModel
{
   public class AgreementDocumentViewModel
    {
        public int DocumentId { get; set; }
        public int AgreementId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentType { get; set; }        
        public string ImageURL
        {
            get
            {
                string uploadpath = System.Configuration.ConfigurationManager.AppSettings["AgreementUploadURLPath"];
                return uploadpath + this.DocumentName;
            }
        }
        public string DisplayName
        {
            get
            {
                return DocumentName.Replace(this.DocumentId.ToString(), string.Empty).TrimStart('_').TrimEnd('_');
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocumentFormat.OpenXml.EMMA;
using MetroDocs.Domain.ViewModel;
using MetroDocs.Domain;
using AutoMapper;
using DocumentFormat.OpenXml.Drawing;
using MetroDocs.Domain.MetroContext;
using Microsoft.AspNet.Identity;
using MetroDocs.DBModule;

namespace MetroDocs.Controllers
{
    [Authorize]
    public class AgreementController : Controller
    {
        // GET: Agreement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateAgreement()
        {
            AgreementDataInputViewModel agreementView = new AgreementDataInputViewModel();            
            return View("CreateAgreement",agreementView);
        }

        public ActionResult SaveAgreement(MetroDocs.Domain.ViewModel.AgreementDataInputViewModel agreementView)
        {            
                    if(!ModelState.IsValid)
                    {
                        string messages = string.Join("; ", ModelState.Values
                                              .SelectMany(x => x.Errors)
                                              .Select(x => x.ErrorMessage));
                        ViewBag.Errmsg = messages;
                        return View("CreateAgreement", agreementView);              
                    }

            try
            {
                Agreement agreement = new Agreement();
                agreement = Mapper.Map<AgreementViewModel, Agreement>(agreementView.AgreementViewModel);
                agreement.LandLordContact = Mapper.Map<ContactInfoViewModel, ContactInfo>(agreementView.LandLordContact);
                agreement.TenantContact = Mapper.Map<ContactInfoViewModel, ContactInfo>(agreementView.TenantContact);
                agreement.EntryDate = DateTime.Now;
                agreement.UserId = User.Identity.GetUserId();
                agreement.PaymentMethod = agreementView.AgreementInfo.PaymentMethod;

                AgreementInfo AgreementInfo = new AgreementInfo();
                AgreementInfo.StartDate = agreementView.AgreementInfo.StartDate;
                AgreementInfo.EndDate = agreementView.AgreementInfo.EndDate;

                AgreementInfo.RentAmountPerMonth = agreementView.AgreementInfo.RentAmountPerMonth;
                AgreementInfo.SecurityDeposit = agreementView.AgreementInfo.SecurityDeposit;  
                AgreementInfo.RenewalUserId = User.Identity.GetUserId();
                AgreementInfo.RenewalDate = DateTime.Now;

                List<AgreementDocument> agreementdocument = new List<AgreementDocument>();

                foreach (var item in agreementView.AgreementInfo.UploadDocuments)
                {
                        agreementdocument.Add(new AgreementDocument
                        {
                            DocumentName = "PKID_" + System.IO.Path.GetFileName(item.FileName),
                            DocumentType = item.ContentType,
                            PostedDocument = item
                        }
                   );
                }
                AgreementInfo.AgreementDocument = agreementdocument;                
                agreement.AgreementInfo.Add(AgreementInfo);

                //TryUpdateModel(agreement); Babu 
                // TryUpdateModel update null 
                if (!ModelState.IsValid)
                {
                    string messages = string.Join("; ", ModelState.Values
                                          .SelectMany(x => x.Errors)
                                          .Select(x => x.ErrorMessage));
                    ViewBag.Errmsg = messages;
                    return View("CreateAgreement", agreementView);
                }
                

                using (MetroDBContext db = new MetroDBContext())
                {
                    db.Agreement.Add(agreement);
                    var i = db.SaveChanges();
                    foreach (var uploaddocument in AgreementInfo.AgreementDocument)
                    {
                        uploaddocument.DocumentName = uploaddocument.DocumentName.Replace("PKID", uploaddocument.DocumentId.ToString());
                        db.AgreementDocument.Attach(uploaddocument);
                        db.Entry(uploaddocument).Property(x => x.DocumentName).IsModified = true;
                        var j = db.SaveChanges();
                        if (j > 0)
                        {
                            string uploadpath = System.Configuration.ConfigurationManager.AppSettings["AgreementUploadPath"];
                            uploadpath = uploadpath + @"/" + uploaddocument.DocumentName;
                            uploaddocument.PostedDocument.SaveAs(uploadpath);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ViewBag.Errmsg = ex.Message;
                return View("CreateAgreement", agreementView);
            }

            return RedirectToAction("SuccessStatus", "Agreement");
        }
        public ActionResult AgreementExpiryStatus()
        {

            List<SelectListItem> reportOption = new List<SelectListItem>();
            reportOption.Add(new SelectListItem { Text = "Expired", Value = "-1" });
            reportOption.Add(new SelectListItem { Text = "1-7 Days", Value = "7" });
            reportOption.Add(new SelectListItem { Text = "8-15 Days", Value = "15" });
            reportOption.Add(new SelectListItem { Text = "16-30 Days", Value = "30" });
            reportOption.Add(new SelectListItem { Text = ">30 Days", Value = "31" });
            reportOption.Add(new SelectListItem { Text = "All", Value = "All" });

            ViewBag.reportOption = reportOption;

            return View();
        }
        public ViewResult SuccessStatus()
        {
            return View();
        }
        public ActionResult AgreementList()
        {
            ViewBag.Reportfrom = System.DateTime.Now.ToString("dd-MMM-yyyy");
            ViewBag.Reportto = System.DateTime.Now.ToString("dd-MMM-yyyy");
            return View();
        }

        [HttpGet]
        [Route("AgreementEntryList/{from}/{to}", Name = "AgreementEntryList")]
        public PartialViewResult AgreementEntryList(DateTime from, DateTime to)
        {            
            List<AgreementList> agreements = new List<AgreementList>();
            agreements = DBTransaction.GetAgreementList(from, to);
            return PartialView("_AgreementList", agreements);
        }

        [HttpGet]
        [Route("DisplayAgreementDocument/{AgreementId}", Name = "DisplayAgreementDocument")]
        public PartialViewResult DisplayAgreementDocument(Int32 AgreementId)
        {
            List<AgreementDocumentViewModel> agreementdocumetViewModels = new List<AgreementDocumentViewModel>();
            List<AgreementDocument> agreementDocuments = new List<AgreementDocument>();
            try
            {
                agreementDocuments = DBTransaction.AgreementDocument(AgreementId);
                agreementdocumetViewModels = Mapper.Map<List<AgreementDocument>, List<AgreementDocumentViewModel>>(agreementDocuments);
            }
            catch (Exception ex)
            {

            }
            return PartialView("_DisplayAgreementDocument", agreementdocumetViewModels);
        }

        [HttpGet]
        [Route("AgreementExpiryStatusReport/{ReportFilter}", Name = "AgreementExpiryStatusReport")]
        public PartialViewResult AgreementExpiryStatusReport(string ReportFilter)
        {
            List<AgreementExpiryStatus> agreements = new List<AgreementExpiryStatus>();
            agreements = DBTransaction.GetAgreementExpiryStatus(ReportFilter);
            return PartialView("_AgreementExpiryStatusReport", agreements);
        }

        

        [HttpGet]
        [Route("AgreementEdit/{AgreementId}", Name = "AgreementEdit")]
        public PartialViewResult AgreementEdit(Int32 AgreementId)
        {
            AgreementRenewal agreementrenewal = new AgreementRenewal();

            using (var db = new MetroDBContext())
            {
                var agreementinfo = db.AgreementInfo.Where(a => a.AgreementId == AgreementId).OrderByDescending(a => a.AgreementInfoId).FirstOrDefault();
                if (agreementinfo != null)
                {
                    agreementrenewal.AgreementInfoId = agreementinfo.AgreementInfoId;
                    agreementrenewal.AgreementId = agreementinfo.AgreementId;
                    agreementrenewal.StartDate = agreementinfo.StartDate;
                    agreementrenewal.EndDate = agreementinfo.EndDate;
                    agreementrenewal.SecurityDeposit = agreementinfo.SecurityDeposit;
                    agreementrenewal.RentAmountPerMonth = agreementinfo.RentAmountPerMonth;
                }
            }
            return PartialView("_DisplayAgreementInfo", agreementrenewal);
        }

        [HttpGet]
        [Route("DisplayAgreementInfo/{AgreementId}", Name = "DisplayAgreementInfo")]
        public PartialViewResult DisplayAgreementInfo(Int32 AgreementId)
        {
            AgreementRenewal agreementrenewal = new AgreementRenewal();

            using (var db = new MetroDBContext())
            {
                var agreementinfo = db.AgreementInfo.Where(a => a.AgreementId == AgreementId).OrderByDescending(a => a.AgreementInfoId).FirstOrDefault();
                if (agreementinfo != null)
                {
                    agreementrenewal.AgreementInfoId = agreementinfo.AgreementInfoId;
                    agreementrenewal.AgreementId = agreementinfo.AgreementId;
                    agreementrenewal.StartDate = agreementinfo.StartDate;
                    agreementrenewal.EndDate = agreementinfo.EndDate;
                    agreementrenewal.SecurityDeposit = agreementinfo.SecurityDeposit;
                    agreementrenewal.RentAmountPerMonth = agreementinfo.RentAmountPerMonth;
                }
            }
            return PartialView("_DisplayAgreementInfo", agreementrenewal);
        }

        [HttpPost]
        public ActionResult UpdateAgreementRenewal(AgreementRenewal agreementRenewal)
        {

            AgreementInfo AgreementInfo = new AgreementInfo();
            AgreementInfo.AgreementId = agreementRenewal.AgreementId;
            AgreementInfo.StartDate = agreementRenewal.RenewalStartDate ?? System.DateTime.Now;
            AgreementInfo.EndDate = agreementRenewal.RenewalEndDate ?? System.DateTime.Now;

            AgreementInfo.RentAmountPerMonth = agreementRenewal.RenewalRentAmountPerMonth ?? 0;
            AgreementInfo.SecurityDeposit = agreementRenewal.RenewalSecurityDeposit ?? 0;

            AgreementInfo.RenewalUserId = User.Identity.GetUserId();
            AgreementInfo.RenewalDate = DateTime.Now;

            List<AgreementDocument> agreementdocument = new List<AgreementDocument>();

            // Checking no of files injected in Request object  
            if (Request.Files.Count == 0)
            {
                return Json("No files selected.");
            }
            try
            {
                //  Get all files from Request object  
                HttpFileCollectionBase files = Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                    //string filename = Path.GetFileName(Request.Files[i].FileName);  

                    HttpPostedFileBase file = files[i];
                    string fname;

                    // Checking for Internet Explorer  
                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        string[] testfiles = file.FileName.Split(new char[] { '\\' });
                        fname = testfiles[testfiles.Length - 1];
                    }
                    else
                    {
                        fname = file.FileName;
                    }

                    agreementdocument.Add(new AgreementDocument
                    {
                       // AgreementInfoId = agreementRenewal.AgreementInfoId,
                        DocumentName = "PKID_" + System.IO.Path.GetFileName(fname),
                        DocumentType = file.ContentType,
                        PostedDocument = file
                    });
                }
                // Returns message that successfully uploaded  

                AgreementInfo.AgreementDocument = agreementdocument;

                using (MetroDBContext db = new MetroDBContext())
                {
                    db.AgreementInfo.Add(AgreementInfo);                 

                    var affectedrows = db.SaveChanges();

                    foreach (var uploaddocument in agreementdocument)
                    {
                        uploaddocument.DocumentName = uploaddocument.DocumentName.Replace("PKID", uploaddocument.DocumentId.ToString());
                        db.AgreementDocument.Attach(uploaddocument);
                        db.Entry(uploaddocument).Property(x => x.DocumentName).IsModified = true;
                        var j = db.SaveChanges();
                        if (j > 0)
                        {
                            string uploadpath = System.Configuration.ConfigurationManager.AppSettings["AgreementUploadPath"];
                            uploadpath = uploadpath + @"/" + uploaddocument.DocumentName;
                            uploaddocument.PostedDocument.SaveAs(uploadpath);
                        }
                    }
                }


                return Json("Agreement details updated successfully!");
            }
            catch (Exception ex)
            {
                return Json("Error occurred. Error details: " + ex.Message);
            }


        }

    }
}
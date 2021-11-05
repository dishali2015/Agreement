using MetroDocs.Domain;
using MetroDocs.Domain.MetroContext;
using MetroDocs.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MetroDocs.DBModule
{
    public class DBTransaction
    {
        public static bool AddUserToRole(string UserId, string Role)
        {// AddUserToRole(@UserId uniqueidentifier, @RoleName varchar(100))
            SqlParameter[] parameter =
                   {
                        new SqlParameter("@UserId",UserId),
                        new SqlParameter("@RoleName",Role),
                    };
            int rowsaffected = -1;
            using (MetroDBContext db = new MetroDBContext())
            {
                rowsaffected = db.Database.ExecuteSqlCommand("AddUserToRole @UserId,@RoleName", parameter);
            }
            return rowsaffected > 0;
        }
        public static bool RemoveUserFromRole(string UserId, string Role)
        {// RemoveUserFromRole(@UserId uniqueidentifier, @RoleName varchar(100))
            SqlParameter[] parameter =
                   {
                        new SqlParameter("@UserId",UserId),
                        new SqlParameter("@RoleName",Role),
                    };
            int rowsaffected = -1;
            using (MetroDBContext db = new MetroDBContext())
            {
                rowsaffected = db.Database.ExecuteSqlCommand("RemoveUserFromRole @UserId,@RoleName", parameter);
            }
            return rowsaffected > 0;
        }
        public static bool RemoveMapCheckListAndRole(string CheckListID, string RoleId)
        {
            SqlParameter[] parameter =
                  {
                        new SqlParameter("@CheckListId",CheckListID),
                        new SqlParameter("@RoleId",RoleId),
                    };
            int rosaffected = -1;
            using (MetroDBContext db = new MetroDBContext())
            {
                rosaffected = db.Database.ExecuteSqlCommand("RemoveMapCheckListAndRole @CheckListId,@RoleId", parameter);
            }
            return rosaffected > 0;
        }

      
        public static List<AgreementList> GetAgreementList(DateTime EntryFrom, DateTime EntryTo)
        {
            List<AgreementList> agreements = new List<AgreementList>();
            SqlParameter[] parameter = {
                    new SqlParameter("@EntryFrom", EntryFrom),
                    new SqlParameter("@EntryTo", EntryTo)
                };
            using (MetroDBContext db = new MetroDBContext())
            {
                try
                {
                    agreements = db.Database.SqlQuery<AgreementList>("Exec getAgreementList @EntryFrom, @EntryTo", parameter).ToList();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }                
            }
            return agreements;  
        }

        public static List<AgreementDocument> AgreementDocument(Int32 AgreementId)
        {
            List<AgreementDocument> agreementDocuments = new List<AgreementDocument>();
            using (MetroDBContext db = new MetroDBContext()) 
            {
                var agreementInfo = db.AgreementInfo.Where(a => a.AgreementId == AgreementId).OrderByDescending(s => s.AgreementInfoId).FirstOrDefault();

                if(agreementInfo!=null)
                {
                    agreementDocuments = db.AgreementDocument.Where(a => a.AgreementInfoId == agreementInfo.AgreementInfoId).ToList();
                }
            }
            return agreementDocuments;
        }

        public static List<AgreementExpiryStatus> GetAgreementExpiryStatus(string ReportFilter)
        {
            List<AgreementExpiryStatus> agreements = new List<AgreementExpiryStatus>(); // GetAgreementExpiryStatus(@ReportOption varchar(50))
            SqlParameter[] parameter = {
                    new SqlParameter("@ReportOption", ReportFilter)                    
                };
            using (MetroDBContext db = new MetroDBContext())
            {
                try
                {
                    agreements = db.Database.SqlQuery<AgreementExpiryStatus>("Exec GetAgreementExpiryStatus @ReportOption", parameter).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return agreements;
        }     
     

        public static bool AddUserToState(string UserId, Int32 StateId)
        {
            SqlParameter[] parameter =
                   {
                        new SqlParameter("@UserId",UserId),
                        new SqlParameter("@StateId",StateId)
                    };
            int rowsaffected = -1;
            using (MetroDBContext db = new MetroDBContext())
            {
                rowsaffected = db.Database.ExecuteSqlCommand("AddUserToState @UserId,@StateId", parameter);
            }
            return rowsaffected > 0;
        }
        public static bool RemoveUserFromState(string UserId, Int32 StateId)
        {
            SqlParameter[] parameter =
                   {
                        new SqlParameter("@UserId",UserId),
                        new SqlParameter("@StateId",StateId)
                    };
            int rowsaffected = -1;
            using (MetroDBContext db = new MetroDBContext())
            {
                rowsaffected = db.Database.ExecuteSqlCommand("RemoveUserFromState @UserId,@StateId", parameter);
            }
            return rowsaffected > 0;
        }

        public static bool AddUserToOrg(string UserId, Int32 OrgId)
        {
            SqlParameter[] parameter =
                   {
                        new SqlParameter("@UserId",UserId),
                        new SqlParameter("@OrgId",OrgId)
                    };
            int rowsaffected = -1;
            using (MetroDBContext db = new MetroDBContext())
            {
                rowsaffected = db.Database.ExecuteSqlCommand("AddUserToOrg @UserId,@OrgId", parameter);
            }
            return rowsaffected > 0;
        }
        public static bool RemoveUserFromOrg(string UserId, Int32 OrgId)
        {
            SqlParameter[] parameter =
                   {
                        new SqlParameter("@UserId",UserId),
                        new SqlParameter("@OrgId",OrgId)
                    };
            int rowsaffected = -1;
            using (MetroDBContext db = new MetroDBContext())
            {
                rowsaffected = db.Database.ExecuteSqlCommand("RemoveUserToOrg @UserId,@OrgId", parameter);
            }
            return rowsaffected > 0;
        }


    }
}


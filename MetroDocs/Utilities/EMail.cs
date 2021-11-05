using MetroDocs.Domain;
using MetroDocs.Domain.MetroContext;
using MetroDocs.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace MetroDocs.Mail
{
    public class EMail
    {
        public static bool sendMail(string To, String CC, string Subject,System.Text.StringBuilder MailBody)
        {
            string MailEnable = System.Configuration.ConfigurationManager.AppSettings["MailEnable"];
            
            if(string.IsNullOrEmpty(MailEnable) || string.IsNullOrWhiteSpace(MailEnable))
            {
                return false;
            }
           else  if (MailEnable.ToLower() != "true")
            {
                return false;
            }
            To = To ?? "";
            CC = CC ?? "";
            Subject = Subject ?? "";
      

            string From = "", Host = "", UserName = "", Password = "", DisplayName = "";
            int Port;

            SMTPMailConfig smtpconfig = new SMTPMailConfig();

            using (MetroDBContext db = new MetroDBContext())
            {
                smtpconfig = db.SMTPMailConfig.FirstOrDefault();
            }
            if(smtpconfig == null)
            {
                return false;
            }
            From = smtpconfig.FromId;
            Host = smtpconfig.Host;
            Port = smtpconfig.Port;
            UserName = smtpconfig.UserName;
            Password = smtpconfig.Password;
            DisplayName = smtpconfig.DisplayName;
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(From, DisplayName?? From);

                    foreach (string mailid in To.Replace(";", ",").Split(','))
                    {
                        if( !string.IsNullOrEmpty(mailid) &&  !string.IsNullOrWhiteSpace(mailid))
                        {
                            mail.To.Add(mailid);
                        }                            
                    }
                    foreach (string mailid in CC.Replace(";", ",").Split(','))
                    {
                        if (!string.IsNullOrEmpty(mailid) && !string.IsNullOrWhiteSpace(mailid))
                        {
                            mail.CC.Add(mailid);
                        }
                    }
                    mail.Subject = Subject;
                    mail.Body = MailBody != null ? MailBody.ToString() : "";
                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient(Host, Port))
                    {
                        smtp.Credentials = new NetworkCredential(UserName, Password);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                MetroErrorLog.LogException(ex, System.Web.HttpContext.Current.Request);
                return false;

            }

         //   return false;
        }
    }
}
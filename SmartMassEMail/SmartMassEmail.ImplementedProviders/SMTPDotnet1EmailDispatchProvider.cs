
// =====================================================================================
// Copyright © 2005 by Shahed Khan. All rights are reserved.
// 
// If you like this code then feel free to go ahead and use it.
// The only thing I ask is that you don't remove or alter my copyright notice.
//
// Your use of this software is entirely at your own risk. I make no claims or
// warrantees about the reliability or fitness of this code for any particular purpose.
// If you make changes or additions to this code please mark your code as being yours.
// 
// website , email shahed.khan@gmail.com
// =====================================================================================

using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using SmartMassEmail.Providers;
using System.Configuration;
using SmartMassEmail.Entities;
using SmartMassEmail.Data.SqlClient;
using SmartMassEmail.Data;
using SmartMassEmail;
using System.Web.Mail; //For .Net1.1
using System.Threading;
using System.Diagnostics;
//using System.Net.Mail; //For .Net2.0


namespace SmartMassEmail.ImplementedProviders
{
    public class SMTPDotnet1EmailDispatchProvider: EmailDispatchProvider
    {
        public SMTPDotnet1EmailDispatchProvider( ) 
		{
		}

		#region EmailDispatch specific functions

        // For .Net1.1 using SmtpMail
        public override bool Dispatch(TList<EmailMessage> list)
        {
            TList<EmailMessage> failurelist = new TList<EmailMessage>();

            SmtpSetting site = GetSmtpSetting();
            if (site == null)
                return false;
            
            SmtpMail.SmtpServer = site.SmtpServer;
            string username = site.SmtpServerUserName;
            string password = site.SmtpServerPassword;
            string portnumber = site.SmtpPortNumber;

            int sentCount = 0;
            int totalSent = 0;
            short connectionLimit = site.SmtpServerConnectionLimit;
            foreach (EmailMessage em in list)
            {
                try
                {
                    MailMessage m = new MailMessage();
                    m.Body = em.EmailBody;
                    m.From = em.EmailFrom;
                    m.To = em.EmailTo;
                    m.Subject = em.EmailSubject;

                    //Uncomment this if you want SmtpServerUsingNtlm Option
                    //for SMTP Authentication
                    //if (site.SmtpServerUsingNtlm)
                    //{
                    //    m.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "2"); //ntlm authentication
                    //}
                    //else if (site.SmtpServerRequiredLogin)
                    //{
                        m.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1"); //basic authentication
                        m.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", username); //set your username here
                        m.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", password); //set your password here
                    //}

                    // Add Port Number if one was configured
                    if (!IsNullorEmpty(portnumber))
                        m.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", portnumber); //set your port number here

                    //
                    m.Headers.Add("X-SME-EmailID", em.ID.ToString());
                    m.Headers.Add("X-SME-Attempts", (em.NumberOfRetry + 1).ToString());
                    m.Headers.Add("X-SME-AppDomain", AppDomain.CurrentDomain.FriendlyName);

                    // Set the body encoding
                    try { m.BodyEncoding = Encoding.GetEncoding(site.EmailEncoding); }
                    catch { m.BodyEncoding = Encoding.UTF8; }

                    // Replace any LF characters with CR LF
                    //m.Body = m.Body.Replace("\n", "\r\n");

                    // Send it
                    SmtpMail.Send(m);

                    EmailDeQueue.Delete(em);

                    if (connectionLimit != -1 && ++sentCount >= connectionLimit)
                    {
                        Thread.Sleep(new TimeSpan(0, 0, 0, site.WaitSecondsWhenConnectionLimitExceeds, 0));
                        sentCount = 0;
                    }
                    // on error, loop so to continue sending other email.
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message + " : " + (e.InnerException != null ? e.InnerException.Message : String.Empty));
                    EntLibHelper.ErrorLog(string.Format("Email Dispatch Error, EmailMessageID: {0} Exception: {1}", em.ID, e.ToString()),null);

                    // Add it to the failure list
                    failurelist.Add(em);
                }

                ++totalSent;

                //if (site.EmailThrottle > 0 && totalSent >= site.EmailThrottle)
                //{
                //    break;
                //}
            }

            if (failurelist.Count > 0)
            {
                ProcessFailedMessages(failurelist);
                return false;
            }


            //if (totalSent > 0 || failure.Count > 0)
            //{
            //    EventLogEntry entry = new EventLogEntry();
            //    entry.Message = string.Format("Email Queue:\n Messages Sent: {0}\nMessages Failed: {1}", totalSent, failure.Count);
            //    entry.Category = "Job Status";
            //    entry.EventID = 601;
            //    entry.SettingsID = site.SettingsID;
            //    EventLogs.Write(entry);
            //}

            return true;
        }
        

        private void ProcessFailedMessages(TList<EmailMessage> list)
        {
            ProcessFailure.Process(list);
        }

        private SmtpSetting GetSmtpSetting( )
        {
            try
            {
                SmtpSetting setting = new SmtpSetting();                
                setting.SmtpServer = ConfigurationManager.AppSettings.Get("SmtpServer").ToString();
                setting.SmtpServerUserName = ConfigurationManager.AppSettings.Get("SmtpServerUserName").ToString();
                setting.SmtpServerPassword = ConfigurationManager.AppSettings.Get("SmtpServerPassword").ToString();
                setting.SmtpPortNumber = ConfigurationManager.AppSettings.Get("SmtpPortNumber").ToString();
                short.TryParse(ConfigurationManager.AppSettings.Get("SmtpServerConnectionLimit").ToString(), out setting.SmtpServerConnectionLimit);
                int.TryParse(ConfigurationManager.AppSettings.Get("WaitSecondsWhenConnectionLimitExceeds").ToString(), out setting.WaitSecondsWhenConnectionLimitExceeds);
                setting.EmailEncoding = ConfigurationManager.AppSettings.Get("EmailEncoding").ToString();
                return setting;
            }
            catch(Exception e) {
                SmartMassEmail.EntLibHelper.ErrorLog("Smtp Settings not correct: "+ e.ToString(), null);
                return null;
            }
        }

        private class SmtpSetting
        {
            public string SmtpServer = string.Empty;
            public string SmtpServerUserName = string.Empty;
            public string SmtpServerPassword = string.Empty;
            public string SmtpPortNumber = string.Empty;
            public short SmtpServerConnectionLimit = 5;
            public int WaitSecondsWhenConnectionLimitExceeds = 15;
            
            public string EmailEncoding = "utf - 8";
        }

        public  bool IsNullorEmpty(string text)
        {
            return text == null || text.Trim() == string.Empty;
        }
		
		#endregion

		#region Provider specific behaviors
		public override void Initialize(string name, NameValueCollection configValue) {

		}

		public override string Name {
			get {
				return null;
			}
		}
		#endregion
    }
}

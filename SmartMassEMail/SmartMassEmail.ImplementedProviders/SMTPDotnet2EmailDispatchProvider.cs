
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
using System.Threading;
using System.Diagnostics;
using System.Net.Mail; //For .Net2.0
using System.ComponentModel;


namespace SmartMassEmail.ImplementedProviders
{
    public class SMTPDotnet2EmailDispatchProvider: EmailDispatchProvider
    {
        public SMTPDotnet2EmailDispatchProvider( ) 
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
            
            

            int sentCount = 0;
            int totalSent = 0;
            short connectionLimit = site.SmtpServerConnectionLimit;
            
            SmtpClient client = new SmtpClient();
            System.Net.NetworkCredential credential = new System.Net.NetworkCredential();
            credential.Password = site.SmtpServerPassword;
            credential.UserName = site.SmtpServerUserName;
                        
            client.Host = site.SmtpServer;
            client.Port = Convert.ToInt32(site.SmtpPortNumber);
            client.EnableSsl = site.EnableSsl;
            if (site.SmtpServerUserName != "")
            {
                client.Credentials = credential;
            }

            foreach (EmailMessage em in list)
            {
                try
                {
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(em.EmailFrom,em.EmailCC);
                    message.To.Add(new MailAddress(em.EmailTo));
                    message.Subject = em.EmailSubject;
                    message.Body = em.EmailBody;

                    if (em.EmailBCC != "")  {
                        message.Bcc.Add(new MailAddress(em.EmailBCC)) ;
                    }

                   // message.Headers.Add("X-SME-EmailID", em.ID.ToString());
                   // message.Headers.Add("X-SME-Attempts", (em.NumberOfRetry + 1).ToString());
                   // message.Headers.Add("X-SME-AppDomain", AppDomain.CurrentDomain.FriendlyName);

                    message.IsBodyHtml = em.IsHtml;

                    // Set the body encoding
                    try { message.BodyEncoding = Encoding.GetEncoding(site.EmailEncoding); }
                    catch { message.BodyEncoding = Encoding.UTF8; }                         
                    
                    
                    
                    //Sending Mails Ascynchronously
                    //client.SendCompleted +=  new SendCompletedEventHandler(SendCompletedHandler);                    
                    //client.SendAsync(message, null);          

                    

                    client.Send(message);
                    

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

        private void SendCompletedHandler(System.Object sender,  AsyncCompletedEventArgs e)
        {
            //Code to process the completion
            
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
                Boolean.TryParse(ConfigurationManager.AppSettings.Get("EnableSsl"), out setting.EnableSsl);
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
            public bool SmtpServerUsingNtlm = false;
            public bool SmtpServerRequiredLogin = false;
            public string EmailEncoding = "utf - 8";
            public bool EnableSsl = false;
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

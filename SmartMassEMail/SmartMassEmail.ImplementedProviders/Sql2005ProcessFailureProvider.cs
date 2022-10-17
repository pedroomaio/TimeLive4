
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
using System.Xml.Serialization;
using System.IO;
using System.Data.SqlClient;
using SmartMassEmail;

namespace SmartMassEmail.ImplementedProviders
{
    public class Sql2005ProcessFailureProvider: ProcessFailureProvider
    {
        public Sql2005ProcessFailureProvider( ) 
		{

		}

		#region ProcessFailure specific functions
        public override void Process(TList<EmailMessage> list)
		{
            if (list != null)
            {
                foreach (EmailMessage message in list)
                {
                    message.NumberOfRetry = message.NumberOfRetry + 1;

                    // put the message in queue again if maximum retry not exceeded
                    if (message.NumberOfRetry < message.MaximumRetry)
                    {
                        string xml = "";
                        using (MemoryStream stream = new MemoryStream())
                        {
                            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(message.GetType());
                            x.Serialize(stream, message);
                            xml = ConvertByteArrayToString(stream.ToArray());

                        }

                        string sql =
                            string.Format(@"DECLARE @dialog_handle UNIQUEIDENTIFIER;    
                    BEGIN DIALOG CONVERSATION @dialog_handle
                        FROM SERVICE [SMEPostingService]
                        TO SERVICE 'SMEService'
                            ON CONTRACT [SMEContract] ;

                        -- Send message on dialog conversation
                        SEND ON CONVERSATION @dialog_handle
                            MESSAGE TYPE [SMEMessageType]
                            ('{0}') ;

                    End Conversation @dialog_handle
                    With cleanup", xml);

                        string connectionString = ConfigurationManager.ConnectionStrings["SmartMassEmailConnectionString2005"].ConnectionString;

                        SqlConnection conn = new SqlConnection(connectionString);
                        SqlCommand cmd = null;
                        try
                        {
                            conn.Open();
                            cmd = conn.CreateCommand();
                            cmd.CommandText = sql;
                            cmd.Transaction = conn.BeginTransaction();
                            cmd.ExecuteNonQuery();
                            cmd.Transaction.Commit();
                            conn.Close();
                        }
                        catch (Exception x)
                        {
                            if (conn != null)
                            {
                                if (cmd != null)
                                {
                                    if (cmd.Transaction != null)
                                        cmd.Transaction.Rollback();
                                }
                                if (conn.State == System.Data.ConnectionState.Open)
                                    conn.Close();
                            }
                            EntLibHelper.ErrorLog(x.ToString(), null);
                        }
                    }
                }
            }
                                
            
			
		}

        private string ConvertByteArrayToString(byte[] byteArray)
        {
            Encoding enc = Encoding.UTF8;
            string text = enc.GetString(byteArray);
            return text;
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


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
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;

namespace SmartMassEmail.ImplementedProviders
{
    public class Sql2005EmailDeQueueProvider: EmailDeQueueProvider
    {
        public Sql2005EmailDeQueueProvider( ) 
		{
		}

		#region EmailDeQueue specific functions
        public override TList<EmailMessage> Recieve( )
		{
            //
            TList<EmailMessage> list = new TList<EmailMessage>();

            string connectionString = ConfigurationManager.ConnectionStrings["SmartMassEmailConnectionString2005"].ConnectionString;
            string queueSchema = "dbo";
            string queueName = "SMEPostQueue";

            // Create the connection and service objects.
            //
            SqlConnection conn = new SqlConnection(connectionString);
            GroupCommitService service = new GroupCommitService(
                conn, queueSchema, queueName);

            // Time interval to wait for messages to arrive on a queue before giving up
            // and returning from the receive loop.
            //
            service.QueueEmptyTimeout = TimeSpan.FromSeconds(10);


            // Time interval to receive additional batches of messages (i.e. lock
            // additional conversation group) from the time we receive first set
            // of messages.
            //
            service.GroupCommitTimeout = TimeSpan.FromSeconds(3);

            // At most we are willing to lock 5 conversation (groups) in a single
            // transaction.
            //
            service.ReceivesPerTransaction = 5;

            try
            {
                conn.Open();

                // Loop to receive and process incoming messages.
                //
                list = service.Run();

                conn.Close();
            }
            catch (SqlException se)
            {
                Console.Error.WriteLine("Exception thrown by SqlClient: {0}", se.Message);
            }
           
            return list;
		}

        public override bool Delete(EmailMessage message )
        {
            //
            return false;
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

    /// <summary>
    /// Originally written by:
    /// I changed it according to my need.
    /// </summary>
    public class GroupCommitService
    {
        #region Private Fields
        private SqlConnection m_connection;
        private string m_queueName;
        private string m_queueSchema;
        private TimeSpan m_queueEmptyTimeout;
        private TimeSpan m_groupCommitTimeout;
        private int m_nReceivesPerTransaction;
        #endregion

        #region Public Properties
        /// <summary>
        /// Timeout for the first WAITFOR(RECEIVE...) issued when we have not
        /// yet received any messages in the transaction.
        /// </summary>
        public TimeSpan QueueEmptyTimeout
        {
            get { return m_queueEmptyTimeout; }
            set { m_queueEmptyTimeout = value; }
        }

        /// <summary>
        /// Amount of time to try to receive additional messages after we have
        /// received the first set of messages.
        /// </summary>
        public TimeSpan GroupCommitTimeout
        {
            get { return m_groupCommitTimeout; }
            set { m_groupCommitTimeout = value; }
        }

        /// <summary>
        /// The maximum number of receive statements to execute in a transaction.
        /// </summary>
        public int ReceivesPerTransaction
        {
            get { return m_nReceivesPerTransaction; }
            set { m_nReceivesPerTransaction = value; }
        }
        #endregion

        #region Constructor
        public GroupCommitService(
            SqlConnection connection,
            string queueSchema,
            string queueName)
        {
            m_connection = connection;
            m_queueSchema = queueSchema;
            m_queueName = queueName;

            // By default we set this to infinite (-1)
            //
            m_queueEmptyTimeout = TimeSpan.FromMilliseconds(-1);

            // By default we set this to 3 seconds
            //
            m_groupCommitTimeout = TimeSpan.FromSeconds(3);

            // By default we set this to 10 receives per transaction
            //
            m_nReceivesPerTransaction = 10;
        }
        #endregion

        #region Public Methods
        public TList<EmailMessage> Run()
        {
            TList<EmailMessage> list = new TList<EmailMessage>();
            SqlCommand cmd = CreateReceiveCommand();
            SqlParameter prmTimeout = cmd.Parameters["@timeout"];

            DateTime commitTime = DateTime.Now;

            while (true)
            {
                // Begin the transaction
                //
                BeginTransaction(cmd);
                
                // Execute WAITFOR(RECEIVE...), TIMEOUT QueueEmptyTimeout
                //
                prmTimeout.Value = (int) m_queueEmptyTimeout.TotalMilliseconds;
                SqlDataReader reader = cmd.ExecuteReader();

                // If it gives us an empty result set.
                //
                if (!reader.HasRows)
                {
                    // We are done with this reader.
                    //
                    reader.Close();

                    // We must commit the transaction.
                    //
                    CommitTransaction(cmd);

                    break;
                }
                
                // Calculate the curfew on this transaction.
                //
                commitTime = DateTime.Now.Add(m_groupCommitTimeout);

                // Set the number of receives performed to 1
                //
                int nReceive = 1;

                while (true)
                {
                    // Process the messages
                    //
                    while (reader.Read())
                    {
                        EmailMessage message = ProcessMessage(reader);
                        if (message != null)
                            list.Add(message);
                    }
                    // We are done with this reader.
                    //
                    reader.Close();

                    // If we have reached the threshold of the number of receives
                    // that can be executed in a single transaction, exit the loop.
                    //
                    if (nReceive >= m_nReceivesPerTransaction)
                    {
                        break;
                    }

                    // Calculate the amount of time left as the difference
                    // between now and when our transaction should be committed.
                    //
                    TimeSpan timeLeft = commitTime - DateTime.Now;

                    // If there is no more time left, exit the loop.
                    //
                    if (timeLeft < TimeSpan.Zero)
                    {
                        break;
                    }

                    // Execute WAITFOR(RECEIVE...), TIMEOUT timeLeft
                    //
                    prmTimeout.Value = (int)timeLeft.TotalMilliseconds;
                    reader = cmd.ExecuteReader();
                    nReceive++;

                    // If it gives us an empty result set, we must have surpassed
                    // the curfew, so exit the loop.
                    //
                    if (!reader.HasRows)
                    {
                        // We are done with this reader.
                        //
                        reader.Close();
                        break;
                    }
                }

                // Commit the transaction.
                //
                CommitTransaction(cmd);
                
            }
            return list;
        }
        #endregion

        #region Private Methods
        private void BeginTransaction(SqlCommand cmd)
        {
            cmd.Transaction = m_connection.BeginTransaction();
        }

        private void CommitTransaction(SqlCommand cmd)
        {
            cmd.Transaction.Commit();
        }

        private EmailMessage ProcessMessage(SqlDataReader reader)
        {
            string xml = reader["mgb"].ToString();
            if (xml != null)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(xml);
                EmailMessage message = new EmailMessage();
                message   = (EmailMessage)LoadFromXml(message, bytes);
                return message;
            }
            return null;
            
        }
        

        private SqlCommand CreateReceiveCommand()
        {
            SqlCommand cmd = m_connection.CreateCommand();
            cmd.CommandText = @"WAITFOR (RECEIVE TOP (10) *,CONVERT( NVARCHAR(max), message_body ) as mgb FROM [" +
                m_queueSchema.Replace("]", "]]") + "].[" +
                m_queueName.Replace("]", "]]") + "]), TIMEOUT @timeout";
            cmd.Parameters.Add("@timeout", System.Data.SqlDbType.Int);
            cmd.CommandTimeout = 0;
            return cmd;
        }

        public static Object LoadFromXml(Object objectToLoad, byte[] b)
        {

            using (MemoryStream stream = new MemoryStream(b))
            {

                StreamReader reader = null;

                try
                {
                    Type thetype = objectToLoad.GetType();
                    XmlSerializer x = new XmlSerializer(thetype);

                    reader = new StreamReader(stream);
                    objectToLoad = x.Deserialize(reader);
                }
                finally
                {
                    //Make sure to close the file even if an exception is raised...
                    if (reader != null)
                        reader.Close();
                }
            }

            return objectToLoad;
        }

        
        #endregion
    }

}

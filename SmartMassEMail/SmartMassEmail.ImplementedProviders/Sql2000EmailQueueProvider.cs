
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

namespace SmartMassEmail.ImplementedProviders
{
    public class Sql2000EmailQueueProvider: EmailQueueProvider
    {
        public Sql2000EmailQueueProvider( ) 
		{
		}

		#region EmailQueue specific functions
        public override bool Send(EmailMessage message)
		{
            if (message != null)
            {
                SmartMassEmail.Data.Bases.NetTiersProvider p = DataRepository.Provider;
                DataRepository rep = new DataRepository();
                
                TransactionManager transaction = rep.CreateTransaction();
                try
                {
                    transaction.BeginTransaction();
                    DataRepository.EmailMessageProvider.Insert(transaction, message);
                    if (message.EmailMessageDetailCollection != null)
                    {
                        if (message.EmailMessageDetailCollection.Count > 0)
                            DataRepository.EmailMessageDetailProvider.Insert(transaction, message.EmailMessageDetailCollection);
                    }
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                        if (transaction.IsOpen)
                        {
                            transaction.Rollback();
                            transaction = null;
                        }
                }
            }
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
}

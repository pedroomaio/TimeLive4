
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
    public class Sql2000EmailDeQueueProvider: EmailDeQueueProvider
    {
        public Sql2000EmailDeQueueProvider( ) 
		{
		}

		#region EmailDeQueue specific functions
        public override TList<EmailMessage> Recieve( )
		{
            //
            TList<EmailMessage> list = DataRepository.EmailMessageProvider.GetPendingEmailMessage();
            
            //This will prevent any other process to pickup the same email.
            foreach (EmailMessage em in list)
            {
                em.Status = (int)EmailMessage.EmailMessageStatus.Processing; 
            }
            DataRepository.EmailMessageProvider.Update(list);
            return list;
		}

        public override bool Delete(EmailMessage message )
        {
            //
            return DataRepository.EmailMessageProvider.Delete(message);
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

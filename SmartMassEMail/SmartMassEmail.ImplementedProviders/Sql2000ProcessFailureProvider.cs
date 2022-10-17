
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
    public class Sql2000ProcessFailureProvider: ProcessFailureProvider
    {
        public Sql2000ProcessFailureProvider( ) 
		{
		}

		#region ProcessFailure specific functions
        public override void Process(TList<EmailMessage> list )
		{
            //            
            //
            foreach (EmailMessage em in list)
            {
                
                if (em.NumberOfRetry < em.MaximumRetry)
                {
                    em.Status = (int)EmailMessage.EmailMessageStatus.Pending;
                    em.NumberOfRetry = em.NumberOfRetry + 1;
                    //ReTry again after 10 min
                    em.RetryTime = em.RetryTime.AddMinutes(10);
                    DataRepository.EmailMessageProvider.Update(em);
                }
                else 
                {
                    //Delete the Message
                    DataRepository.EmailMessageProvider.Delete(em);
                }
            }
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

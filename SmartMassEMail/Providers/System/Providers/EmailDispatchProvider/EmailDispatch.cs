	
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
using System.Configuration;
using SmartMassEmail.Entities;

namespace SmartMassEmail.Providers 
{
	public class EmailDispatch 
	{
		public static bool Dispatch (TList<EmailMessage> list)
		{
            return EmailDispatchProvider.Instance().Dispatch(list);
		}
        
		
	}


}

	
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
using System.Collections.Specialized;

namespace SmartMassEmail.Providers 
{
	public class EmailTemplate 
	{
		public static SmartMassEmail.Entities.Template GetTemplate (string templateName)
		{
            return EmailTemplateProvider.Instance().GetTemplate(templateName);
		}

        public static SmartMassEmail.Entities.EmailMessage GetTemplatedMessage(string templateName, SmartMassEmail.Entities.EmailMessage message, StringDictionary namevalue)
        {
            return EmailTemplateProvider.Instance().GetTemplatedMessage(templateName, message, namevalue);
        }
        		
	}
}

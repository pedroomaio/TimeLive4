
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
using System.Collections;


namespace SmartMassEmail.ImplementedProviders
{
    public class FileSystemEmailTemplateProvider: EmailTemplateProvider
    {
        public FileSystemEmailTemplateProvider( ) 
		{
		}

		#region EmailTemplate specific functions
        public override SmartMassEmail.Entities.Template GetTemplate(string templateName)
		{
			//Get template from filesystem and return a Template Object
            string path = System.Web.Hosting.HostingEnvironment.MapPath(ConfigurationManager.AppSettings.Get("TemplateFolderPath").ToString());
            string fileContents;
            using (System.IO.StreamReader sr = new System.IO.StreamReader(string.Format(@"{0}{1}.txt",path,templateName)))
            {
                fileContents = sr.ReadToEnd();
            }
            SmartMassEmail.Entities.Template template = new SmartMassEmail.Entities.Template();
            template.TemplateName = templateName;
            template.TemplateBody = fileContents;
            return template;
		}

        public override SmartMassEmail.Entities.EmailMessage GetTemplatedMessage(string templateName, SmartMassEmail.Entities.EmailMessage message, StringDictionary namevalue)
        {
            Template template = GetTemplate(templateName);
            if (message != null)
            {
                if (template != null)
                {
                    if (namevalue != null)
                    {
                        foreach (DictionaryEntry de in namevalue)
                        {
                           template.TemplateBody = template.TemplateBody.Replace(de.Key.ToString(), de.Value.ToString());
                        }
                        message.EmailBody = template.TemplateBody;
                    }
                }
            }
            return message;
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

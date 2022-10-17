	
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
using System.Collections;
using System.Xml;
using System.Collections.Specialized;

namespace SmartMassEmail.Providers {

	public class EmailQueueConfiguration {
		string defaultProvider;
		Hashtable providers = new Hashtable();

        public static EmailQueueConfiguration GetConfig( )
        {
            //return (EmailQueueConfiguration)ConfigurationSettings.GetConfig("smartMassEmail.providers/emailQueue");
            return (EmailQueueConfiguration)ConfigurationManager.GetSection("smartMassEmail.providers/emailQueue");
		}  

		public void LoadValuesFromConfigurationXml(XmlNode node) {
			XmlAttributeCollection attributeCollection = node.Attributes;

			// Get the default provider
			defaultProvider = attributeCollection["defaultProvider"].Value;

			// Read child nodes
			foreach (XmlNode child in node.ChildNodes) {
				if (child.Name == "providers")
					GetProviders(child);
			}
		}

		void GetProviders(XmlNode node) {
			foreach (XmlNode provider in node.ChildNodes) {
				switch (provider.Name) {
					case "add" :
						providers.Add(provider.Attributes["name"].Value, new Provider(provider.Attributes) );
						break;

					case "remove" :
						providers.Remove(provider.Attributes["name"].Value);
						break;

					case "clear" :
						providers.Clear();
						break;
				}
			}
		}

		// Properties
		//
		public string DefaultProvider { get { return defaultProvider; } }
		public Hashtable Providers { get { return providers; } } 

	}

	
}

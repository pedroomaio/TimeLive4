
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

namespace SmartMassEmail.Providers 
{
    public class Provider
    {
        string name;
        string providerType;
        NameValueCollection providerAttributes = new NameValueCollection();

        public Provider(XmlAttributeCollection attributes)
        {

            // Set the name of the provider
            //
            name = attributes["name"].Value;

            // Set the type of the provider
            //
            providerType = attributes["type"].Value;

            // Store all the attributes in the attributes bucket
            //
            foreach (XmlAttribute attribute in attributes)
            {

                if ((attribute.Name != "name") && (attribute.Name != "type"))
                    providerAttributes.Add(attribute.Name, attribute.Value);

            }

        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Type
        {
            get
            {
                return providerType;
            }
        }

        public NameValueCollection Attributes
        {
            get
            {
                return providerAttributes;
            }
        }

    }
}

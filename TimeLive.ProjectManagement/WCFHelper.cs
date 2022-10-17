using System;
using System.ServiceModel.Channels;
using System.Windows;

namespace ProjectManagement
{
    public class WCFHelper
    {
        public static T CreateService<T>(string serviceURL)
        {
            System.ServiceModel.Channels.CustomBinding binding = new System.ServiceModel.Channels.CustomBinding();
            binding.Elements.Add(new BinaryMessageEncodingBindingElement());
            if (Application.Current.Host.Source.AbsoluteUri.StartsWith("https"))
                binding.Elements.Add(new HttpsTransportBindingElement { MaxBufferSize = Int32.MaxValue, MaxReceivedMessageSize = Int32.MaxValue });
            else
                binding.Elements.Add(new HttpTransportBindingElement { MaxBufferSize = Int32.MaxValue, MaxReceivedMessageSize = Int32.MaxValue });
            Uri uri;
            if (serviceURL.StartsWith("http"))
                uri = new Uri(serviceURL);
            else
                uri = new Uri(Application.Current.Host.Source, serviceURL);

            System.ServiceModel.EndpointAddress address = new System.ServiceModel.EndpointAddress(uri);
            try
            {
                return (T)Activator.CreateInstance(typeof(T), binding, address);
            }
            catch (Exception e)
            {
                string s = e.Message;
            }
            return default(T);
        }
    }
}
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ServiceModel.Channels;

namespace ProjectManagement
{
    public class WebServiceUtilities
    {
        public const string TaskServiceURI = "services/TaskService.svc";
        public const string EmployeeServiceURI = "services/EmployeeService.svc";
        public static string GetTaskServiceURI()
        {
            string ApplicationPath = Application.Current.Host.Source.AbsoluteUri.Replace("ClientBin/ProjectManagement.xap", "");
            return ApplicationPath + TaskServiceURI;
        }
        public static string GetEmployeeServiceURI()
        {
            string ApplicationPath = Application.Current.Host.Source.AbsoluteUri.Replace("ClientBin/ProjectManagement.xap", "");
            return ApplicationPath + EmployeeServiceURI;
        }
        public static CustomBinding GetServiceBinding()
        {
            CustomBinding binding = new CustomBinding();
            binding.Elements.Add(new BinaryMessageEncodingBindingElement());
            if (Application.Current.Host.Source.Scheme.Equals("https"))
            {
                binding.Elements.Add(new HttpsTransportBindingElement() { MaxBufferSize = int.MaxValue, MaxReceivedMessageSize = int.MaxValue });
            }
            else
            {
                binding.Elements.Add(new HttpTransportBindingElement() { MaxBufferSize = int.MaxValue, MaxReceivedMessageSize = int.MaxValue });
            }
            return binding;
        }
    }
}

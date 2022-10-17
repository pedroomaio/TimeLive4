using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;
namespace SmartMassEmail.Entities
{
    ///<summary>
    ///</summary>
    /// <remarks>
    /// </remarks>	
    [Serializable]
    public class Template
    {
        private string _TemplateName;
        ///<summary>
        ///</summary>
        /// <remarks>
        /// </remarks>	
        public string TemplateName
        {
            get { return _TemplateName; }
            set { _TemplateName = value; }
        }

        private string _TemplateBody;
        ///<summary>
        ///</summary>
        /// <remarks>
        /// </remarks>	
        public string TemplateBody
        {
            get { return _TemplateBody; }
            set { _TemplateBody = value; }
        }


    }
}

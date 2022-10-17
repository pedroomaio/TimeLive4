#region Using directives

using System;

#endregion

namespace SmartMassEmail.Entities
{	
	///<summary>
	/// An object representation of the 'EmailMessage' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	public partial class EmailMessage 
	{
        ///<summary>
        ///</summary>
		public enum EmailMessageStatus
        {
            ///<summary>
            ///</summary>
            Pending = 0,
            ///<summary>
            ///</summary>
            Processing =1,
            ///<summary>
            ///</summary>
            Complete=3,
            ///<summary>
            ///</summary>
            Failure=4
        }
	}
}

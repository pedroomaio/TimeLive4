#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using SmartMassEmail.Entities;
using SmartMassEmail.Data;

#endregion

namespace SmartMassEmail.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="EmailMessageDetailProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class EmailMessageDetailProviderBase : EmailMessageDetailProviderBaseCore
	{
	} // end class
} // end namespace

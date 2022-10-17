
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Generated on : Friday, 1 September 2006
	Important: Do not modify this file. Edit the file SqlEmailMessageProvider.cs instead.
*/

#region using directives

using System;
using System.Data;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using System.Collections;
using System.Collections.Specialized;

using System.Diagnostics;
using SmartMassEmail.Entities;
using SmartMassEmail.Data;
using SmartMassEmail.Data.Bases;

#endregion

namespace SmartMassEmail.Data.SqlClient
{
	///<summary>
	/// This class is the SqlClient Data Access Logic Component implementation for the <see cref="EmailMessage"/> entity.
	///</summary>
	public partial class SqlEmailMessageProviderBase : EmailMessageProviderBase
	{
		#region Declarations
		
		string _connectionString;
	    bool _useStoredProcedure;
	    string _providerInvariantName;
			
		#endregion "Declarations"
			
		#region Constructors
		
		/// <summary>
		/// Creates a new <see cref="SqlEmailMessageProviderBase"/> instance.
		/// </summary>
		public SqlEmailMessageProviderBase()
		{
		}
	
	/// <summary>
	/// Creates a new <see cref="SqlEmailMessageProviderBase"/> instance.
	/// Uses connection string to connect to datasource.
	/// </summary>
	/// <param name="connectionString">The connection string to the database.</param>
	/// <param name="useStoredProcedure">A boolean value that indicates if we use the stored procedures or embedded queries.</param>
	/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	public SqlEmailMessageProviderBase(string connectionString, bool useStoredProcedure, string providerInvariantName)
	{
		this._connectionString = connectionString;
		this._useStoredProcedure = useStoredProcedure;
		this._providerInvariantName = providerInvariantName;
	}
		
	#endregion "Constructors"
	
		#region Public properties
	/// <summary>
    /// Gets or sets the connection string.
    /// </summary>
    /// <value>The connection string.</value>
    public string ConnectionString
	{
		get {return this._connectionString;}
		set {this._connectionString = value;}
	}
	
	/// <summary>
    /// Gets or sets a value indicating whether to use stored procedures.
    /// </summary>
    /// <value><c>true</c> if we choose to use use stored procedures; otherwise, <c>false</c>.</value>
	public bool UseStoredProcedure
	{
		get {return this._useStoredProcedure;}
		set {this._useStoredProcedure = value;}
	}
	
	/// <summary>
    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
    /// </summary>
    /// <value>The name of the provider invariant.</value>
    public string ProviderInvariantName
    {
        get { return this._providerInvariantName; }
        set { this._providerInvariantName = value; }
    }
	#endregion
	
		#region Get Many To Many Relationship Functions
	#endregion
	
	
		#region Delete Functions
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="id">. Primary Key.</param>	
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Delete(TransactionManager transactionManager, System.Guid id)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.EmailMessage_Delete", _useStoredProcedure);
			database.AddInParameter(commandWrapper, "@ID", DbType.Guid, id);
			
			int results = 0;
			
			if (transactionManager != null)
			{	
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}
			
			//Stop Tracking Now that it has been updated and persisted.
			if (DataRepository.Provider.EnableEntityTracking)
			{
				string entityKey = EntityLocator.ConstructKeyFromPkItems(typeof(EmailMessage)
					,id);
				EntityManager.StopTracking(entityKey);
			}
			
			if (results == 0)
			{
				//throw new DataException("The record has been already deleted.");
				return false;
			}
			
			return Convert.ToBoolean(results);
		}//end Delete
		#endregion

		#region Find Functions
		/// <summary>
		/// 	Returns rows meeting the whereclause condition from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <remarks>Operators must be capitalized (OR, AND)</remarks>
		/// <returns>Returns a typed collection of SmartMassEmail.Entities.EmailMessage objects.</returns>
		public override SmartMassEmail.Entities.TList<EmailMessage> Find(TransactionManager transactionManager, string whereClause, int start, int pageLength, out int count)
		{
			count = -1;
			if (whereClause.IndexOf(";") > -1)
				return new SmartMassEmail.Entities.TList<EmailMessage>();
	
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.EmailMessage_Find", _useStoredProcedure);

		bool searchUsingOR = false;
		if (whereClause.IndexOf("OR") > 0) // did they want to do "a=b OR c=d OR..."?
			searchUsingOR = true;
		
		database.AddInParameter(commandWrapper, "@SearchUsingOR", DbType.Boolean, searchUsingOR);
		
		database.AddInParameter(commandWrapper, "@ID", DbType.Guid, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ChangeStamp", DbType.DateTime, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Priority", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Status", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@NumberOfRetry", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@RetryTime", DbType.DateTime, DBNull.Value);
		database.AddInParameter(commandWrapper, "@MaximumRetry", DbType.Int32, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ExpiryDatetime", DbType.DateTime, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ArrivedDateTime", DbType.DateTime, DBNull.Value);
		database.AddInParameter(commandWrapper, "@SenderInfo", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@EmailTo", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@EmailFrom", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@EmailSubject", SqlDbType.NVarChar, DBNull.Value);
		database.AddInParameter(commandWrapper, "@EmailBody", SqlDbType.NText, DBNull.Value);
		database.AddInParameter(commandWrapper, "@EmailCC", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@EmailBCC", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@IsHtml", DbType.Boolean, DBNull.Value);
	
			// replace all instances of 'AND' and 'OR' because we already set searchUsingOR
			whereClause = whereClause.Replace("AND", "|").Replace("OR", "|") ; 
			string[] clauses = whereClause.ToLower().Split('|');
		
			// Here's what's going on below: Find a field, then to get the value we
			// drop the field name from the front, trim spaces, drop the '=' sign,
			// trim more spaces, and drop any outer single quotes.
			// Now handles the case when two fields start off the same way - like "Friendly='Yes' AND Friend='john'"
				
			char[] equalSign = {'='};
			char[] singleQuote = {'\''};
	   		foreach (string clause in clauses)
			{
				if (clause.Trim().StartsWith("id ") || clause.Trim().StartsWith("id="))
				{
					database.SetParameterValue(commandWrapper, "@ID", new Guid(
						clause.Replace("id","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote)));
					continue;
				}
				if (clause.Trim().StartsWith("changestamp ") || clause.Trim().StartsWith("changestamp="))
				{
					database.SetParameterValue(commandWrapper, "@ChangeStamp", 
						clause.Replace("changestamp","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("priority ") || clause.Trim().StartsWith("priority="))
				{
					database.SetParameterValue(commandWrapper, "@Priority", 
						clause.Replace("priority","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("status ") || clause.Trim().StartsWith("status="))
				{
					database.SetParameterValue(commandWrapper, "@Status", 
						clause.Replace("status","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("numberofretry ") || clause.Trim().StartsWith("numberofretry="))
				{
					database.SetParameterValue(commandWrapper, "@NumberOfRetry", 
						clause.Replace("numberofretry","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("retrytime ") || clause.Trim().StartsWith("retrytime="))
				{
					database.SetParameterValue(commandWrapper, "@RetryTime", 
						clause.Replace("retrytime","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("maximumretry ") || clause.Trim().StartsWith("maximumretry="))
				{
					database.SetParameterValue(commandWrapper, "@MaximumRetry", 
						clause.Replace("maximumretry","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("expirydatetime ") || clause.Trim().StartsWith("expirydatetime="))
				{
					database.SetParameterValue(commandWrapper, "@ExpiryDatetime", 
						clause.Replace("expirydatetime","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("arriveddatetime ") || clause.Trim().StartsWith("arriveddatetime="))
				{
					database.SetParameterValue(commandWrapper, "@ArrivedDateTime", 
						clause.Replace("arriveddatetime","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("senderinfo ") || clause.Trim().StartsWith("senderinfo="))
				{
					database.SetParameterValue(commandWrapper, "@SenderInfo", 
						clause.Replace("senderinfo","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("emailto ") || clause.Trim().StartsWith("emailto="))
				{
					database.SetParameterValue(commandWrapper, "@EmailTo", 
						clause.Replace("emailto","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("emailfrom ") || clause.Trim().StartsWith("emailfrom="))
				{
					database.SetParameterValue(commandWrapper, "@EmailFrom", 
						clause.Replace("emailfrom","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("emailsubject ") || clause.Trim().StartsWith("emailsubject="))
				{
					database.SetParameterValue(commandWrapper, "@EmailSubject", 
						clause.Replace("emailsubject","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("emailbody ") || clause.Trim().StartsWith("emailbody="))
				{
					database.SetParameterValue(commandWrapper, "@EmailBody", 
						clause.Replace("emailbody","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("emailcc ") || clause.Trim().StartsWith("emailcc="))
				{
					database.SetParameterValue(commandWrapper, "@EmailCC", 
						clause.Replace("emailcc","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("emailbcc ") || clause.Trim().StartsWith("emailbcc="))
				{
					database.SetParameterValue(commandWrapper, "@EmailBCC", 
						clause.Replace("emailbcc","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("ishtml ") || clause.Trim().StartsWith("ishtml="))
				{
					database.SetParameterValue(commandWrapper, "@IsHtml", 
						clause.Replace("ishtml","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
	
				throw new ArgumentException("Unable to use this part of the where clause in this version of Find: " + clause);
			}
					
			IDataReader reader = null;
			//Create Collection
			SmartMassEmail.Entities.TList<EmailMessage> rows = new SmartMassEmail.Entities.TList<EmailMessage>();
	
				
			try
			{
				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}		
				
				Fill(reader, rows, start, pageLength);
				
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
			}
			finally
			{
				if (reader != null) 
					reader.Close();				
			}
			return rows;
		}
		
		#endregion "Find Functions"
	
		#region GetList Functions
				
		/// <summary>
		/// 	Gets All rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of SmartMassEmail.Entities.EmailMessage objects.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override SmartMassEmail.Entities.TList<EmailMessage> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.EmailMessage_Get_List", _useStoredProcedure);
			
			IDataReader reader = null;
		
			//Create Collection
			SmartMassEmail.Entities.TList<EmailMessage> rows = new SmartMassEmail.Entities.TList<EmailMessage>();
			
			try
			{
				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}		
		
				Fill(reader, rows, start, pageLength);
				count = -1;
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
			}
			finally 
			{
				if (reader != null) 
					reader.Close();
			}
			return rows;
		}//end getall
		
		#endregion
				
		#region Paged Recordset
				
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of SmartMassEmail.Entities.EmailMessage objects.</returns>
		public override SmartMassEmail.Entities.TList<EmailMessage> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.EmailMessage_GetPaged", _useStoredProcedure);
			
			database.AddInParameter(commandWrapper, "@WhereClause", DbType.String, whereClause);
			database.AddInParameter(commandWrapper, "@OrderBy", DbType.String, orderBy);
			database.AddInParameter(commandWrapper, "@PageIndex", DbType.Int32, start);
			database.AddInParameter(commandWrapper, "@PageSize", DbType.Int32, pageLength);
		
			IDataReader reader = null;
			//Create Collection
			SmartMassEmail.Entities.TList<EmailMessage> rows = new SmartMassEmail.Entities.TList<EmailMessage>();
			
			try
			{
				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}
				
				Fill(reader, rows, 0, int.MaxValue);
				count = rows.Count;

				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
			}
			catch(Exception)
			{			
				throw;
			}
			finally
			{
				if (reader != null) 
					reader.Close();
			}
			
			return rows;
		}
		
		#endregion	
		
		#region Get By Foreign Key Functions
	#endregion
	
		#region Get By Index Functions

		#region GetByID
					
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmailMessage index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <returns>Returns an instance of the <see cref="SmartMassEmail.Entities.EmailMessage"/> class.</returns>
		/// <remarks></remarks>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override SmartMassEmail.Entities.EmailMessage GetByID(TransactionManager transactionManager, System.Guid id, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.EmailMessage_GetByID", _useStoredProcedure);
			
				database.AddInParameter(commandWrapper, "@ID", DbType.Guid, id);
			
			IDataReader reader = null;
			SmartMassEmail.Entities.TList<EmailMessage> tmp = new SmartMassEmail.Entities.TList<EmailMessage>();
			try
			{
				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}		
		
				//Create collection and fill
				Fill(reader, tmp, start, pageLength);
				count = -1;
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
			}
			finally 
			{
				if (reader != null) 
					reader.Close();
			}
			
			if (tmp.Count == 1)
			{
				return tmp[0];
			}
			else if (tmp.Count == 0)
			{
				return null;
			}
			else
			{
				throw new DataException("Cannot find the unique instance of the class.");
			}
			
			//return rows;
		}
		
		#endregion

	#endregion Get By Index Functions

		#region Insert Functions
		/// <summary>
		/// Lets you efficiently bulk many entity to the database.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entities">The entities.</param>
		/// <remarks>
		///		After inserting into the datasource, the SmartMassEmail.Entities.EmailMessage object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		public override void BulkInsert(TransactionManager transactionManager, TList<SmartMassEmail.Entities.EmailMessage> entities)
		{
			//System.Data.SqlClient.SqlBulkCopy bulkCopy = new System.Data.SqlClient.SqlBulkCopy(this._connectionString, System.Data.SqlClient.SqlBulkCopyOptions.CheckConstraints); //, null);
			
			System.Data.SqlClient.SqlBulkCopy bulkCopy = null;
	
			if (transactionManager != null && transactionManager.IsOpen)
			{			
				System.Data.SqlClient.SqlConnection cnx = transactionManager.TransactionObject.Connection as System.Data.SqlClient.SqlConnection;
				System.Data.SqlClient.SqlTransaction transaction = transactionManager.TransactionObject as System.Data.SqlClient.SqlTransaction;
				bulkCopy = new System.Data.SqlClient.SqlBulkCopy(cnx, System.Data.SqlClient.SqlBulkCopyOptions.CheckConstraints, transaction); //, null);
			}
			else
			{
				bulkCopy = new System.Data.SqlClient.SqlBulkCopy(this._connectionString, System.Data.SqlClient.SqlBulkCopyOptions.CheckConstraints); //, null);
			}
			
			bulkCopy.BulkCopyTimeout = 360;
			bulkCopy.DestinationTableName = "EmailMessage";
			
			DataTable dataTable = new DataTable();
			DataColumn col0 = dataTable.Columns.Add("ID", typeof(System.Guid));
			col0.AllowDBNull = false;		
			DataColumn col1 = dataTable.Columns.Add("ChangeStamp", typeof(System.DateTime));
			col1.AllowDBNull = false;		
			DataColumn col2 = dataTable.Columns.Add("Priority", typeof(System.Int32));
			col2.AllowDBNull = false;		
			DataColumn col3 = dataTable.Columns.Add("Status", typeof(System.Int32));
			col3.AllowDBNull = false;		
			DataColumn col4 = dataTable.Columns.Add("NumberOfRetry", typeof(System.Int32));
			col4.AllowDBNull = false;		
			DataColumn col5 = dataTable.Columns.Add("RetryTime", typeof(System.DateTime));
			col5.AllowDBNull = false;		
			DataColumn col6 = dataTable.Columns.Add("MaximumRetry", typeof(System.Int32));
			col6.AllowDBNull = false;		
			DataColumn col7 = dataTable.Columns.Add("ExpiryDatetime", typeof(System.DateTime));
			col7.AllowDBNull = false;		
			DataColumn col8 = dataTable.Columns.Add("ArrivedDateTime", typeof(System.DateTime));
			col8.AllowDBNull = false;		
			DataColumn col9 = dataTable.Columns.Add("SenderInfo", typeof(System.String));
			col9.AllowDBNull = false;		
			DataColumn col10 = dataTable.Columns.Add("EmailTo", typeof(System.String));
			col10.AllowDBNull = false;		
			DataColumn col11 = dataTable.Columns.Add("EmailFrom", typeof(System.String));
			col11.AllowDBNull = false;		
			DataColumn col12 = dataTable.Columns.Add("EmailSubject", typeof(System.String));
			col12.AllowDBNull = false;		
			DataColumn col13 = dataTable.Columns.Add("EmailBody", typeof(System.String));
			col13.AllowDBNull = false;		
			DataColumn col14 = dataTable.Columns.Add("EmailCC", typeof(System.String));
			col14.AllowDBNull = false;		
			DataColumn col15 = dataTable.Columns.Add("EmailBCC", typeof(System.String));
			col15.AllowDBNull = false;		
			DataColumn col16 = dataTable.Columns.Add("IsHtml", typeof(System.Boolean));
			col16.AllowDBNull = false;		
			
			bulkCopy.ColumnMappings.Add("ID", "ID");
			bulkCopy.ColumnMappings.Add("ChangeStamp", "ChangeStamp");
			bulkCopy.ColumnMappings.Add("Priority", "Priority");
			bulkCopy.ColumnMappings.Add("Status", "Status");
			bulkCopy.ColumnMappings.Add("NumberOfRetry", "NumberOfRetry");
			bulkCopy.ColumnMappings.Add("RetryTime", "RetryTime");
			bulkCopy.ColumnMappings.Add("MaximumRetry", "MaximumRetry");
			bulkCopy.ColumnMappings.Add("ExpiryDatetime", "ExpiryDatetime");
			bulkCopy.ColumnMappings.Add("ArrivedDateTime", "ArrivedDateTime");
			bulkCopy.ColumnMappings.Add("SenderInfo", "SenderInfo");
			bulkCopy.ColumnMappings.Add("EmailTo", "EmailTo");
			bulkCopy.ColumnMappings.Add("EmailFrom", "EmailFrom");
			bulkCopy.ColumnMappings.Add("EmailSubject", "EmailSubject");
			bulkCopy.ColumnMappings.Add("EmailBody", "EmailBody");
			bulkCopy.ColumnMappings.Add("EmailCC", "EmailCC");
			bulkCopy.ColumnMappings.Add("EmailBCC", "EmailBCC");
			bulkCopy.ColumnMappings.Add("IsHtml", "IsHtml");
			
			foreach(SmartMassEmail.Entities.EmailMessage entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
					
				DataRow row = dataTable.NewRow();
				
					row["ID"] = entity.ID;
							
				
					row["ChangeStamp"] = entity.ChangeStamp;
							
				
					row["Priority"] = entity.Priority;
							
				
					row["Status"] = entity.Status;
							
				
					row["NumberOfRetry"] = entity.NumberOfRetry;
							
				
					row["RetryTime"] = entity.RetryTime;
							
				
					row["MaximumRetry"] = entity.MaximumRetry;
							
				
					row["ExpiryDatetime"] = entity.ExpiryDatetime;
							
				
					row["ArrivedDateTime"] = entity.ArrivedDateTime;
							
				
					row["SenderInfo"] = entity.SenderInfo;
							
				
					row["EmailTo"] = entity.EmailTo;
							
				
					row["EmailFrom"] = entity.EmailFrom;
							
				
					row["EmailSubject"] = entity.EmailSubject;
							
				
					row["EmailBody"] = entity.EmailBody;
							
				
					row["EmailCC"] = entity.EmailCC;
							
				
					row["EmailBCC"] = entity.EmailBCC;
							
				
					row["IsHtml"] = entity.IsHtml;
							
				
				dataTable.Rows.Add(row);
			}		
			
			// send the data to the server		
			bulkCopy.WriteToServer(dataTable);		
			
			// update back the state
			foreach(SmartMassEmail.Entities.EmailMessage entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
			
				entity.AcceptChanges();
			}
		}
				
		/// <summary>
		/// 	Inserts a SmartMassEmail.Entities.EmailMessage object into the datasource using a transaction.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">SmartMassEmail.Entities.EmailMessage object to insert.</param>
		/// <remarks>
		///		After inserting into the datasource, the SmartMassEmail.Entities.EmailMessage object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Insert(TransactionManager transactionManager, SmartMassEmail.Entities.EmailMessage entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.EmailMessage_Insert", _useStoredProcedure);
			
			database.AddInParameter(commandWrapper, "@ID", DbType.Guid, entity.ID );
			database.AddInParameter(commandWrapper, "@ChangeStamp", DbType.DateTime, entity.ChangeStamp );
			database.AddInParameter(commandWrapper, "@Priority", DbType.Int32, entity.Priority );
			database.AddInParameter(commandWrapper, "@Status", DbType.Int32, entity.Status );
			database.AddInParameter(commandWrapper, "@NumberOfRetry", DbType.Int32, entity.NumberOfRetry );
			database.AddInParameter(commandWrapper, "@RetryTime", DbType.DateTime, entity.RetryTime );
			database.AddInParameter(commandWrapper, "@MaximumRetry", DbType.Int32, entity.MaximumRetry );
			database.AddInParameter(commandWrapper, "@ExpiryDatetime", DbType.DateTime, entity.ExpiryDatetime );
			database.AddInParameter(commandWrapper, "@ArrivedDateTime", DbType.DateTime, entity.ArrivedDateTime );
			database.AddInParameter(commandWrapper, "@SenderInfo", DbType.AnsiString, entity.SenderInfo );
			database.AddInParameter(commandWrapper, "@EmailTo", DbType.AnsiString, entity.EmailTo );
			database.AddInParameter(commandWrapper, "@EmailFrom", DbType.AnsiString, entity.EmailFrom );
            database.AddInParameter(commandWrapper, "@EmailSubject", SqlDbType.NVarChar, entity.EmailSubject);
            database.AddInParameter(commandWrapper, "@EmailBody", SqlDbType.NText, entity.EmailBody );
			database.AddInParameter(commandWrapper, "@EmailCC", DbType.AnsiString, entity.EmailCC );
			database.AddInParameter(commandWrapper, "@EmailBCC", DbType.AnsiString, entity.EmailBCC );
			database.AddInParameter(commandWrapper, "@IsHtml", DbType.Boolean, entity.IsHtml );
			
			int results = 0;
			
				
			if (transactionManager != null)
			{
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}
					
			
			entity.OriginalID = entity.ID;
			
			entity.AcceptChanges();
	
			return Convert.ToBoolean(results);
		}	
		#endregion

		#region Update Functions
				
		/// <summary>
		/// 	Update an existing row in the datasource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">SmartMassEmail.Entities.EmailMessage object to update.</param>
		/// <remarks>
		///		After updating the datasource, the SmartMassEmail.Entities.EmailMessage object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Update(TransactionManager transactionManager, SmartMassEmail.Entities.EmailMessage entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.EmailMessage_Update", _useStoredProcedure);
			
			database.AddInParameter(commandWrapper, "@ID", DbType.Guid, entity.ID );
			database.AddInParameter(commandWrapper, "@OriginalID", DbType.Guid, entity.OriginalID);
			database.AddInParameter(commandWrapper, "@ChangeStamp", DbType.DateTime, entity.ChangeStamp );
			database.AddInParameter(commandWrapper, "@Priority", DbType.Int32, entity.Priority );
			database.AddInParameter(commandWrapper, "@Status", DbType.Int32, entity.Status );
			database.AddInParameter(commandWrapper, "@NumberOfRetry", DbType.Int32, entity.NumberOfRetry );
			database.AddInParameter(commandWrapper, "@RetryTime", DbType.DateTime, entity.RetryTime );
			database.AddInParameter(commandWrapper, "@MaximumRetry", DbType.Int32, entity.MaximumRetry );
			database.AddInParameter(commandWrapper, "@ExpiryDatetime", DbType.DateTime, entity.ExpiryDatetime );
			database.AddInParameter(commandWrapper, "@ArrivedDateTime", DbType.DateTime, entity.ArrivedDateTime );
			database.AddInParameter(commandWrapper, "@SenderInfo", DbType.AnsiString, entity.SenderInfo );
			database.AddInParameter(commandWrapper, "@EmailTo", DbType.AnsiString, entity.EmailTo );
			database.AddInParameter(commandWrapper, "@EmailFrom", DbType.AnsiString, entity.EmailFrom );
            database.AddInParameter(commandWrapper, "@EmailSubject", SqlDbType.NVarChar, entity.EmailSubject);
			database.AddInParameter(commandWrapper, "@EmailBody", SqlDbType.NText, entity.EmailBody );
			database.AddInParameter(commandWrapper, "@EmailCC", DbType.AnsiString, entity.EmailCC );
			database.AddInParameter(commandWrapper, "@EmailBCC", DbType.AnsiString, entity.EmailBCC );
			database.AddInParameter(commandWrapper, "@IsHtml", DbType.Boolean, entity.IsHtml );
			
			int results = 0;
			
			
			if (transactionManager != null)
			{
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}
			
			//Stop Tracking Now that it has been updated and persisted.
			if (DataRepository.Provider.EnableEntityTracking)
				EntityManager.StopTracking(entity.EntityTrackingKey);
			
			entity.OriginalID = entity.ID;
			
			entity.AcceptChanges();
	
			return Convert.ToBoolean(results);
		}
			
		#endregion
		
		#region Custom Methods
	
		#region _EmailMessage_GetPendingEmailMessage
					
		/// <summary>
		///	This method wrap the '_EmailMessage_GetPendingEmailMessage' stored procedure. 
		/// </summary>	
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="SmartMassEmail.Entities.TList&lt;EmailMessage&gt;"/> instance.</returns>
		public override SmartMassEmail.Entities.TList<EmailMessage> GetPendingEmailMessage(TransactionManager transactionManager, int start, int pageLength )
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = database.GetStoredProcCommand("_EmailMessage_GetPendingEmailMessage");
			
	
			
			IDataReader reader = null;

			if (transactionManager != null)
			{	
				reader = Utility.ExecuteReader(transactionManager, commandWrapper);
			}
			else
			{
				reader = Utility.ExecuteReader(database, commandWrapper);
			}			
			
			//Create Collection
				SmartMassEmail.Entities.TList<EmailMessage> rows = new SmartMassEmail.Entities.TList<EmailMessage>();
				try
				{    
					Fill(reader, rows, start, pageLength);
				}
				finally
				{
					if (reader != null) 
						reader.Close();
				}

				return rows;
		}
		#endregion
		#endregion
	}//end class
} // end namespace

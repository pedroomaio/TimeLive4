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
	/// This class is the base class for any <see cref="EmailMessageProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class EmailMessageProviderBaseCore : EntityProviderBase<SmartMassEmail.Entities.EmailMessage, SmartMassEmail.Entities.EmailMessageKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Functions

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, SmartMassEmail.Entities.EmailMessageKey key)
		{
			return Delete(transactionManager, key.ID);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Guid id)
		{
			return Delete(null, id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Guid id);		
		
		#endregion
		
		#region Get By Foreign Key Functions
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override SmartMassEmail.Entities.EmailMessage Get(TransactionManager transactionManager, SmartMassEmail.Entities.EmailMessageKey key, int start, int pageLength)
		{
			return GetByID(transactionManager, key.ID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_EmailMessage index.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Returns an instance of the <see cref="SmartMassEmail.Entities.EmailMessage"/> class.</returns>
		public SmartMassEmail.Entities.EmailMessage GetByID(System.Guid id)
		{
			int count = -1;
			return GetByID(null,id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmailMessage index.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SmartMassEmail.Entities.EmailMessage"/> class.</returns>
		public SmartMassEmail.Entities.EmailMessage GetByID(System.Guid id, int start, int pageLength)
		{
			int count = -1;
			return GetByID(null, id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmailMessage index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SmartMassEmail.Entities.EmailMessage"/> class.</returns>
		public SmartMassEmail.Entities.EmailMessage GetByID(TransactionManager transactionManager, System.Guid id)
		{
			int count = -1;
			return GetByID(transactionManager, id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmailMessage index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SmartMassEmail.Entities.EmailMessage"/> class.</returns>
		public SmartMassEmail.Entities.EmailMessage GetByID(TransactionManager transactionManager, System.Guid id, int start, int pageLength)
		{
			int count = -1;
			return GetByID(transactionManager, id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmailMessage index.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SmartMassEmail.Entities.EmailMessage"/> class.</returns>
		public SmartMassEmail.Entities.EmailMessage GetByID(System.Guid id, int start, int pageLength, out int count)
		{
			return GetByID(null, id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmailMessage index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="SmartMassEmail.Entities.EmailMessage"/> class.</returns>
		public abstract SmartMassEmail.Entities.EmailMessage GetByID(TransactionManager transactionManager, System.Guid id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		#region _EmailMessage_GetPendingEmailMessage 
		
		/// <summary>
		///	This method wrap the '_EmailMessage_GetPendingEmailMessage' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="SmartMassEmail.Entities.TList&lt;EmailMessage&gt;"/> instance.</returns>
		public SmartMassEmail.Entities.TList<EmailMessage> GetPendingEmailMessage()
		{
			return GetPendingEmailMessage(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the '_EmailMessage_GetPendingEmailMessage' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="SmartMassEmail.Entities.TList&lt;EmailMessage&gt;"/> instance.</returns>
		public SmartMassEmail.Entities.TList<EmailMessage> GetPendingEmailMessage(int start, int pageLength)
		{
			return GetPendingEmailMessage(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the '_EmailMessage_GetPendingEmailMessage' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <returns>A <see cref="SmartMassEmail.Entities.TList&lt;EmailMessage&gt;"/> instance.</returns>
		public SmartMassEmail.Entities.TList<EmailMessage> GetPendingEmailMessage(TransactionManager transactionManager)
		{
			return GetPendingEmailMessage(0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the '_EmailMessage_GetPendingEmailMessage' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="SmartMassEmail.Entities.TList&lt;EmailMessage&gt;"/> instance.</returns>
		public abstract SmartMassEmail.Entities.TList<EmailMessage> GetPendingEmailMessage(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a SmartMassEmail.Entities.TList&lt;EmailMessage&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="SmartMassEmail.Entities.TList&lt;EmailMessage&gt;"/></returns>
		public static SmartMassEmail.Entities.TList<EmailMessage> Fill(IDataReader reader, SmartMassEmail.Entities.TList<EmailMessage> rows, int start, int pageLength)
		{
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
					return rows; // not enough rows, just return
			}

			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done

				string key = null;
				
				SmartMassEmail.Entities.EmailMessage c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"EmailMessage" 
							+ (reader.IsDBNull(reader.GetOrdinal("ID"))?Guid.Empty:(System.Guid)reader["ID"]).ToString();

					c = EntityManager.LocateOrCreate<EmailMessage>(
						key.ToString(), // EntityTrackingKey 
						"EmailMessage",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new SmartMassEmail.Entities.EmailMessage();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ID = (System.Guid)reader["ID"];
					c.OriginalID = c.ID; //(reader.IsDBNull(reader.GetOrdinal("ID")))?Guid.Empty:(System.Guid)reader["ID"];
					c.ChangeStamp = (System.DateTime)reader["ChangeStamp"];
					c.Priority = (System.Int32)reader["Priority"];
					c.Status = (System.Int32)reader["Status"];
					c.NumberOfRetry = (System.Int32)reader["NumberOfRetry"];
					c.RetryTime = (System.DateTime)reader["RetryTime"];
					c.MaximumRetry = (System.Int32)reader["MaximumRetry"];
					c.ExpiryDatetime = (System.DateTime)reader["ExpiryDatetime"];
					c.ArrivedDateTime = (System.DateTime)reader["ArrivedDateTime"];
					c.SenderInfo = (System.String)reader["SenderInfo"];
					c.EmailTo = (System.String)reader["EmailTo"];
					c.EmailFrom = (System.String)reader["EmailFrom"];
					c.EmailSubject = (System.String)reader["EmailSubject"];
					c.EmailBody = (System.String)reader["EmailBody"];
					c.EmailCC = (System.String)reader["EmailCC"];
					c.EmailBCC = (System.String)reader["EmailBCC"];
					c.IsHtml = (System.Boolean)reader["IsHtml"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="SmartMassEmail.Entities.EmailMessage"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="SmartMassEmail.Entities.EmailMessage"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, SmartMassEmail.Entities.EmailMessage entity)
		{
			if (!reader.Read()) return;
			
			entity.ID = (System.Guid)reader["ID"];
			entity.OriginalID = (System.Guid)reader["ID"];
			entity.ChangeStamp = (System.DateTime)reader["ChangeStamp"];
			entity.Priority = (System.Int32)reader["Priority"];
			entity.Status = (System.Int32)reader["Status"];
			entity.NumberOfRetry = (System.Int32)reader["NumberOfRetry"];
			entity.RetryTime = (System.DateTime)reader["RetryTime"];
			entity.MaximumRetry = (System.Int32)reader["MaximumRetry"];
			entity.ExpiryDatetime = (System.DateTime)reader["ExpiryDatetime"];
			entity.ArrivedDateTime = (System.DateTime)reader["ArrivedDateTime"];
			entity.SenderInfo = (System.String)reader["SenderInfo"];
			entity.EmailTo = (System.String)reader["EmailTo"];
			entity.EmailFrom = (System.String)reader["EmailFrom"];
			entity.EmailSubject = (System.String)reader["EmailSubject"];
			entity.EmailBody = (System.String)reader["EmailBody"];
			entity.EmailCC = (System.String)reader["EmailCC"];
			entity.EmailBCC = (System.String)reader["EmailBCC"];
			entity.IsHtml = (System.Boolean)reader["IsHtml"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="SmartMassEmail.Entities.EmailMessage"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="SmartMassEmail.Entities.EmailMessage"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, SmartMassEmail.Entities.EmailMessage entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ID = (System.Guid)dataRow["ID"];
			entity.OriginalID = (System.Guid)dataRow["ID"];
			entity.ChangeStamp = (System.DateTime)dataRow["ChangeStamp"];
			entity.Priority = (System.Int32)dataRow["Priority"];
			entity.Status = (System.Int32)dataRow["Status"];
			entity.NumberOfRetry = (System.Int32)dataRow["NumberOfRetry"];
			entity.RetryTime = (System.DateTime)dataRow["RetryTime"];
			entity.MaximumRetry = (System.Int32)dataRow["MaximumRetry"];
			entity.ExpiryDatetime = (System.DateTime)dataRow["ExpiryDatetime"];
			entity.ArrivedDateTime = (System.DateTime)dataRow["ArrivedDateTime"];
			entity.SenderInfo = (System.String)dataRow["SenderInfo"];
			entity.EmailTo = (System.String)dataRow["EmailTo"];
			entity.EmailFrom = (System.String)dataRow["EmailFrom"];
			entity.EmailSubject = (System.String)dataRow["EmailSubject"];
			entity.EmailBody = (System.String)dataRow["EmailBody"];
			entity.EmailCC = (System.String)dataRow["EmailCC"];
			entity.EmailBCC = (System.String)dataRow["EmailBCC"];
			entity.IsHtml = (System.Boolean)dataRow["IsHtml"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="SmartMassEmail.Entities.EmailMessage"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">SmartMassEmail.Entities.EmailMessage Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, SmartMassEmail.Entities.EmailMessage entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;
			
			// Load Entity through Provider
			// Deep load child collections  - Call GetByID methods when available
			
			#region EmailMessageDetailCollection
			//Relationship Type One : Many
			if (CanDeepLoad(entity, "List<EmailMessageDetail>", "EmailMessageDetailCollection", deepLoadType, innerList)) 
			{
				#if NETTIERS_DEBUG
				Debug.WriteLine("- property 'EmailMessageDetailCollection' loaded.");
				#endif 

				entity.EmailMessageDetailCollection = DataRepository.EmailMessageDetailProvider.GetByEmailMessageID(transactionManager, entity.ID);

				if (deep && entity.EmailMessageDetailCollection.Count > 0)
				{
					DataRepository.EmailMessageDetailProvider.DeepLoad(transactionManager, entity.EmailMessageDetailCollection, deep, deepLoadType, childTypes, innerList);
				}
			}		
			#endregion 
		}
		
		#endregion 
		
		#region DeepSave

		/// <summary>
		/// Deep Save the entire object graph of the SmartMassEmail.Entities.EmailMessage object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">SmartMassEmail.Entities.EmailMessage instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">SmartMassEmail.Entities.EmailMessage Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override void DeepSave(TransactionManager transactionManager, SmartMassEmail.Entities.EmailMessage entity, DeepSaveType deepSaveType, System.Type[] childTypes, Hashtable innerList)
		{	
			if (entity == null)
				return;
				
			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			#region Composite Source Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			#endregion Composite Source Properties


			#region List<EmailMessageDetail>
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["List<EmailMessageDetail>"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList["List<EmailMessageDetail>"] == null))
			{
			// update each child parent id with the real parent id (mostly used on insert)
			foreach(EmailMessageDetail child in entity.EmailMessageDetailCollection)
			{
					child.EmailMessageID = entity.ID;			}
			
			if (entity.EmailMessageDetailCollection.Count > 0)
				DataRepository.EmailMessageDetailProvider.DeepSave(transactionManager, entity.EmailMessageDetailCollection, deepSaveType, childTypes);
			} 
			#endregion 
		}
		#endregion
	} // end class
	
	#region EmailMessageChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>SmartMassEmail.Entities.EmailMessage</c>
	///</summary>
	public enum EmailMessageChildEntityTypes
	{

		///<summary>
		/// Collection of <c>EmailMessage</c> as OneToMany for EmailMessageDetailCollection
		///</summary>
		[ChildEntityType(typeof(TList<EmailMessageDetail>))]
		EmailMessageDetailCollection,
	}
	
	#endregion EmailMessageChildEntityTypes
	
	#region EmailMessageFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmailMessage"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailMessageFilterBuilder : SqlFilterBuilder<EmailMessageColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailMessageFilterBuilder class.
		/// </summary>
		public EmailMessageFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmailMessageFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmailMessageFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmailMessageFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmailMessageFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmailMessageFilterBuilder
} // end namespace

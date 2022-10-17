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
	public abstract partial class EmailMessageDetailProviderBaseCore : EntityProviderBase<SmartMassEmail.Entities.EmailMessageDetail, SmartMassEmail.Entities.EmailMessageDetailKey>
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
		public override bool Delete(TransactionManager transactionManager, SmartMassEmail.Entities.EmailMessageDetailKey key)
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
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmailMessageDetail_EmailMessage key.
		///		FK_EmailMessageDetail_EmailMessage Description: 
		/// </summary>
		/// <param name="emailMessageID"></param>
		/// <returns>Returns a typed collection of SmartMassEmail.Entities.EmailMessageDetail objects.</returns>
		public SmartMassEmail.Entities.TList<EmailMessageDetail> GetByEmailMessageID(System.Guid emailMessageID)
		{
			int count = -1;
			return GetByEmailMessageID(emailMessageID, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmailMessageDetail_EmailMessage key.
		///		FK_EmailMessageDetail_EmailMessage Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="emailMessageID"></param>
		/// <returns>Returns a typed collection of SmartMassEmail.Entities.EmailMessageDetail objects.</returns>
		/// <remarks></remarks>
		public SmartMassEmail.Entities.TList<EmailMessageDetail> GetByEmailMessageID(TransactionManager transactionManager, System.Guid emailMessageID)
		{
			int count = -1;
			return GetByEmailMessageID(transactionManager, emailMessageID, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmailMessageDetail_EmailMessage key.
		///		FK_EmailMessageDetail_EmailMessage Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="emailMessageID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of SmartMassEmail.Entities.EmailMessageDetail objects.</returns>
		public SmartMassEmail.Entities.TList<EmailMessageDetail> GetByEmailMessageID(TransactionManager transactionManager, System.Guid emailMessageID, int start, int pageLength)
		{
			int count = -1;
			return GetByEmailMessageID(transactionManager, emailMessageID, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmailMessageDetail_EmailMessage key.
		///		fK_EmailMessageDetail_EmailMessage Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="emailMessageID"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of SmartMassEmail.Entities.EmailMessageDetail objects.</returns>
		public SmartMassEmail.Entities.TList<EmailMessageDetail> GetByEmailMessageID(System.Guid emailMessageID, int start, int pageLength)
		{
			int count =  -1;
			return GetByEmailMessageID(null, emailMessageID, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmailMessageDetail_EmailMessage key.
		///		fK_EmailMessageDetail_EmailMessage Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="emailMessageID"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of SmartMassEmail.Entities.EmailMessageDetail objects.</returns>
		public SmartMassEmail.Entities.TList<EmailMessageDetail> GetByEmailMessageID(System.Guid emailMessageID, int start, int pageLength,out int count)
		{
			return GetByEmailMessageID(null, emailMessageID, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_EmailMessageDetail_EmailMessage key.
		///		FK_EmailMessageDetail_EmailMessage Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="emailMessageID"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of SmartMassEmail.Entities.EmailMessageDetail objects.</returns>
		public abstract SmartMassEmail.Entities.TList<EmailMessageDetail> GetByEmailMessageID(TransactionManager transactionManager, System.Guid emailMessageID, int start, int pageLength, out int count);
		
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
		public override SmartMassEmail.Entities.EmailMessageDetail Get(TransactionManager transactionManager, SmartMassEmail.Entities.EmailMessageDetailKey key, int start, int pageLength)
		{
			return GetByID(transactionManager, key.ID, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK_EmailMessageDetail index.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Returns an instance of the <see cref="SmartMassEmail.Entities.EmailMessageDetail"/> class.</returns>
		public SmartMassEmail.Entities.EmailMessageDetail GetByID(System.Guid id)
		{
			int count = -1;
			return GetByID(null,id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmailMessageDetail index.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SmartMassEmail.Entities.EmailMessageDetail"/> class.</returns>
		public SmartMassEmail.Entities.EmailMessageDetail GetByID(System.Guid id, int start, int pageLength)
		{
			int count = -1;
			return GetByID(null, id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmailMessageDetail index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SmartMassEmail.Entities.EmailMessageDetail"/> class.</returns>
		public SmartMassEmail.Entities.EmailMessageDetail GetByID(TransactionManager transactionManager, System.Guid id)
		{
			int count = -1;
			return GetByID(transactionManager, id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmailMessageDetail index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SmartMassEmail.Entities.EmailMessageDetail"/> class.</returns>
		public SmartMassEmail.Entities.EmailMessageDetail GetByID(TransactionManager transactionManager, System.Guid id, int start, int pageLength)
		{
			int count = -1;
			return GetByID(transactionManager, id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmailMessageDetail index.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="SmartMassEmail.Entities.EmailMessageDetail"/> class.</returns>
		public SmartMassEmail.Entities.EmailMessageDetail GetByID(System.Guid id, int start, int pageLength, out int count)
		{
			return GetByID(null, id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_EmailMessageDetail index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="SmartMassEmail.Entities.EmailMessageDetail"/> class.</returns>
		public abstract SmartMassEmail.Entities.EmailMessageDetail GetByID(TransactionManager transactionManager, System.Guid id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a SmartMassEmail.Entities.TList&lt;EmailMessageDetail&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="SmartMassEmail.Entities.TList&lt;EmailMessageDetail&gt;"/></returns>
		public static SmartMassEmail.Entities.TList<EmailMessageDetail> Fill(IDataReader reader, SmartMassEmail.Entities.TList<EmailMessageDetail> rows, int start, int pageLength)
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
				
				SmartMassEmail.Entities.EmailMessageDetail c = null;
				if (DataRepository.Provider.UseEntityFactory)
				{
					key = @"EmailMessageDetail" 
							+ (reader.IsDBNull(reader.GetOrdinal("ID"))?Guid.Empty:(System.Guid)reader["ID"]).ToString();

					c = EntityManager.LocateOrCreate<EmailMessageDetail>(
						key.ToString(), // EntityTrackingKey 
						"EmailMessageDetail",  //Creational Type
						DataRepository.Provider.EntityCreationalFactoryType,  //Factory used to create entity
						DataRepository.Provider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new SmartMassEmail.Entities.EmailMessageDetail();
				}
				
				if (!DataRepository.Provider.EnableEntityTracking || c.EntityState == EntityState.Added)
                {
					c.SuppressEntityEvents = true;
					c.ID = (System.Guid)reader["ID"];
					c.OriginalID = c.ID; //(reader.IsDBNull(reader.GetOrdinal("ID")))?Guid.Empty:(System.Guid)reader["ID"];
					c.ChangeStamp = (System.DateTime)reader["ChangeStamp"];
					c.IsBinary = (System.Int32)reader["IsBinary"];
					c.Name = (System.String)reader["Name"];
					c.BinaryData = (System.Byte[])reader["BinaryData"];
					c.StringData = (System.String)reader["StringData"];
					c.EmailMessageID = (System.Guid)reader["EmailMessageID"];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
			return rows;
		}
		
		/// <summary>
		/// Refreshes the <see cref="SmartMassEmail.Entities.EmailMessageDetail"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="SmartMassEmail.Entities.EmailMessageDetail"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, SmartMassEmail.Entities.EmailMessageDetail entity)
		{
			if (!reader.Read()) return;
			
			entity.ID = (System.Guid)reader["ID"];
			entity.OriginalID = (System.Guid)reader["ID"];
			entity.ChangeStamp = (System.DateTime)reader["ChangeStamp"];
			entity.IsBinary = (System.Int32)reader["IsBinary"];
			entity.Name = (System.String)reader["Name"];
			entity.BinaryData = (System.Byte[])reader["BinaryData"];
			entity.StringData = (System.String)reader["StringData"];
			entity.EmailMessageID = (System.Guid)reader["EmailMessageID"];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="SmartMassEmail.Entities.EmailMessageDetail"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="SmartMassEmail.Entities.EmailMessageDetail"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, SmartMassEmail.Entities.EmailMessageDetail entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ID = (System.Guid)dataRow["ID"];
			entity.OriginalID = (System.Guid)dataRow["ID"];
			entity.ChangeStamp = (System.DateTime)dataRow["ChangeStamp"];
			entity.IsBinary = (System.Int32)dataRow["IsBinary"];
			entity.Name = (System.String)dataRow["Name"];
			entity.BinaryData = (System.Byte[])dataRow["BinaryData"];
			entity.StringData = (System.String)dataRow["StringData"];
			entity.EmailMessageID = (System.Guid)dataRow["EmailMessageID"];
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
		/// <param name="entity">The <see cref="SmartMassEmail.Entities.EmailMessageDetail"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">SmartMassEmail.Entities.EmailMessageDetail Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, SmartMassEmail.Entities.EmailMessageDetail entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, ChildEntityTypesList innerList)
		{
			if(entity == null)
				return;

			#region EmailMessageIDSource	
			if (CanDeepLoad(entity, "EmailMessage", "EmailMessageIDSource", deepLoadType, innerList) 
				&& entity.EmailMessageIDSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.EmailMessageID;
				EmailMessage tmpEntity = EntityManager.LocateEntity<EmailMessage>(EntityLocator.ConstructKeyFromPkItems(typeof(EmailMessage), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.EmailMessageIDSource = tmpEntity;
				else
					entity.EmailMessageIDSource = DataRepository.EmailMessageProvider.GetByID(entity.EmailMessageID);
			
				if (deep && entity.EmailMessageIDSource != null)
				{
					DataRepository.EmailMessageProvider.DeepLoad(transactionManager, entity.EmailMessageIDSource, deep, deepLoadType, childTypes, innerList);
				}
			}
			#endregion EmailMessageIDSource
			
			// Load Entity through Provider
		}
		
		#endregion 
		
		#region DeepSave

		/// <summary>
		/// Deep Save the entire object graph of the SmartMassEmail.Entities.EmailMessageDetail object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">SmartMassEmail.Entities.EmailMessageDetail instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">SmartMassEmail.Entities.EmailMessageDetail Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override void DeepSave(TransactionManager transactionManager, SmartMassEmail.Entities.EmailMessageDetail entity, DeepSaveType deepSaveType, System.Type[] childTypes, Hashtable innerList)
		{	
			if (entity == null)
				return;
				
			// Save Root Entity through Provider
			this.Save(transactionManager, entity);
			
			#region Composite Source Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region EmailMessageIDSource
			if ((deepSaveType == DeepSaveType.IncludeChildren && innerList["EmailMessage"] != null)
				|| (deepSaveType == DeepSaveType.ExcludeChildren && innerList["EmailMessage"] == null))
			{
				if (entity.EmailMessageIDSource != null )
				{			
					DataRepository.EmailMessageProvider.Save(transactionManager, entity.EmailMessageIDSource);
				}
			}
			#endregion 
			#endregion Composite Source Properties

		}
		#endregion
	} // end class
	
	#region EmailMessageDetailChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>SmartMassEmail.Entities.EmailMessageDetail</c>
	///</summary>
	public enum EmailMessageDetailChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>EmailMessage</c> at EmailMessageIDSource
		///</summary>
		[ChildEntityType(typeof(EmailMessage))]
		EmailMessage,
		}
	
	#endregion EmailMessageDetailChildEntityTypes
	
	#region EmailMessageDetailFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmailMessageDetail"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailMessageDetailFilterBuilder : SqlFilterBuilder<EmailMessageDetailColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailMessageDetailFilterBuilder class.
		/// </summary>
		public EmailMessageDetailFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the EmailMessageDetailFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public EmailMessageDetailFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the EmailMessageDetailFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public EmailMessageDetailFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion EmailMessageDetailFilterBuilder
} // end namespace

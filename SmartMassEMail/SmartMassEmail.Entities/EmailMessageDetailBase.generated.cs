	
/*
	File generated by NetTiers templates [www.nettiers.com]
	Generated on : Friday, 1 September 2006
	Important: Do not modify this file. Edit the file EmailMessageDetail.cs instead.
*/

#region using directives

using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Runtime.Serialization;

#endregion

namespace SmartMassEmail.Entities
{
	#region EmailMessageDetailEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="EmailMessageDetail"/> object.
	/// </remarks>
	public class EmailMessageDetailEventArgs : System.EventArgs
	{
		private EmailMessageDetailColumn column;
		
		///<summary>
		/// Initalizes a new Instance of the EmailMessageDetailEventArgs class.
		///</summary>
		public EmailMessageDetailEventArgs(EmailMessageDetailColumn column)
		{
			this.column = column;
		}
		
		
		///<summary>
		/// The EmailMessageDetailColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="EmailMessageDetailColumn" />
		public EmailMessageDetailColumn Column { get { return this.column; } }
	}
	#endregion
	
	
	///<summary>
	/// Define a delegate for all EmailMessageDetail related events.
	///</summary>
	public delegate void EmailMessageDetailEventHandler(object sender, EmailMessageDetailEventArgs e);
	
	///<summary>
	/// An object representation of the 'EmailMessageDetail' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	//[ToolboxItem(typeof(EmailMessageDetail))]
	public abstract partial class EmailMessageDetailBase : EntityBase, IEntityId<EmailMessageDetailKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		/// 	Old the inner data of the entity.
		/// </summary>
		private EmailMessageDetailEntityData entityData;
		
		// <summary>
		// 	Old the original data of the entity.
		// </summary>
		//EmailMessageDetailEntityData originalData;
		
		/// <summary>
		/// 	Old a backup of the inner data of the entity.
		/// </summary>
		private EmailMessageDetailEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		[NonSerialized]
		private TList<EmailMessageDetail> parentCollection;
		private bool inTxn = false;

		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event EmailMessageDetailEventHandler ColumnChanging;
		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event EmailMessageDetailEventHandler ColumnChanged;		
		#endregion "Variable Declarations"
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="EmailMessageDetailBase"/> instance.
		///</summary>
		public EmailMessageDetailBase()
		{
			this.entityData = new EmailMessageDetailEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="EmailMessageDetailBase"/> instance.
		///</summary>
		///<param name="emailMessageDetailID"></param>
		///<param name="emailMessageDetailChangeStamp"></param>
		///<param name="emailMessageDetailIsBinary"></param>
		///<param name="emailMessageDetailName"></param>
		///<param name="emailMessageDetailBinaryData"></param>
		///<param name="emailMessageDetailStringData"></param>
		///<param name="emailMessageDetailEmailMessageID"></param>
		public EmailMessageDetailBase(System.Guid emailMessageDetailID, System.DateTime emailMessageDetailChangeStamp, 
			System.Int32 emailMessageDetailIsBinary, System.String emailMessageDetailName, System.Byte[] emailMessageDetailBinaryData, 
			System.String emailMessageDetailStringData, System.Guid emailMessageDetailEmailMessageID)
		{
			this.entityData = new EmailMessageDetailEntityData();
			this.backupData = null;

			this.ID = emailMessageDetailID;
			this.ChangeStamp = emailMessageDetailChangeStamp;
			this.IsBinary = emailMessageDetailIsBinary;
			this.Name = emailMessageDetailName;
			this.BinaryData = emailMessageDetailBinaryData;
			this.StringData = emailMessageDetailStringData;
			this.EmailMessageID = emailMessageDetailEmailMessageID;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="EmailMessageDetail"/> instance.
		///</summary>
		///<param name="emailMessageDetailID"></param>
		///<param name="emailMessageDetailChangeStamp"></param>
		///<param name="emailMessageDetailIsBinary"></param>
		///<param name="emailMessageDetailName"></param>
		///<param name="emailMessageDetailBinaryData"></param>
		///<param name="emailMessageDetailStringData"></param>
		///<param name="emailMessageDetailEmailMessageID"></param>
		public static EmailMessageDetail CreateEmailMessageDetail(System.Guid emailMessageDetailID, System.DateTime emailMessageDetailChangeStamp, 
			System.Int32 emailMessageDetailIsBinary, System.String emailMessageDetailName, System.Byte[] emailMessageDetailBinaryData, 
			System.String emailMessageDetailStringData, System.Guid emailMessageDetailEmailMessageID)
		{
			EmailMessageDetail newEmailMessageDetail = new EmailMessageDetail();
			newEmailMessageDetail.ID = emailMessageDetailID;
			newEmailMessageDetail.ChangeStamp = emailMessageDetailChangeStamp;
			newEmailMessageDetail.IsBinary = emailMessageDetailIsBinary;
			newEmailMessageDetail.Name = emailMessageDetailName;
			newEmailMessageDetail.BinaryData = emailMessageDetailBinaryData;
			newEmailMessageDetail.StringData = emailMessageDetailStringData;
			newEmailMessageDetail.EmailMessageID = emailMessageDetailEmailMessageID;
			return newEmailMessageDetail;
		}
				
		#endregion Constructors
		
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="EmailMessageDetailColumn"/> which has raised the event.</param>
		public void OnColumnChanging(EmailMessageDetailColumn column)
		{
			if(IsEntityTracked && EntityState != EntityState.Added)
				EntityManager.StopTracking(EntityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				EmailMessageDetailEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new EmailMessageDetailEventArgs(column));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="EmailMessageDetailColumn"/> which has raised the event.</param>
		public void OnColumnChanged(EmailMessageDetailColumn column)
		{
			if (!SuppressEntityEvents)
			{
				EmailMessageDetailEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new EmailMessageDetailEventArgs(column));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
				
		#region Properties	
				
		/// <summary>
		/// 	Gets or sets the ID property. 
		///		
		/// </summary>
		/// <value>This type is uniqueidentifier.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(true, false, false)]
		public override System.Guid ID
		{
			get
			{
				return this.entityData.ID; 
			}
			
			set
			{
				if (this.entityData.ID == value)
					return;
					
					
				OnColumnChanging(EmailMessageDetailColumn.ID);
				this.entityData.ID = value;
				this.EntityId.ID = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(EmailMessageDetailColumn.ID);
				OnPropertyChanged("ID");
			}
		}
		
		/// <summary>
		/// 	Get the original value of the ID property.
		///		
		/// </summary>
		/// <remarks>This is the original value of the ID property.</remarks>
		/// <value>This type is uniqueidentifier</value>
		[BrowsableAttribute(false)/*, XmlIgnoreAttribute()*/]
		public  virtual System.Guid OriginalID
		{
			get { return this.entityData.OriginalID; }
			set { this.entityData.OriginalID = value; }
		}
		
		/// <summary>
		/// 	Gets or sets the ChangeStamp property. 
		///		
		/// </summary>
		/// <value>This type is datetime.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false)]
		public override System.DateTime ChangeStamp
		{
			get
			{
				return this.entityData.ChangeStamp; 
			}
			
			set
			{
				if (this.entityData.ChangeStamp == value)
					return;
					
					
				OnColumnChanging(EmailMessageDetailColumn.ChangeStamp);
				this.entityData.ChangeStamp = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(EmailMessageDetailColumn.ChangeStamp);
				OnPropertyChanged("ChangeStamp");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the IsBinary property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false)]
		public virtual System.Int32 IsBinary
		{
			get
			{
				return this.entityData.IsBinary; 
			}
			
			set
			{
				if (this.entityData.IsBinary == value)
					return;
					
					
				OnColumnChanging(EmailMessageDetailColumn.IsBinary);
				this.entityData.IsBinary = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(EmailMessageDetailColumn.IsBinary);
				OnPropertyChanged("IsBinary");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the Name property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false, 250)]
		public virtual System.String Name
		{
			get
			{
				return this.entityData.Name; 
			}
			
			set
			{
				if (this.entityData.Name == value)
					return;
					
					
				OnColumnChanging(EmailMessageDetailColumn.Name);
				this.entityData.Name = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(EmailMessageDetailColumn.Name);
				OnPropertyChanged("Name");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the BinaryData property. 
		///		
		/// </summary>
		/// <value>This type is image.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false)]
		public virtual System.Byte[] BinaryData
		{
			get
			{
				return this.entityData.BinaryData; 
			}
			
			set
			{
				if (this.entityData.BinaryData == value)
					return;
					
					
				OnColumnChanging(EmailMessageDetailColumn.BinaryData);
				this.entityData.BinaryData = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(EmailMessageDetailColumn.BinaryData);
				OnPropertyChanged("BinaryData");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the StringData property. 
		///		
		/// </summary>
		/// <value>This type is text.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false)]
		public virtual System.String StringData
		{
			get
			{
				return this.entityData.StringData; 
			}
			
			set
			{
				if (this.entityData.StringData == value)
					return;
					
					
				OnColumnChanging(EmailMessageDetailColumn.StringData);
				this.entityData.StringData = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(EmailMessageDetailColumn.StringData);
				OnPropertyChanged("StringData");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the EmailMessageID property. 
		///		
		/// </summary>
		/// <value>This type is uniqueidentifier.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false, false, false)]
		public virtual System.Guid EmailMessageID
		{
			get
			{
				return this.entityData.EmailMessageID; 
			}
			
			set
			{
				if (this.entityData.EmailMessageID == value)
					return;
					
					
				OnColumnChanging(EmailMessageDetailColumn.EmailMessageID);
				this.entityData.EmailMessageID = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(EmailMessageDetailColumn.EmailMessageID);
				OnPropertyChanged("EmailMessageID");
			}
		}
		

		#region Source Foreign Key Property
				
		private EmailMessage _emailMessageIDSource = null;
		
		/// <summary>
		/// Gets or sets the source <see cref="EmailMessage"/>.
		/// </summary>
		/// <value>The source EmailMessage for EmailMessageID.</value>
		[Browsable(false), BindableAttribute()]
		public virtual EmailMessage EmailMessageIDSource
      	{
            get { return this._emailMessageIDSource; }
            set { this._emailMessageIDSource = value; }
      	}
		#endregion
			
		#region Table Meta Data
		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "EmailMessageDetail"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"ID", "ChangeStamp", "IsBinary", "Name", "BinaryData", "StringData", "EmailMessageID"};
			}
		}
		#endregion 
		
		
		#endregion
		
		#region IEditableObject
		
		#region  CancelAddNew Event
		/// <summary>
        /// The delegate for the CancelAddNew event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		public delegate void CancelAddNewEventHandler(object sender, EventArgs e);
    
    	/// <summary>
		/// The CancelAddNew event.
		/// </summary>
		[field:NonSerialized]
		public event CancelAddNewEventHandler CancelAddNew ;

		/// <summary>
        /// Called when [cancel add new].
        /// </summary>
        public void OnCancelAddNew()
        {    
			if (!SuppressEntityEvents)
			{
	            CancelAddNewEventHandler handler = CancelAddNew ;
            	if (handler != null)
	            {    
    	            handler(this, EventArgs.Empty) ;
        	    }
	        }
        }
		#endregion 
		
		/// <summary>
		/// Begins an edit on an object.
		/// </summary>
		void IEditableObject.BeginEdit() 
	    {
	        //Console.WriteLine("Start BeginEdit");
	        if (!inTxn) 
	        {
	            this.backupData = this.entityData.Clone() as EmailMessageDetailEntityData;
	            inTxn = true;
	            //Console.WriteLine("BeginEdit");
	        }
	        //Console.WriteLine("End BeginEdit");
	    }
	
		/// <summary>
		/// Discards changes since the last <c>BeginEdit</c> call.
		/// </summary>
	    void IEditableObject.CancelEdit() 
	    {
	        //Console.WriteLine("Start CancelEdit");
	        if (this.inTxn) 
	        {
	            this.entityData = this.backupData;
	            this.backupData = null;
				this.inTxn = false;

				if (this.bindingIsNew)
	        	//if (this.EntityState == EntityState.Added)
	        	{
					if (this.parentCollection != null)
						this.parentCollection.Remove( (EmailMessageDetail) this ) ;
				}	            
	        }
	        //Console.WriteLine("End CancelEdit");
	    }
	
		/// <summary>
		/// Pushes changes since the last <c>BeginEdit</c> or <c>IBindingList.AddNew</c> call into the underlying object.
		/// </summary>
	    void IEditableObject.EndEdit() 
	    {
	        //Console.WriteLine("Start EndEdit" + this.custData.id + this.custData.lastName);
	        if (this.inTxn) 
	        {
	            this.backupData = null;
				if (this.IsDirty) 
				{
					if (this.bindingIsNew) {
						this.EntityState = EntityState.Added;
						this.bindingIsNew = false ;
					}
					else
						if (this.EntityState == EntityState.Unchanged) 
							this.EntityState = EntityState.Changed ;
				}

				this.bindingIsNew = false ;
	            this.inTxn = false;	            
	        }
	        //Console.WriteLine("End EndEdit");
	    }
	    
	    /// <summary>
        /// Gets or sets the parent collection.
        /// </summary>
        /// <value>The parent collection.</value>
	    [XmlIgnore]
		[Browsable(false)]
	    public override object ParentCollection
	    {
	        get 
	        {
	            return (object)this.parentCollection;
	        }
	        set 
	        {
	            this.parentCollection = value as TList<EmailMessageDetail>;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as EmailMessageDetail);
	        }
	    }


		#endregion
		
		#region Methods	
			
		///<summary>
		///  TODO: Revert all changes and restore original values.
		///  Currently not supported.
		///</summary>
		/// <exception cref="NotSupportedException">This method is not currently supported and always throws this exception.</exception>
		public override void CancelChanges()
		{
			throw new NotImplementedException("Method currently not Supported.");
		}	
		
		#region ICloneable Members
		///<summary>
		///  Returns a Typed EmailMessageDetail Entity 
		///</summary>
		public virtual EmailMessageDetail Copy()
		{
			//shallow copy entity
			EmailMessageDetail copy = new EmailMessageDetail();
			copy.ID = this.ID;
			copy.OriginalID = this.OriginalID;
			copy.ChangeStamp = this.ChangeStamp;
			copy.IsBinary = this.IsBinary;
			copy.Name = this.Name;
			copy.BinaryData = this.BinaryData;
			copy.StringData = this.StringData;
			copy.EmailMessageID = this.EmailMessageID;
					
			copy.AcceptChanges();
			return (EmailMessageDetail)copy;
		}
		
		///<summary>
		/// ICloneable.Clone() Member, returns the Shallow Copy of this entity.
		///</summary>
		public object Clone()
		{
			return this.Copy();
		}
		
		///<summary>
		/// Returns a deep copy of the child collection object passed in.
		///</summary>
		public static object MakeCopyOf(object x)
		{
			if (x is ICloneable)
			{
				// Return a deep copy of the object
				return ((ICloneable)x).Clone();
			}
			else
				throw new System.NotSupportedException("Object Does Not Implement the ICloneable Interface.");
		}
		
		///<summary>
		///  Returns a Typed EmailMessageDetail Entity which is a deep copy of the current entity.
		///</summary>
		public virtual EmailMessageDetail DeepCopy()
		{
			return EntityHelper.Clone<EmailMessageDetail>(this as EmailMessageDetail);	
		}
		#endregion
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="EmailMessageDetailBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(EmailMessageDetailBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="EmailMessageDetailBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="EmailMessageDetailBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="EmailMessageDetailBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(EmailMessageDetailBase Object1, EmailMessageDetailBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.ID != Object2.ID)
				equal = false;
			if (Object1.ChangeStamp != Object2.ChangeStamp)
				equal = false;
			if (Object1.IsBinary != Object2.IsBinary)
				equal = false;
			if (Object1.Name != Object2.Name)
				equal = false;
			if (Object1.BinaryData != Object2.BinaryData)
				equal = false;
			if (Object1.StringData != Object2.StringData)
				equal = false;
			if (Object1.EmailMessageID != Object2.EmailMessageID)
				equal = false;
			return equal;
		}
		
		#endregion
		
		#region IComparable Members
		///<summary>
		/// Compares this instance to a specified object and returns an indication of their relative values.
		///<param name="obj">An object to compare to this instance, or a null reference (Nothing in Visual Basic).</param>
		///</summary>
		///<returns>A signed integer that indicates the relative order of this instance and obj.</returns>
		public virtual int CompareTo(object obj)
		{
			throw new NotImplementedException();
			// TODO -> generate a strongly typed IComparer in the concrete class
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name) .CompareTo(((EmailMessageDetailBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name));
		}
		
		/*
		// static method to get a Comparer object
        public static EmailMessageDetailComparer GetComparer()
        {
            return new EmailMessageDetailComparer();
        }
        */

        // Comparer delegates back to EmailMessageDetail
        // Employee uses the integer's default
        // CompareTo method
        /*
        public int CompareTo(Item rhs)
        {
            return this.Id.CompareTo(rhs.Id);
        }
        */

/*
        // Special implementation to be called by custom comparer
        public int CompareTo(EmailMessageDetail rhs, EmailMessageDetailColumn which)
        {
            switch (which)
            {
            	
            	
            	case EmailMessageDetailColumn.ID:
            		return this.ID.CompareTo(rhs.ID);
            		
            		                 
            	
            	
            	case EmailMessageDetailColumn.ChangeStamp:
            		return this.ChangeStamp.CompareTo(rhs.ChangeStamp);
            		
            		                 
            	
            	
            	case EmailMessageDetailColumn.IsBinary:
            		return this.IsBinary.CompareTo(rhs.IsBinary);
            		
            		                 
            	
            	
            	case EmailMessageDetailColumn.Name:
            		return this.Name.CompareTo(rhs.Name);
            		
            		                 
            	
            		                 
            	
            	
            	case EmailMessageDetailColumn.StringData:
            		return this.StringData.CompareTo(rhs.StringData);
            		
            		                 
            	
            	
            	case EmailMessageDetailColumn.EmailMessageID:
            		return this.EmailMessageID.CompareTo(rhs.EmailMessageID);
            		
            		                 
            }
            return 0;
        }
        */
	
		#endregion
		
		#region IComponent Members
		
		private ISite _site = null;

		/// <summary>
		/// Gets or Sets the site where this data is located.
		/// </summary>
		[XmlIgnore]
		[SoapIgnore]
		[Browsable(false)]
		public ISite Site
		{
			get{ return this._site; }
			set{ this._site = value; }
		}

		#endregion

		#region IDisposable Members
		
		/// <summary>
		/// Notify those that care when we dispose.
		/// </summary>
		[field:NonSerialized]
		public event System.EventHandler Disposed;

		/// <summary>
		/// Clean up. Nothing here though.
		/// </summary>
		public void Dispose()
		{
			this.parentCollection = null;
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		/// <summary>
		/// Clean up.
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				EventHandler handler = Disposed;
				if (handler != null)
					handler(this, EventArgs.Empty);
			}
		}
		
		#endregion
				
		#region IEntityKey<EmailMessageDetailKey> Members
		
		// member variable for the EntityId property
		private EmailMessageDetailKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public EmailMessageDetailKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new EmailMessageDetailKey(this);
				}

				return _entityId;
			}
			set
			{
				if ( value != null )
				{
					value.Entity = this;
				}
				
				_entityId = value;
			}
		}
		
		#endregion
		
		#region EntityTrackingKey
		///<summary>
		/// Provides the tracking key for the <see cref="EntityLocator"/>
		///</summary>
		[XmlIgnore]
		public override string EntityTrackingKey
		{
			get
			{
				if(entityTrackingKey == null)
					entityTrackingKey = @"EmailMessageDetail" 
					+ this.ID.ToString();
				return entityTrackingKey;
			}
			set
		    {
		        if (value != null)
                    entityTrackingKey = value;
		    }
		}
		#endregion 
		
		#region ToString Method
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{8}{7}- ID: {0}{7}- ChangeStamp: {1}{7}- IsBinary: {2}{7}- Name: {3}{7}- BinaryData: {4}{7}- StringData: {5}{7}- EmailMessageID: {6}{7}", 
				this.ID,
				this.ChangeStamp,
				this.IsBinary,
				this.Name,
				this.BinaryData,
				this.StringData,
				this.EmailMessageID,
				Environment.NewLine, 
				this.GetType());
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'EmailMessageDetail' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal class EmailMessageDetailEntityData : ICloneable
	{
		#region Variable Declarations
		
		#region Primary key(s)
			/// <summary>			
			/// ID : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "EmailMessageDetail"</remarks>
			public System.Guid ID;
				
			/// <summary>
			/// keep a copy of the original so it can be used for editable primary keys.
			/// </summary>
			public System.Guid OriginalID;
			
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// ChangeStamp : 
		/// </summary>
		public System.DateTime		  ChangeStamp = DateTime.MinValue;
		
		/// <summary>
		/// IsBinary : 
		/// </summary>
		public System.Int32		  IsBinary = (int)0;
		
		/// <summary>
		/// Name : 
		/// </summary>
		public System.String		  Name = string.Empty;
		
		/// <summary>
		/// BinaryData : 
		/// </summary>
		public System.Byte[]		  BinaryData = new byte[] {};
		
		/// <summary>
		/// StringData : 
		/// </summary>
		public System.String		  StringData = string.Empty;
		
		/// <summary>
		/// EmailMessageID : 
		/// </summary>
		public System.Guid		  EmailMessageID = Guid.Empty;
		#endregion
			
		#endregion "Variable Declarations"
		
		public Object Clone()
		{
			EmailMessageDetailEntityData _tmp = new EmailMessageDetailEntityData();
						
			_tmp.ID = this.ID;
			_tmp.OriginalID = this.OriginalID;
			
			_tmp.ChangeStamp = this.ChangeStamp;
			_tmp.IsBinary = this.IsBinary;
			_tmp.Name = this.Name;
			_tmp.BinaryData = this.BinaryData;
			_tmp.StringData = this.StringData;
			_tmp.EmailMessageID = this.EmailMessageID;
			
			return _tmp;
		}
		
	}//End struct


		#endregion
		
		#region Validation
		
		/// <summary>
		/// Assigns validation rules to this object based on model definition.
		/// </summary>
		/// <remarks>This method overrides the base class to add schema related validation.</remarks>
		protected override void AddValidationRules()
		{
			//Validation rules based on database schema.
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"Name");
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("Name",250));
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"BinaryData");
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"StringData");
		}
   		#endregion
	
	} // End Class
	
	#region EmailMessageDetailComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class EmailMessageDetailComparer : System.Collections.Generic.IComparer<EmailMessageDetail>
	{
		EmailMessageDetailColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:EmailMessageDetailComparer"/> class.
        /// </summary>
		public EmailMessageDetailComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:%=className%>Comparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public EmailMessageDetailComparer(EmailMessageDetailColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="EmailMessageDetail"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="EmailMessageDetail"/> to compare.</param>
        /// <param name="b">The second <c>EmailMessageDetail</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(EmailMessageDetail a, EmailMessageDetail b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(EmailMessageDetail entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(EmailMessageDetail a, EmailMessageDetail b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public EmailMessageDetailColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region EmailMessageDetailKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="EmailMessageDetail"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class EmailMessageDetailKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the EmailMessageDetailKey class.
		/// </summary>
		public EmailMessageDetailKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the EmailMessageDetailKey class.
		/// </summary>
		public EmailMessageDetailKey(EmailMessageDetailBase entity)
		{
			Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.id = entity.ID;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the EmailMessageDetailKey class.
		/// </summary>
		public EmailMessageDetailKey(System.Guid id)
		{
			#region Init Properties

			this.id = id;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private EmailMessageDetailBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public EmailMessageDetailBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the ID property
		private System.Guid id;
		
		/// <summary>
		/// Gets or sets the ID property.
		/// </summary>
		public System.Guid ID
		{
			get { return id; }
			set
			{
				if ( Entity != null )
				{
					Entity.ID = value;
				}
				
				id = value;
			}
		}
		
		#endregion

		#region Methods
		
		/// <summary>
		/// Reads values from the supplied <see cref="IDictionary"/> object into
		/// properties of the current object.
		/// </summary>
		/// <param name="values">An <see cref="IDictionary"/> instance that contains
		/// the key/value pairs to be used as property values.</param>
		public override void Load(IDictionary values)
		{
			#region Init Properties

			if ( values != null )
			{
				ID = ( values["ID"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["ID"], typeof(System.Guid)) : Guid.Empty;
			}

			#endregion
		}

		/// <summary>
		/// Creates a new <see cref="IDictionary"/> object and populates it
		/// with the property values of the current object.
		/// </summary>
		/// <returns>A collection of name/value pairs.</returns>
		public override IDictionary ToDictionary()
		{
			IDictionary values = new Hashtable();

			#region Init Dictionary

			values.Add("ID", ID);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("ID: {0}{1}",
								ID,
								Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	

	#region EmailMessageDetailColumn Enum
	
	/// <summary>
	/// Enumerate the EmailMessageDetail columns.
	/// </summary>
	[Serializable]
	public enum EmailMessageDetailColumn
	{
		/// <summary>
		/// ID : 
		/// </summary>
		[EnumTextValue("ID")]
		[ColumnEnum("ID", typeof(System.Guid), System.Data.DbType.Guid, true, false, false)]
		ID,
		/// <summary>
		/// ChangeStamp : 
		/// </summary>
		[EnumTextValue("ChangeStamp")]
		[ColumnEnum("ChangeStamp", typeof(System.DateTime), System.Data.DbType.DateTime, false, false, false)]
		ChangeStamp,
		/// <summary>
		/// IsBinary : 
		/// </summary>
		[EnumTextValue("IsBinary")]
		[ColumnEnum("IsBinary", typeof(System.Int32), System.Data.DbType.Int32, false, false, false)]
		IsBinary,
		/// <summary>
		/// Name : 
		/// </summary>
		[EnumTextValue("Name")]
		[ColumnEnum("Name", typeof(System.String), System.Data.DbType.AnsiString, false, false, false, 250)]
		Name,
		/// <summary>
		/// BinaryData : 
		/// </summary>
		[EnumTextValue("BinaryData")]
		[ColumnEnum("BinaryData", typeof(System.Byte[]), System.Data.DbType.Binary, false, false, false)]
		BinaryData,
		/// <summary>
		/// StringData : 
		/// </summary>
		[EnumTextValue("StringData")]
		[ColumnEnum("StringData", typeof(System.String), System.Data.DbType.AnsiString, false, false, false)]
		StringData,
		/// <summary>
		/// EmailMessageID : 
		/// </summary>
		[EnumTextValue("EmailMessageID")]
		[ColumnEnum("EmailMessageID", typeof(System.Guid), System.Data.DbType.Guid, false, false, false)]
		EmailMessageID
	}//End enum

	#endregion EmailMessageDetailColumn Enum

} // end namespace
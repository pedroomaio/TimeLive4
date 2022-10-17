/*
	File generated by NetTiers templates [www.nettiers.com]
	Generated on : Friday, 1 September 2006
	Important: Do not modify this file. Edit the file EntityBase.cs instead.
*/

#region Using Directives

using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Runtime.Serialization;

#endregion

namespace SmartMassEmail.Entities
{

	/// <summary>
	/// The base object for each database table entity.
	/// </summary>
	[Serializable]
	public abstract partial class EntityBaseCore : IEntity, INotifyPropertyChanged, IDataErrorInfo, IDeserializationCallback
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the <see cref="T:EntityBaseCore"/> class.
		/// </summary>
		protected EntityBaseCore()
		{
		}
		
      	#endregion
		
		/// <summary>
		/// The EntityState of the entity
		/// </summary>
		private EntityState currentEntityState = EntityState.Added ;
	    /// <summary>
	    /// Determines whether the entity is being tracked by the Locator.
	    /// </summary>
		private bool isEntityTracked = false;
	    /// <summary>
		/// Suppresses Entity Events from Firing, 
		/// useful when loading the entities from the database.
		/// </summary>
	    private bool suppressEntityEvents = false;
		
		
		/// <summary>
		///  Used by in place editing of databinding features for new inserted row.
		/// Indicates that we are in the middle of an IBinding insert transaction.
		/// </summary>
		protected bool bindingIsNew = true;
				
		/// <summary>
		///	The name of the underlying database table.
		/// </summary>
		public abstract string TableName { get;}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		/// <value>A string array that holds the columns names.</value>
		public abstract string[] TableColumns {get;}

		//private bool _isDeleted = false;
		/// <summary>
		/// 	True if object has been <see cref="MarkToDelete"/>. ReadOnly.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public bool IsDeleted
		{
			get { return this.currentEntityState == EntityState.Deleted; }
		}		
		
		//private bool _isDirty = false;
		/// <summary>
		///		Indicates if the object has been modified from its original state.
		/// </summary>
		/// <remarks>True if object has been modified from its original state; otherwise False;</remarks>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public bool IsDirty
		{
			get { return this.currentEntityState != EntityState.Unchanged; }
		}
		
		
		//private bool _isNew = true;
		/// <summary>
		///		Indicates if the object is new.
		/// </summary>
		/// <remarks>True if objectis new; otherwise False;</remarks>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public bool IsNew
		{
			get { return this.currentEntityState == EntityState.Added; }
			set { this.currentEntityState = EntityState.Added; }
		}
		

		
		//private EntityState state = EntityState.Unchanged ;
		/// <summary>
		///		Indicates state of object
		/// </summary>
		/// <remarks>0=Unchanged, 1=Added, 2=Changed</remarks>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public virtual EntityState EntityState
		{
			get { return this.currentEntityState; }
			set { this.currentEntityState = value; }
		}
		
		/// <summary>
		/// Accepts the changes made to this object.
		/// </summary>
		/// <remarks>
		/// After calling this method <see cref="IsDirty"/> and <see cref="IsNew"/> are false. <see cref="IsDeleted"/> flag remain unchanged as it is handled by the parent List.
		/// </remarks>
		public virtual void AcceptChanges()
		{			
			this.bindingIsNew = false;
			this.currentEntityState = EntityState.Unchanged;
			OnPropertyChanged(string.Empty);
		}
		
		
		///<summary>
		///  TODO: Revert all changes and restore original values.
		///  Currently not supported.
		///</summary>
		/// <exception cref="NotSupportedException">This method is not currently supported and always throws this exception.</exception>
		public abstract void CancelChanges();
		
		
		///<summary>
		///   Marks entity to be deleted.
		///</summary>
		public virtual void MarkToDelete()
		{
			
			if (this.currentEntityState != EntityState.Added)
				this.currentEntityState = EntityState.Deleted ;
		}
		
		///<summary>
		///   Remove the "isDeleted" mark from the entity.
		///</summary>
		public virtual void RemoveDeleteMark()
		{
			if (this.currentEntityState != EntityState.Added) 
			{				
				this.currentEntityState = EntityState.Changed ;
			}
		}
				 
		/// <summary>
        /// Gets or sets the parent collection.
        /// </summary>
        /// <value>The parent collection.</value>
		[XmlIgnore]
		public abstract object ParentCollection{get;set;}
		
		#region Common Columns
		/// <summary>
		/// 
		/// </summary>
		public abstract System.Guid ID {get;set;}
		/// <summary>
		/// 
		/// </summary>
		public abstract System.DateTime ChangeStamp {get;set;}
		#endregion		
		
		/// <summary>
		/// Object that contains data to associate with this object
		/// </summary>
		[NonSerialized]
		private object tag;	
		
		/// <summary>
		///     Gets or sets the object that contains supplemental data about this object.
		/// </summary>
		/// <value>Object</value>
		[System.ComponentModel.Bindable(false)]
		[LocalizableAttribute(false)]
		[DescriptionAttribute("Object containing data to be associated with this object")]
		public virtual object Tag
		{
			get
			{
				return this.tag;
			}
			set
			{
				if (this.tag == value)
					return;
		
				this.tag = value;
			}
		}
		
		/// <summary>
		/// Determines whether this entity is being tracked.
		/// </summary>
		[System.ComponentModel.Bindable(false)]
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public bool IsEntityTracked 
		{	
			get
			{
				return isEntityTracked;
			}
			set
			{
				isEntityTracked = value;
			}	
		}
		
				
		/// <summary>
		/// Determines whether this entity is to suppress events while set to true.
		/// </summary>
		[System.ComponentModel.Bindable(false)]
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public bool SuppressEntityEvents
		{	
			get
			{
				return suppressEntityEvents;
			}
			set
			{
				suppressEntityEvents = value;
			}	
		}
		
		///<summary>
		/// Provides the tracking key for the <see cref="EntityLocator"/>
		///</summary>
		[XmlIgnoreAttribute(), BrowsableAttribute(false)]
		public abstract string EntityTrackingKey {	get; set; }
		
		#region INotifyPropertyChanged Members
		
		/// <summary>
		/// Event to indicate that a property has changed.
		/// </summary>
		[field:NonSerialized]
		public event PropertyChangedEventHandler PropertyChanged;
		
		/// <summary>
		/// Called when a property is changed
		/// </summary>
		/// <param name="propertyName">The name of the property that has changed.</param>
		protected virtual void OnPropertyChanged(string propertyName)
		{ 
			if (!suppressEntityEvents)
			{
			OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
		}
		}
		
		/// <summary>
		/// Called when a property is changed
		/// </summary>
		/// <param name="e">PropertyChangedEventArgs</param>
		protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			if (!suppressEntityEvents)
			{
			//Validate the property
         ValidationRules.ValidateRules(e.PropertyName);

			if (null != PropertyChanged)
			{
				PropertyChanged(this, e);
			}
		}
		}
		
		#endregion
		
		#region IDataErrorInfo Members

		/// <summary>
		/// Gets an error message indicating what is wrong with this object.
		/// </summary>
		/// <value></value>
		/// <returns>An error message indicating what is wrong with this object. The default is an empty string ("").</returns>      
		public string Error
		{
			get 
			{
				string errorDescription = string.Empty;
				if (!IsValid)
				{
					errorDescription = ValidationRules.GetBrokenRules().ToString();
				}				
				return errorDescription;
			}
		}

		/// <summary>
		/// Gets the <see cref="T:String"/> with the specified column name.
		/// </summary>
		/// <value></value>
		public string this[string columnName]
		{
			get
			{
				string errorDescription = string.Empty;
				if (!IsValid)
				{
				 	errorDescription = ValidationRules.GetBrokenRules().GetPropertyErrorDescriptions(columnName);
				}
				return errorDescription;
			}
		}

      #endregion

      	#region Validation

		[NonSerialized]
     	private Validation.ValidationRules _validationRules;


		/// <summary>
		/// Returns the list of <see cref="Validation.ValidationRules"/> associated with this object.
		/// </summary>
		[XmlIgnoreAttribute()]
		protected Validation.ValidationRules ValidationRules
		{
			get
			{
				if (_validationRules == null)
				{
					_validationRules = new Validation.ValidationRules(this);
					
					//lazy init the rules as well.
					AddValidationRules();
				}
	
				return _validationRules;
			}
		}

		/// <summary>
		/// Assigns validation rules to this object.
		/// </summary>
		/// <remarks>
		/// This method can be overridden in a derived class to add custom validation rules. 
		///</remarks>
		protected virtual void AddValidationRules()
		{
			
		}
	
		/// <summary>
		/// Returns <see langword="true" /> if the object is valid, 
		/// <see langword="false" /> if the object validation rules that have indicated failure. 
		/// </summary>
		[Browsable(false)]
		public virtual bool IsValid
		{
			get
			{
				return ValidationRules.IsValid;
			}
		}

		/// <summary>
		/// Returns a list of all the validation rules that failed.
		/// </summary>
		/// <returns><see cref="Validation.BrokenRulesList" /></returns>
		[XmlIgnoreAttribute()]
		public virtual Validation.BrokenRulesList BrokenRulesList
		{
			get
			{
				return ValidationRules.GetBrokenRules();
			}
		}
	
		/// <summary>
		/// Force this object to validate itself using the assigned business rules.
		/// </summary>
		/// <remarks>Validates all properties.</remarks>
		public void Validate()
		{
			ValidationRules.ValidateRules();
		}
	
		/// <summary>
		/// Force the object to validate itself using the assigned business rules.
		/// </summary>
		/// <param name="propertyName">Name of the property to validate.</param>
		public void Validate(string propertyName)
		{
			ValidationRules.ValidateRules(propertyName);
		}
		
		/// <summary>
		/// Force the object to validate itself using the assigned business rules.
		/// </summary>
		/// <param name="column">Column enumeration representingt the column to validate.</param>
		public void Validate(System.Enum column)
		{
			Validate(column.ToString());
		}
      	#endregion

      #region IDeserializationCallback Members

		/// <summary>
		/// Runs when the entire object graph has been deserialized.
		/// </summary>
		/// <param name="sender">The object that initiated the callback. The functionality for this parameter is not currently implemented.</param>
		
		public void OnDeserialization(object sender)
		{
			if(!suppressEntityEvents)
			{
			ValidationRules.Target = this;
			AddValidationRules();
		}
		}

      #endregion
		
	}
}
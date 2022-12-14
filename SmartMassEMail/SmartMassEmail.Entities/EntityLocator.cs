
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.ObjectBuilder;


namespace SmartMassEmail.Entities
{
    /// <summary>
    /// Provides a means to weak reference and already created and untouched locate entities.
    /// </summary>	
    public class EntityLocator : Locator 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityLocator"/> class.
        /// </summary>
        public EntityLocator() 
            : base(null)
        { 
        }

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(string key, object value)
        {
            //TODO: Add an Entity specific logic 
            
            base.Add(key as object, value);
        }


        /// <summary>
        /// Determines whether [contains] [the specified key].
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// 	<c>true</c> if [contains] [the specified key]; otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(string key, SearchMode options)
        {
            //TODO: Add an Entity specific logic 
            return base.Contains(key, options);
        }


        /// <summary>
        /// Gets the specified key of any object.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="options">The options.</param>
        /// <returns>object if available, else null </returns>
        public override object Get(object key, SearchMode options)
        {
            return base.Get(key, options);
        }

        /// <summary>
        /// Get's an Entity from the Tracking Locator
        /// </summary>
        /// <typeparam name="Entity">A type that implements IEntity</typeparam>
        /// <param name="key">locator list key to fetch, best used 
        /// if it's the (TypeName or TableName) + EntityKey of the this entity</param>
        /// <returns>Entity from Locator if available.</returns>
        public Entity GetEntity<Entity>(string key) where Entity : EntityBase, new()
        {
            //TODO: Add an Entity specific logic 
            return Get(key as object, SearchMode.Local) as Entity;
        }

        /// <summary>
        /// Get's a List of Entities from the Tracking Locator
        /// </summary>
        /// <typeparam name="EntityList"> a type that implements ListBase&lt;IEntity&gt;</typeparam>
        /// <param name="key">locator list key to fetch, best used 
        /// if it's like the criteria of the method used to populate this list
        /// </param>
        /// <returns>ListBase&lt;IEntity&gt; if available</returns>
        public EntityList GetList<EntityList>(string key) where EntityList : ListBase<IEntity>, new()
        {
            //TODO: Add an List specific logic 
            return Get(key as object, SearchMode.Local) as EntityList;
        }
		
        /// <summary>
        /// Re-Creates the key based on primary key values.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="pkItems">The pk items.</param>
        /// <returns></returns>
		public static string ConstructKeyFromPkItems(Type type, params object[] pkItems)
		{
			if (type == null)
				throw new ArgumentNullException("type");
			
			if (pkItems.Length == 0)
				throw new ArgumentNullException("pkItems");
				
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append(type.Name);
			
			for(int i=0; i < pkItems.Length; i++)
			{
				if (pkItems[i] != null)
					sb.Append(pkItems[i].ToString());
			}
			
			return sb.ToString();
		}
	}

}

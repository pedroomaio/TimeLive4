using System;
using System.Reflection;
using System.Collections;

namespace SmartMassEmail.Entities
{
	/// <summary>
	/// Hold a list of <see cref="Expression"/> instance.
	/// </summary>
	public sealed class Expressions : CollectionBase
	{
		/// <summary>
		/// Initializes a new instance of the <c>Expressions</c> class.
		/// </summary>
		/// <param name="holeFilterExpression">the filter expression that will be parsed to create the collection.</param>
		public Expressions (string holeFilterExpression)
		{
			this.SplitFilter(holeFilterExpression);
		}
		
		/// <summary>
		/// Initializes a new instance of the <c>Expressions</c> class.
		/// </summary>
		public Expressions() 
		{
		}
		
		/// <summary>
		/// This method split a string filter expression anc create <c>Filter</c> instances.
		/// </summary>
		public void SplitFilter(string HoleFilterExpression)
		{
			int LastPosition = 0;
			
			//AND
			for (int j = 5; j <= HoleFilterExpression.Length -5; j ++)
			{
			
				string FiveCurrentChars = HoleFilterExpression.Substring(j-5, 5).ToUpper();
				if (FiveCurrentChars == " AND ") 
				{
					
					
					this.Add( new Expression(HoleFilterExpression.Substring(LastPosition , j - LastPosition -5 )));
					LastPosition = j;
				}
			}
			//OR
			for (int z = 4; z <= HoleFilterExpression.Length -4; z ++)
			{
				string TowCurrentChars = HoleFilterExpression.Substring(z -4, 4).ToUpper();
				if (TowCurrentChars == " OR " ) 
				{
					this.Add(new Expression(HoleFilterExpression.Substring(LastPosition  , z - LastPosition -4)));
					LastPosition = z;
				}
			}
		
			//Ajouter le dernier ?lement ou le premier si aucun AND/OR
			this.Add(new Expression(HoleFilterExpression.Substring(LastPosition)));
		}
		
		/// <summary>
		/// Get the <see cref="Expression"/> at the specified index.
		/// </summary>
		/// <param name="Index">The index of the expression in the collection.</param>
		/// <returns></returns>
		public Expression Item(int Index)
		{
			return (Expression) List[Index];	
		}
		
		/// <summary>
		/// Adds the specified value.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public int Add(Expression value) 
		{			
			return List.Add(value);
		}

		/// <summary>
		/// Removes the specified value.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public void Remove(Expression value) 
		{		
			List.Remove(value);
		}

/*
		/// <summary>
		/// Elements the changed.
		/// </summary>
		/// <param name="cust">The cust.</param>
		internal void ElementChanged(Expression cust) 
		{        
			int index = List.IndexOf(cust);        		
		}
*/
	}
	
	
	/// <summary>
	///	 Reprensents an expression to filter a collection.
	/// </summary>
	public sealed class Expression
	{
		private string TmpPropertyValue;
		private string TmpOperator;
		private string TmpUserValue;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Expression"/> class.
		/// </summary>
		public Expression()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Expression"/> class.
		/// </summary>
		/// <param name="PropValue">The prop value.</param>
		/// <param name="Opr">The opr.</param>
		/// <param name="Usrvalue">The usrvalue.</param>
		public Expression(string PropValue, string Opr, string Usrvalue )
		{
			this.PropertyName = PropValue;
			this.Operator = Opr;
			this.UserValue = this.UserValue = Usrvalue;
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Expression"/> class.
		/// </summary>
		/// <param name="wholeExpression">The whole expression.</param>
		public Expression( string wholeExpression)
		{
			string [] Words = new string[2] ;
			Words = wholeExpression.Split(new char[]{' '}, 3);
			this.PropertyName = Words[0];
			this.Operator = Words[1].Trim();
			this.UserValue = Words[2].Trim ();
		}
		
		/// <summary>
		/// Gets or sets the name of the property.
		/// </summary>
		/// <value>The name of the property.</value>
		public string PropertyName
		{
			get{return TmpPropertyValue;}
			set{TmpPropertyValue = value;}
		}
		
		/// <summary>
		/// Gets or sets the operator.
		/// </summary>
		/// <value>The operator.</value>
		public string Operator
		{
			get{return TmpOperator;}
			set{TmpOperator = value;}
		}
		
		/// <summary>
		/// Gets or sets the user value.
		/// </summary>
		/// <value>The user value.</value>
		public string UserValue
		{
			get{return TmpUserValue;}
			set{TmpUserValue = value;}
		}
	}
	
	/// <summary>
	/// Represents a filter.
	/// </summary>
	public sealed class Filter
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Filter"/> class.
		/// </summary>
		public Filter()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="Filter"/> class.
		/// </summary>
		/// <param name="ObjToFilter">The obj to filter.</param>
		/// <param name="filterdItemsBackupList">The filterd items backup list.</param>
		/// <param name="itemType">Type of the item.</param>
		/// <param name="Filter">The filter.</param>
		public Filter(object ObjToFilter, IList filterdItemsBackupList, Type itemType, string Filter)
		{			
			this.ApplyFilter(ObjToFilter, filterdItemsBackupList, itemType, Filter);
		}
		
		/// <summary>
		/// Determines whether the specified object property value is ok.
		/// </summary>
		/// <param name="ObjectPropertyValue">The object property value.</param>
		/// <param name="Operator">The operator.</param>
		/// <param name="UserValue">The user value.</param>
		/// <returns>
		/// 	<c>true</c> if the specified object property value is ok; otherwise, <c>false</c>.
		/// </returns>
		private bool IsOk(string ObjectPropertyValue , string Operator, string UserValue)
		{
			bool Rt = false;
			
			if (Operator == "=")
			{
				if (ObjectPropertyValue.TrimEnd() == UserValue.TrimEnd()) {Rt = true;}
			}
			else if(Operator == "<>" |Operator == "!=")
			{
				if (ObjectPropertyValue.TrimEnd() != UserValue.TrimEnd()) {Rt = true;}
			}
			else if (Operator.ToUpper() == "LIKE")
			{
				//recherche des ?toiles
				int LastStrar = UserValue.LastIndexOf("*");
				int UserValueLenght = UserValue.Length ;
				string SearchedText = UserValue.Replace("*", "");
				int TextPosition = ObjectPropertyValue.IndexOf(SearchedText);
				if (TextPosition != -1)
				{
				{Rt = true;}
				}
			}
			else
			{
				throw new Exception("The operator '" + Operator + "' does not match the type String !");
			}
			return Rt;
		}
		
		/// <summary>
		/// Determines whether the specified object property value is ok.
		/// </summary>
		/// <param name="ObjectPropertyValue">The object property value.</param>
		/// <param name="Operator">The operator.</param>
		/// <param name="UserValue">The user value.</param>
		/// <returns>
		/// 	<c>true</c> if the specified object property value is ok; otherwise, <c>false</c>.
		/// </returns>
		private bool IsOk(int ObjectPropertyValue , string Operator, int UserValue)
		{
			bool Rt = false;
			
			if (Operator == "=")
			{
				if (ObjectPropertyValue == UserValue) {Rt = true;}
			}
			else if (Operator == ">")
			{
				if (ObjectPropertyValue > UserValue) {Rt = true;}
			}
			else if (Operator == ">=")
			{
				if (ObjectPropertyValue >= UserValue) {Rt = true;}
			}
			else if (Operator == "<")
			{
				if (ObjectPropertyValue < UserValue) {Rt = true;}
			}
			else if (Operator == "<=")
			{
				if (ObjectPropertyValue <= UserValue) {Rt = true;}
			}
			
			else if(Operator == "<>"|Operator == "!=")
			{
				if (ObjectPropertyValue != UserValue) {Rt = true;}
			}

			else
			{
				throw new Exception("The operator '" + Operator + "' does not match the type int !");
			}
			return Rt;
		}
		
		/// <summary>
		/// Determines whether the specified object property value is ok.
		/// </summary>
		/// <param name="ObjectPropertyValue">The object property value.</param>
		/// <param name="Operator">The operator.</param>
		/// <param name="UserValue">The user value.</param>
		/// <returns>
		/// 	<c>true</c> if the specified object property value is ok; otherwise, <c>false</c>.
		/// </returns>
		private bool IsOk(decimal ObjectPropertyValue , string Operator, int UserValue)
		{
			bool Rt = false;
			
			if (Operator == "=")
			{
				if (ObjectPropertyValue == UserValue) {Rt = true;}
			}
			else if (Operator == ">")
			{
				if (ObjectPropertyValue > UserValue) {Rt = true;}
			}
			else if (Operator == ">=")
			{
				if (ObjectPropertyValue >= UserValue) {Rt = true;}
			}
			else if (Operator == "<")
			{
				if (ObjectPropertyValue < UserValue) {Rt = true;}
			}
			else if (Operator == "<=")
			{
				if (ObjectPropertyValue <= UserValue) {Rt = true;}
			}
			
			else if(Operator == "<>"|Operator == "!=")
			{
				if (ObjectPropertyValue != UserValue) {Rt = true;}
			}

			else
			{
				throw new Exception("The operator '" + Operator + "' does not match the type int !");
			}
			return Rt;
		}

		/// <summary>
		/// Determines whether the specified object property value is ok.
		/// </summary>
		/// <param name="ObjectPropertyValue">The object property value.</param>
		/// <param name="Operator">The operator.</param>
		/// <param name="UserValue">The user value.</param>
		/// <returns>
		/// 	<c>true</c> if the specified object property value is ok; otherwise, <c>false</c>.
		/// </returns>
		private bool IsOk(Guid ObjectPropertyValue , string Operator, Guid UserValue)
		{
			bool Rt = false;
			
			if (Operator == "=")
			{
				if (ObjectPropertyValue == UserValue) {Rt = true;}
			}
			else
			{
				throw new Exception("The operator '" + Operator + "' does not match the type Guid !");
			}
			return Rt;
		}
		
		/// <summary>
		/// Determines whether the specified object property value is ok.
		/// </summary>
		/// <param name="ObjectPropertyValue">The object property value.</param>
		/// <param name="Operator">The operator.</param>
		/// <param name="UserValue">The user value.</param>
		/// <returns>
		/// 	<c>true</c> if the specified object property value is ok; otherwise, <c>false</c>.
		/// </returns>
		private bool IsOk(double ObjectPropertyValue , string Operator, double UserValue)
		{
			bool Rt = false;
			
			if (Operator == "=")
			{
				if (ObjectPropertyValue == UserValue) {Rt = true;}
			}
			else if (Operator == ">")
			{
				if (ObjectPropertyValue > UserValue) {Rt = true;}
			}
			else if (Operator == ">=")
			{
				if (ObjectPropertyValue >= UserValue) {Rt = true;}
			}
			else if (Operator == "<")
			{
				if (ObjectPropertyValue < UserValue) {Rt = true;}
			}
			else if (Operator == "<=")
			{
				if (ObjectPropertyValue <= UserValue) {Rt = true;}
			}
			else
			{
				
				throw new Exception("The operator '" + Operator + "' does not match the type double !");
			}
			return Rt;
		}
		
		/// <summary>
		/// Determines whether the specified object property value is ok.
		/// </summary>
		/// <param name="ObjectPropertyValue">The object property value.</param>
		/// <param name="Operator">The operator.</param>
		/// <param name="UserValue">The user value.</param>
		/// <returns>
		/// 	<c>true</c> if the specified object property value is ok; otherwise, <c>false</c>.
		/// </returns>
		private bool IsOk(decimal ObjectPropertyValue , string Operator, decimal UserValue)
		{
			bool Rt = false;
			
			if (Operator == "=")
			{
				if (ObjectPropertyValue == UserValue) {Rt = true;}
			}
			else if (Operator == ">")
			{
				if (ObjectPropertyValue > UserValue) {Rt = true;}
			}
			else if (Operator == ">=")
			{
				if (ObjectPropertyValue >= UserValue) {Rt = true;}
			}
			else if (Operator == "<")
			{
				if (ObjectPropertyValue < UserValue) {Rt = true;}
			}
			else if (Operator == "<=")
			{
				if (ObjectPropertyValue <= UserValue) {Rt = true;}
			}
			else
			{
				
				throw new Exception("The operator '" + Operator + "' does not match the type decimal !");
			}
			return Rt;			
		}
		
		/// <summary>
		/// Determines whether the specified object property value is ok.
		/// </summary>
		/// <param name="ObjectPropertyValue">The object property value.</param>
		/// <param name="Operator">The operator.</param>
		/// <param name="UserValue">The user value.</param>
		/// <returns>
		/// 	<c>true</c> if the specified object property value is ok; otherwise, <c>false</c>.
		/// </returns>
		private bool IsOk(DateTime ObjectPropertyValue , string Operator, DateTime UserValue)
		{
			bool Rt = false;
			
			if (Operator == "=")
			{
				if (ObjectPropertyValue == UserValue) {Rt = true;}
			}
			else if (Operator == ">")
			{
				if (ObjectPropertyValue > UserValue) {Rt = true;}
			}
			else if (Operator == ">=")
			{
				if (ObjectPropertyValue >= UserValue) {Rt = true;}
			}
			else if (Operator == "<")
			{
				if (ObjectPropertyValue < UserValue) {Rt = true;}
			}
			else if (Operator == "<=")
			{
				if (ObjectPropertyValue <= UserValue) {Rt = true;}
			}
			else
			{
				
				throw new Exception("The operator '" + Operator + "' does not match the type DateTime !");
			}
			return Rt;
		}
		
		/// <summary>
		/// Determines whether the specified object property value is ok.
		/// </summary>
		/// <param name="ObjectPropertyValue">if set to <c>true</c> [object property value].</param>
		/// <param name="Operator">The operator.</param>
		/// <param name="UserValue">if set to <c>true</c> [user value].</param>
		/// <returns>
		/// 	<c>true</c> if the specified object property value is ok; otherwise, <c>false</c>.
		/// </returns>
		private bool IsOk(bool ObjectPropertyValue , string Operator, bool UserValue)
		{
			bool Rt = false;
			
			if (Operator == "=")
			{
				if (ObjectPropertyValue == UserValue) {Rt = true;}
			}
			else
			{
				throw new Exception("The operator '" + Operator + "' does not match the type string !");
			}
			return Rt;
		}
		
		/// <summary>
		/// Determines whether the specified operator is ok.
		/// </summary>
		/// <param name="Operator">The operator.</param>
		/// <param name="UserValue">The user value.</param>
		/// <returns>
		/// 	<c>true</c> if the specified operator is ok; otherwise, <c>false</c>.
		/// </returns>
		private bool IsOk(string Operator, object UserValue)
		{
			bool Rt = false;
			
			if (UserValue.ToString().ToUpper() == "NULL" & Operator == "=" )
			{
				Rt = true;
			}
			return Rt;
		}
		
		/// <summary>
		/// Corrects the user value.
		/// </summary>
		/// <param name="UserValue">The user value.</param>
		/// <returns></returns>
		private string CorrectUserValue(string UserValue)
		{
			if (UserValue.Substring(0,1)  == "'")
			{
				UserValue =UserValue.Replace("'", "");
			}
			
			if (UserValue.Substring(0,1)  == "#")
			{
				UserValue =UserValue.Replace("#", "");
			}

			return UserValue;
		}
		
		/// <summary>
		/// Determines whether the specified object property value is ok.
		/// </summary>
		/// <param name="ObjectPropertyValue">The object property value.</param>
		/// <param name="Operator">The operator.</param>
		/// <param name="UserValue">The user value.</param>
		/// <returns>
		/// 	<c>true</c> if the specified object property value is ok; otherwise, <c>false</c>.
		/// </returns>
		private bool IsOk(object ObjectPropertyValue , string Operator, string UserValue)
		{
			bool Rt = false ;
			
			//Type of the property value
			if (ObjectPropertyValue == null)
			{
			}
			
			Type TypeOfValue = ObjectPropertyValue.GetType();
			//Object FilterValue  = Convert.ChangeType(CorrectUserValue(UserValue),TypeOfValue) ;
			Object FilterValue  = CorrectUserValue(UserValue) ;
			
			if (TypeOfValue ==typeof(string))
			{
				Rt = IsOk((string)ObjectPropertyValue, Operator, (string) FilterValue);
			}
			else if (TypeOfValue ==typeof(int))
			{
				Rt = IsOk((int)ObjectPropertyValue, Operator, (int) Convert.ToInt32(FilterValue));
			}
			else if (TypeOfValue == typeof(double))
			{
				Rt = IsOk((double)ObjectPropertyValue, Operator, (double)Convert.ToDouble(FilterValue));
			}
			else if (TypeOfValue == typeof(decimal))
			{
				Rt = IsOk((decimal)ObjectPropertyValue, Operator, (decimal)Convert.ToDecimal( FilterValue));
			}
			else if (TypeOfValue == typeof(DateTime))
			{
				Rt = IsOk((DateTime)ObjectPropertyValue, Operator, (DateTime) Convert.ToDateTime(FilterValue));
			}
			else if (TypeOfValue == typeof(bool))
			{
				Rt = IsOk((bool)ObjectPropertyValue, Operator, (bool) Convert.ToBoolean (FilterValue));
			}
			else if (TypeOfValue == typeof(Guid))
			{
				Rt = IsOk((Guid)ObjectPropertyValue, Operator, new Guid(FilterValue.ToString()));
			}
			else if (TypeOfValue == typeof(decimal))
			{
				Rt = IsOk((decimal)ObjectPropertyValue, Operator, (decimal) Convert.ToDecimal(FilterValue));
			}
			else if (TypeOfValue == typeof(byte))
            { 
				Rt = IsOk((byte)ObjectPropertyValue, Operator, (byte)Convert.ToByte(FilterValue)); 
			}
			else if (TypeOfValue == typeof(System.Int16))
            { 
				Rt = IsOk((System.Int16)ObjectPropertyValue, Operator, (System.Int16)Convert.ToInt16(FilterValue)); 
			}
			else
			{throw new Exception("Filtering is not possible on the type " + TypeOfValue.ToString());}
			return Rt;
		}
		
		/// <summary>
		/// Applies the filter.
		/// </summary>
		/// <param name="objToFilter">The obj to filter.</param>
		/// <param name="filterdItemsBackupList">The filterd items backup list.</param>
		/// <param name="itemType">Type of the item.</param>
		/// <param name="StrFilter">The STR filter.</param>
		public void ApplyFilter(object objToFilter, IList filterdItemsBackupList, Type itemType, string StrFilter)
		{
			
			//DateTime D1 = DateTime.Now ;

			IList ObjectToFilter = (IList)objToFilter;
			int CountValue = ObjectToFilter.Count;
			Expressions ListOfExpressions = new Expressions(StrFilter);


			//Loading items of the collection
			bool [] Validations;
			bool AllIsOK;
			
			PropertyInfo [] PropsInfo = new PropertyInfo[ListOfExpressions.Count ];
			for(int x = 0; x< ListOfExpressions.Count;x++)
			{
				PropsInfo	[x] = itemType.GetProperty (ListOfExpressions.Item(x).PropertyName,BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase );
				if( PropsInfo[x] == null) 
				{
					throw new Exception ("property " + ListOfExpressions.Item(x).PropertyName + " does not exist!");
				}
			}
			
			for (int f = 0; f<= (ObjectToFilter.Count -1); f++)
			{
				object CollectionItem = ObjectToFilter[f];
				Type TypeOfItem = CollectionItem.GetType();

				Validations = new bool[ListOfExpressions.Count ];
				AllIsOK = true;

				for (int t = 0 ; t<= ListOfExpressions.Count -1 ; t++)
				{
					PropertyInfo ItemProperty = PropsInfo[t];
					object PropertyValue = ItemProperty.GetValue(CollectionItem, new object[0]);

					if (PropertyValue ==null)
					{
						Validations[t] = IsOk(ListOfExpressions.Item(t).Operator , ListOfExpressions.Item(t).UserValue );
					}
					else
					{
						Validations[t] = this.IsOk(PropertyValue, ListOfExpressions.Item(t).Operator , ListOfExpressions.Item(t).UserValue );
					}
					if (Validations[t] == false)
					{AllIsOK = false;}
					//System.Diagnostics.Trace.WriteLine("time : " + (DateTime.Now - timeSt1).TotalMilliseconds.ToString() + " cicle : " + cicle.ToString());
					//timeSt1 = DateTime.Now;
					//cicle++;
				}

				if (AllIsOK == false)
				{
					ObjectToFilter.Remove(CollectionItem);
					filterdItemsBackupList.Add(CollectionItem);
					CountValue -= 1;
					f -= 1;
				}
			}
	
			//DateTime D2= DateTime.Now ;
			//Console.WriteLine((D2-D1).ToString());
		}
	}
}

using System;
using System.Reflection;
using System.Collections.Generic;


namespace SerpisAd
{
	public class Persister
	{
		public static int Insert (object obj){
			Console.WriteLine ("Persister.Insert");
			Type type = obj.GetType ();
			string [] fieldNames = getFieldNames(type);
			string[] paramNames = getParamNames (fieldNames);
			Console.WriteLine (string.Join (",", fieldNames));
			Console.WriteLine (string.Join (",", paramNames));
			string insertSql = "insert into {0} ({1}) values ({2})";
			Console.WriteLine(insertSql,tableName,string.Join(",", fieldNames), string.Join(",",fieldNames);
			return 0;
		}
		private static void addParameters(IDbCommand dbCommand, object obj){
		}
		private static string [] getFieldNames(Type type){
			List<string> fieldNames = new List <string> ();
			PropertyInfo[] propertyInfos = type.GetProperties();
			foreach (PropertyInfo propertyInfo in propertyInfos)
				if (!propertyInfo.Name.Equals ("Id"))
					fieldNames.Add (propertyInfo.Name);
			Console.WriteLine (string.Join (",", fieldNames));
			return fieldNames.ToArray ();
	}
		private static string [] getParamNames(string[]fieldNames){
			List<string> paramNames = new List <string> ();
			foreach (string fieldName in fieldNames)
				paramNames = ('@' + fieldName);
			return paramNames.ToArray ();
}
	}
}

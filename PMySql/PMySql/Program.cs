using System;
using MySql.Data.MySqlClient;

namespace PMySql
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			MySqlConnection mySqlConnection = new MySqlConnection(
				//Cadena de conexión//
				"Database=dbprueba;Data Source=localhost;User Id=root;Password=sistemas"
				);
			//Abrimos la conexión para poder realizar los cambios que queremos
			mySqlConnection.Open ();
			//Creamos un comando con funciones de mysql
			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
			mySqlCommand.CommandText = "select * from articulo";
			//Creamos el Reader para que lee el comando
			MySqlDataReader mysqlDR= mySqlCommand.ExecuteReader();
			//Cerramos tanto el reader como la conexión
			showColumnNames (mysqlDR);
			Console.WriteLine (" ");
			show(mysqlDR);
			mysqlDR.Close ();
			mySqlConnection.Close ();
			}
			private static void showColumnNames (MySqlDataReader mysqlDR){
			for (int i = 0; i < mysqlDR.FieldCount; i++) {
				Console.WriteLine ("Columna {0} {1}", i, mysqlDR.GetName (i));
				//console.writeline("showColumnNames...");
				//string [] columnNames = getColumnNames(mysqlDR);
				//foreach (string columnName in columnNames)
					//Console.WriteLine("columna=" + columnName
			}
			}
		//public static string[] getColumnNames (MySqlDataReader myslDR){
		//int count = myslDR.FieldCount;
		//string[] columNames = new string[count];
		//for (int index = 0; index < mysqlDR.FieldCount; index++)
		// ColumnNames [index] = mysqlDR.GetName(index);
		// return columnNames;
	
		private static void show (MySqlDataReader mysqlDR){
			while (mysqlDR.Read()) {
				for (int i=0; i<mysqlDR.FieldCount; i++) {
					Console.Write ("{0} {1}  ", mysqlDR.GetName (i), mysqlDR [mysqlDR.GetName (i)]);
				}
				Console.WriteLine (" ");
			}
			}
		
	}

}






using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace PMySql
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			MySqlConnection mySqlConnection = new MySqlConnection (
				"Database=dbprueba;Data Source=localhost;User Id=root;Password=sistemas"
				);
			mySqlConnection.Open ();

			updateDatabase (mySqlConnection);

			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
			mySqlCommand.CommandText = "select * from articulo";
			//				"select " +
			//				"a.categoria as articulocategoria, " +
			//				"c.nombre as categorianombre, " +
			//				"count(*) as numeroarticulos " +
			//				"from articulo a " +
			//				"left join categoria c " +
			//				"on a.categoria = c.id " +
			//				"group by articulocategoria, categorianombre";

			MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();

			showColumnNames (mySqlDataReader);
			show (mySqlDataReader);

			mySqlDataReader.Close ();

			mySqlConnection.Close ();
		}

		private static void updateDatabase(MySqlConnection mySqlConnection) {
			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
			mySqlCommand.CommandText = "insert into articulo (nombre, categoria) values ('artículo nuevo', 1)";
			mySqlCommand.ExecuteNonQuery ();
		}

		private static void showColumnNames(MySqlDataReader mySqlDataReader) {
			Console.WriteLine ("showColumnNames...");
			string[] columnNames = getColumnNames (mySqlDataReader);
			Console.WriteLine (string.Join (", ", columnNames));

		}

		public static string[] getColumnNames(MySqlDataReader mySqlDataReader) {
			//			int count = mySqlDataReader.FieldCount;
			//			string[] columnNames = new string[count];
			//			for (int index = 0; index < count; index++) 
			//				columnNames [index] = mySqlDataReader.GetName (index);
			//			return columnNames;

			int count = mySqlDataReader.FieldCount;
			List<string> columnNames = new List<string> ();
			for (int index = 0; index < count; index++)
				columnNames.Add (mySqlDataReader.GetName (index));
			return columnNames.ToArray();
		}

		private static void show(MySqlDataReader mySqlDataReader) {
			Console.WriteLine ("show...");
			while (mySqlDataReader.Read()) 
				showRow (mySqlDataReader);

		}

		private static void showRow(MySqlDataReader mySqlDataReader) {
			int count = mySqlDataReader.FieldCount;
			string line = "";
			for (int index = 0; index < count; index++)
				line = line + mySqlDataReader [index] + " ";

			Console.WriteLine (line);
		}
	}
}		
		

/*
                
ColumnTotal = treeview.Columns.Length; 
for (Index = 0; Index < ColumnTotal; Index++)  //remove existing columns 
{ 
Console.WriteLine("disposed: Column " + treeview.Columns[0].Title); 

treeview.Columns[0].Dispose(); 
treeview.Columns[0] = null; 
treeview.RemoveColumn(treeview.Columns[0]); 
} 
                
if (store != null) 
{ 
store.Dispose(); 
store = null; 
                        
Console.WriteLine("disposed: store"); 
}	


TreeViewColumn tvcol = new TreeViewColumn();   
CellRendererText tcellr = new CellRendererText(); 
tcellr.BackgroundGdk =  new Gdk.Color(220,220,220); 
tvcol.Title = "";	
tvcol.PackStart(tcellr, true); 
tvcol.AddAttribute(tcellr, "text", 0); 
treeview.AppendColumn(tvcol); 
                        
for (Index = 0; Index < reader.FieldCount; Index++) //iterate through 
each field of the database 
{ 
FieldName = reader.GetName(Index); //get the query results field names 
defined under strSQL 
                                
TreeViewColumn col = new TreeViewColumn();  // add columns for each 
field 
CellRendererText colr = new CellRendererText(); 
colr.Editable = true; //Make every single Cell editable 
colr.Edited += CellEdit; 
                                
col.Title = FieldName;  //title the column with the field names 
retrieved by the query 
col.PackStart(colr, true); 
col.AddAttribute(colr, "text", Index+1); 
treeview.AppendColumn(col); //Add the Column to the Treeview 
} 
                        
//create array of strings one for each column 
System.Type[] Fields = new System.Type[treeview.Columns.Length]; 

for (Index = 0; Index < treeview.Columns.Length; Index++) 
{ 
Fields[Index] = typeof(string); //set each type to string 
} 
                        
//The ListStore is a columned list data structure to be used with 
TreeView widget. 
store = new ListStore(Fields);  //initialise store with columns 
treeview.Model = store; //setup treeview with store 
//The TreeIter is the primary structure for accessing a tree row 
TreeIter iter = new TreeIter(); 
//add the data from the query to the treeview 
string[] FieldArray = new string[treeview.Columns.Length]; 
int RowCount = 0; 
while(reader.Read()) //read through reach row in result set returned by 
the query 
{ 
RowCount += 1; 
FieldArray[0] = RowCount.ToString(); //first column displays the row 
count 
                                
for (Index = 1; Index < treeview.Columns.Length; Index++) 
{ 
FieldArray[Index] = reader.GetString(Index-1); //get the data from the 
result set 
FieldArray[Index] = FieldArray[Index].Trim(); 
                                }	
iter = store.AppendValues(FieldArray); //add row to treeview 
} 




using System;
using System.Collections.Generic;
using Gtk;
using MySql.Data.MySqlClient;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		Console.WriteLine ("MainWindow ctor.");
		MySqlConnection mySqlConnection = new MySqlConnection (
			"Database=dbprueba;Data Source=localhost;User Id=root;Password=sistemas"
		);

		mySqlConnection.Open ();

		MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
		mySqlCommand.CommandText = "select * from articulo";
		MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader ();
		//treeView.AppendColumn ("id", new CellRendererText (), "text", 0);
		//treeView.AppendColumn ("nombre", new CellRendererText (), "text", 1);

		//Así introducimos los índices de todas las columnas
		string[] columnNames = getColumnNames (mySqlDataReader);
		for(int index=0; index<columnNames.Length; index ++)
			treeView.AppendColumn (columnNames [index], new CellRendererText (), "text", index);

		//ListStore listStore = new ListStore (typeof(String), typeof(String));
		Type[] types= getTypes (mySqlDataReader.FieldCount);
		ListStore listStore = new ListStore (types);

		while (mySqlDataReader.Read()) {
			//listStore.AppendValues (mySqlDataReader [0].ToString (), mySqlDataReader [1].ToString ());
			string[] values = getValues (mySqlDataReader);
			listStore.AppendValues (values);
		}

		mySqlDataReader.Close ();

		treeView.Model = listStore;

		mySqlConnection.Close ();
	

	}
		
	private string[] getColumnNames(MySqlDataReader mySqlDataReader) {
		int count = mySqlDataReader.FieldCount;
		List<string> columnNames = new List<string> ();
		for (int index = 0; index < count; index++)
			columnNames.Add (mySqlDataReader.GetName (index));
		return columnNames.ToArray();
	} 
	//Metodo que devuelve un array con los tipos, para saber cuántos, no variedad de tipos.
	private Type[]getTypes(int count ){
		//Construímos una lista para añadir los tipos.
		List<Type> types = new List<Type> ();
		for (int i=0; i< count; i++) 
			types.Add (typeof(string));
		return types.ToArray ();
	}
	private string [] getValues (MySqlDataReader mySqlDataReader){
		int count = mySqlDataReader.FieldCount;
		List <String> values = new List <string> ();
		for (int i=0; i< count; i++)
			values.Add (mySqlDataReader [i].ToString ());
		return values.ToArray ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a){
		Application.Quit ();
		a.RetVal = true;
		}
		
	}//			
		
		/*
		string[] values = new String[2];
		values [0] = "2";
		values [1] = "Nombre del segundo";
		listStore.AppendValues (values);
		listStore = new ListStore (typeof(ulong), typeof(string), 
		typeof(string), typeof(decimal));
		treeView.Model = listStore;
		*/

		//Cuando las columnas son id y nombre.
		/*while (mySqlDataReader.Read()) {
			listStore.AppendValues (mySqlDataReader [0].ToString (), mySqlDataReader [1].ToString ());
			treeView.Model = listStore;
		}*/
		//listStore.AppendValues (id);
		//typeof(string), typeof(decimal)

//		//añado columnas

//		//establezco el modelo
//		//Lo creamos
//		
//		
//		//Todo rellenarlistore
//		listStore.AppendValues ("1", "Nombre del primero");
//
//		treeView.Model = listStore;
//





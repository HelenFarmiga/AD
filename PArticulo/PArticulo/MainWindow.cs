using System;
using System.Data;
using System.Collections.Generic;
using Gtk;

using PArticulo;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		Console.WriteLine ("MainWindow ctor.");
		IDbConnection dbConnection = App.Instance.DbConnection;
		IDbCommand dbCommand =dbConnection.CreateCommand ();
		dbCommand.CommandText = "select * from articulo";
		IDataReader dataReader = dbCommand.ExecuteReader ();
		//treeView.AppendColumn ("id", new CellRendererText (), "text", 0);
		//treeView.AppendColumn ("nombre", new CellRendererText (), "text", 1);

		//Así introducimos los índices de todas las columnas
		string[] columnNames = getColumnNames (dataReader);
		for(int index=0; index<columnNames.Length; index ++)
			treeView.AppendColumn (columnNames [index], new CellRendererText (), "text", index);

		//ListStore listStore = new ListStore (typeof(String), typeof(String));
		Type[] types= getTypes (dataReader.FieldCount);
		ListStore listStore = new ListStore (types);

		while (dataReader.Read()) {
			//listStore.AppendValues (mySqlDataReader [0].ToString (), mySqlDataReader [1].ToString ());
			string[] values = getValues (dataReader);
			listStore.AppendValues (values);
		}

		dataReader.Close ();

		treeView.Model = listStore;

		dbConnection.Close ();
	

	}
		
	private string[] getColumnNames(IDataReader dataReader) {
		int count = dataReader.FieldCount;
		List<string> columnNames = new List<string> ();
		for (int index = 0; index < count; index++)
			columnNames.Add (dataReader.GetName (index));
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
	private string [] getValues (IDataReader dataReader){
		int count =  dataReader.FieldCount;
		List <String> values = new List <string> ();
		for (int i=0; i< count; i++)
			values.Add ( dataReader [i].ToString ());
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






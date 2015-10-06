using System;
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


		treeView.AppendColumn("id", new CellRendererText (), "text", 0);
		treeView.AppendColumn("nombre", new CellRendererText(),"text",1);

		ListStore listStore = new ListStore (typeof(String), typeof(String) );
		//Cuando las columnas son id y nombre.
		while (mySqlDataReader.Read())
				listStore.AppendValues (mySqlDataReader[0].ToString(), mySqlDataReader[1].ToString());
			
		treeView.Model = listStore;


		/*
		string[] values = new String[2];
		values [0] = "2";
		values [1] = "Nombre del segundo";
		listStore.AppendValues (values);
		listStore = new ListStore (typeof(ulong), typeof(string), 
		typeof(string), typeof(decimal));
		treeView.Model = listStore;
		*/
		//int count = mySqlDataReader.FieldCount;
		//long id;
		//
		//for (int i=0; i <count; i++){
		// id.Add(Colum*/

		//listStore.AppendValues (id);
		//typeof(string), typeof(decimal)
		mySqlDataReader.Close ();
		mySqlConnection.Close ();
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
	}


	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

}
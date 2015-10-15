using System;
using Gtk;

using PArticulo;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		Console.WriteLine ("MainWindow ctor.");
		QueryResult queryResult = PersisterHelper.Get ("select * from articulo");
		TreeViewHelper.Fill (treeView, queryResult);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}		
		
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






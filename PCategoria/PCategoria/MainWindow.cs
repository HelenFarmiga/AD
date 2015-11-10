using System;
using Gtk;

using SerpisAd;
using PCategoria;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		Console.WriteLine ("MainWindow ctor.");
		QueryResult queryResult = PersisterHelper.Get ("select * from categoria");
		TreeViewHelper.Fill (treeview1, queryResult);

		newAction.Activated += delegate {
			new CategoriaView();
		};
		refreshAction.Activated += delegate {
			//Creamos un array que contenga las columnas
			TreeViewColumn [] columnas = treeview1.Columns;
			//Recorremos las columnas
			for (int i=0; i<columnas.Length; i++)
				treeview1.RemoveColumn (columnas[i]);
			QueryResult queryresult = PersisterHelper.Get("select * from categoria");
			TreeViewHelper.Fill (treeview1, queryresult);
		};
	}
	

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}



}




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




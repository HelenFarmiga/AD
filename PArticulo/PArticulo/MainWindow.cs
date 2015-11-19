using System;
using Gtk;
using System.Collections;

using System.Data;
using SerpisAd;
using PArticulo;


public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		Console.WriteLine ("MainWindow ctor.");
		fillTreeView ();

		newAction.Activated += delegate {
			new ArticuloView();
		};

		refreshAction.Activated += delegate {
			fillTreeView();
		};
		
			deleteAction.Activated += delegate {
			object id=TreeViewHelper.GetId(treeView);
			Console.WriteLine("click ondeleteAction id={0}", id);
			delete(id);
		};


		editAction.Activated += delegate {
			object id=TreeViewHelper.GetId(treeView);
			Console.WriteLine("Edicion de la tabla seleccionada");
			new ArticuloView(id);
		};

		treeView.Selection.Changed += delegate {
			Console.WriteLine("ha ocurrido treeView.Selection.Changed");
			object id = TreeViewHelper.GetId (treeView);
			deleteAction.Sensitive = TreeViewHelper.IsSelected (treeView);
			editAction.Sensitive=TreeViewHelper.IsSelected (treeView);
		};
			deleteAction.Sensitive = false;
			editAction.Sensitive = false;
	}
		
	private void delete (object id){
		if(WindowHelper.ConfirmDelete (this)){

		IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
		string borrar = string.Format("delete from articulo where id={0}", id);
		dbCommand.CommandText = borrar;
		dbCommand.ExecuteNonQuery();
			fillTreeView (); //Actualiza sólo
		};
	}

	private void fillTreeView() {
		QueryResult queryResult = PersisterHelper.Get ("select * from articulo");
		TreeViewHelper.Fill (treeView, queryResult);
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a){
		Application.Quit ();
		a.RetVal = true;
	}

}
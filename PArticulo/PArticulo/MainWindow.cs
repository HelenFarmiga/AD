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

		treeView.Selection.Changed += delegate {
			object id = TreeViewHelper.GetId (treeView);
			deleteAction.Sensitive = TreeViewHelper.IsSelected (treeView);
		};
			deleteAction.Sensitive = false;
	}
		
	private void delete (object id){
		if(ConfirmDelete(this)){
		Console.WriteLine("Dice que eliminar si");
		//Creamos un string que contenga comando para borrar
		IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
		string borrar = string.Format("delete from articulo where id={0}", id);
		dbCommand.CommandText = borrar;
		dbCommand.ExecuteNonQuery();
			fillTreeView (); //Actualiza sólo
		};
	}
	
	public bool ConfirmDelete (Window window){
		MessageDialog messageDialog = new MessageDialog(
		window,
		DialogFlags.DestroyWithParent,
		MessageType.Question,
		ButtonsType.YesNo,
				"Quieres eliminar el elemento seleccionado?"
					);
				messageDialog.Title = Title;
				ResponseType response = (ResponseType)messageDialog.Run ();
				messageDialog.Destroy ();
				return response == ResponseType.Yes;				
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
using System;
using System.Data;
using Gtk;
using System.Collections;

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

		deleteAction.Activated += delegate {
			object id=TreeViewHelper.GetId(treeview1);
			Console.WriteLine("click ondeleteAction id={0}", id);
			delete(id);
		};

		treeview1.Selection.Changed += delegate {
			object id = TreeViewHelper.GetId (treeview1);
			deleteAction.Sensitive = TreeViewHelper.IsSelected (treeview1);
		};
		deleteAction.Sensitive = false;
	}

		private void delete (object id){
			if(ConfirmDelete(this)){
				Console.WriteLine("Dice que eliminar si");
				//Creamos un string que contenga comando para borrar
				IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand();
				string borrar = string.Format("delete from categoria where id={0}", id);
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
		QueryResult queryResult = PersisterHelper.Get ("select * from categoria");
		TreeViewHelper.Fill (treeview1, queryResult);
	}
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}



}




using System;
using Gtk;

namespace PArticulo
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();

		}
	}
}


//
//			treeView.AppendColumn ("id", new CellRendererText (), "text", 0);
//			treeView.AppendColumn ("nombre", new CellRendererText (), "text", 1);
//			treeView.AppendColumn ("categoria", new CellRendererText (), "text", 2);
//		
  
//			listStore = new ListStore (typeof(ulong), typeof(string), 
//			                                   typeof(string), typeof(decimal));
//			treeView.Model = listStore;
//
//			fillListStore ();
//
//			treeView.Selection.Changed += selectionChanged;
//
//			refreshAction.Activated += delegate {
//				listStore.Clear();
//				fillListStore();
//			};
//
//			editAction.Activated += delegate {
//				new ArticuloView();
//
//			};
//
//			//TODO resto de actions
//		}
//		private void selectionChanged (object sender, EventArgs e) {
//			Console.WriteLine ("selectionChanged");
//			bool hasSelected = treeView.Selection.CountSelectedRows () > 0;
//			deleteAction.Sensitive = hasSelected;
//			editAction.Sensitive = hasSelected;
//		}
//
//		private void fillListStore() {
//			IDbCommand dbCommand = dbConnection.CreateCommand ();
//			dbCommand.CommandText = "select a.id, a.nombre, c.nombre as categoria, a.precio" +
//				" from articulo a left join categoria c on (a.categoria = c.id)";
//
//			IDataReader dataReader = dbCommand.ExecuteReader ();
//			while (dataReader.Read()) {
//				object id = dataReader ["id"];
//				object nombre = dataReader ["nombre"];
//				object categoria = dataReader ["categoria"].ToString();
//				object precio = dataReader ["precio"];
//				listStore.AppendValues (id, nombre, categoria, precio);
//			}
//			dataReader.Close ();
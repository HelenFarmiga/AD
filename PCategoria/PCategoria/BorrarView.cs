using System;

namespace PCategoria
{
	public partial class BorrarView : Gtk.Window
	{
		public BorrarView () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
		QueryResult queryResult = PersisterHelper.Get ("select * from categoria");
		TreeViewHelper.Fill(treeview1, queryResult);
	}
	private void borrar() {
		IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
		dbCommand.CommandText = "delete values (@nombre)";

		string command= "delete form categoria 
		string nombre = entry1.Text;
		DbCommandHelper.AddParameter (dbCommand, "nombre", nombre);
		dbCommand.ExecuteNonQuery();
		Destroy ();
	}
	protected void OnEventDeleted

}


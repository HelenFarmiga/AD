using System;
using Gtk;
using System.Collections;
using System.Data;
using SerpisAd;

namespace PCategoria
{
	public partial class CategoriaView : Gtk.Window
	{
		public CategoriaView () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
			QueryResult queryResult = PersisterHelper.Get ("select * from categoria");
			Guarda.Activated += delegate {	save();	};
		}
			private void save() {
				IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
				dbCommand.CommandText = "insert into categoria (nombre) values (@nombre)";
				string nombre = entry1.Text;
				DbCommandHelper.AddParameter (dbCommand, "nombre", nombre);
				dbCommand.ExecuteNonQuery();
				Destroy ();
			}
	}

}

	

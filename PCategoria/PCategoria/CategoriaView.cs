using System;
using Gtk;
using System.Collections;
using System.Data;
using SerpisAd;

namespace PCategoria
{
	public partial class CategoriaView : Gtk.Window
	{
		private object id;
		public CategoriaView () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
			QueryResult queryResult = PersisterHelper.Get ("select * from categoria");
			Guarda.Activated += delegate {	save();	};
		}
		public CategoriaView(object id) : this() {
			Title = "Borrar Categoria";
			this.id = id;
			load ();
		}

			private void save() {
				IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
				dbCommand.CommandText = "insert into categoria (nombre) values (@nombre)";
				string nombre = entry1.Text;
				DbCommandHelper.AddParameter (dbCommand, "nombre", nombre);
				dbCommand.ExecuteNonQuery();
				Destroy ();
			}
		private void load(){
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = "select * from categoria where id = @id";
			DbCommandHelper.AddParameter (dbCommand, "id", id);
			IDataReader dataReader = dbCommand.ExecuteReader ();
			if (!dataReader.Read ())
				//TODO throw exception
				return;
			string nombre = (string)dataReader ["nombre"];
			dataReader.Close ();
			entry1.Text = nombre;
		}	
	}
}
	



	

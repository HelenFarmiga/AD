using System;
using Gtk;
using System.Collections;
using System.Data;
using SerpisAd;

namespace PCategoria{	
	public delegate void SaveDelegate();
	public partial class CategoriaView : Gtk.Window
	{
		private object id = null;
		private string nombre = "";
		private SaveDelegate save;
		
		public CategoriaView () : base(Gtk.WindowType.Toplevel) {
			init ();
			save = insert;
		}

		public CategoriaView(object id) : base(Gtk.WindowType.Toplevel) {
			this.id = id;
			load ();
			init ();
			save = update;
		}
		private void init (){
			this.Build ();
			entry1.Text = nombre;
			Guardar.Activated += delegate {	
				save();	
			};
		}

		private void load(){
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = "select * from categoria where id = @id";
			DbCommandHelper.AddParameter (dbCommand, "id", id);
			IDataReader dataReader = dbCommand.ExecuteReader ();
			if (!dataReader.Read ())
				return;
			nombre = (string)dataReader ["nombre"];
			dataReader.Close ();
		}
		
		private void insert(){
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = "insert into categoria (nombre) " +
				"values (@nombre)";
			nombre = entry1.Text;
			DbCommandHelper.AddParameter (dbCommand, "nombre", nombre);
			dbCommand.ExecuteNonQuery ();
			Destroy ();
		}
		
		private void update() {
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = "update categoria set nombre=@nombre where id = @id";
			nombre = entry1.Text;
			DbCommandHelper.AddParameter (dbCommand, "nombre", nombre);
			DbCommandHelper.AddParameter (dbCommand, "id", id);
			dbCommand.ExecuteNonQuery ();
			}
	}
}





		






	

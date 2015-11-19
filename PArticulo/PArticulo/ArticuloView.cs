using Gtk;
using System;
using System.Collections;
using System.Data;
using SerpisAd;

namespace PArticulo
{
	public partial class ArticuloView : Gtk.Window
	{
		private object id;
		private object categoria;

		// constructor principal
		public ArticuloView () : 
			base(Gtk.WindowType.Toplevel)
		{
			this.Build ();

			QueryResult queryResult = PersisterHelper.Get ("select * from categoria");
			ComboBoxHelper.Fill (comboBoxCategoria, queryResult);

			// evento boton guardar: llamamos al metodo
			saveAction.Activated += delegate {	
				guardar();	
			};
		}

		// otro cunstructor que llama al constructor anterior
		public ArticuloView(object id) : this() {
			this.id = id;
			load ();
		}

		private void load(){
			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = "select * from articulo where id = @id";
			DbCommandHelper.AddParameter (dbCommand, "id", id);
			IDataReader dataReader = dbCommand.ExecuteReader ();
			if (!dataReader.Read ())
				//TODO throw exception
				return;
			string nombre = (string)dataReader ["nombre"];
			categoria = dataReader ["categoria"];
			if (categoria is DBNull)
				categoria = null;
			decimal precio = (decimal)dataReader ["precio"]; // falla si hay un null (se puede arreglar con ?decimal)
			dataReader.Close ();
			entryNombre.Text = nombre;
			//TODO posicionarse en el comboboxcategoria
			spinButtonPrecio.Value = Convert.ToDouble (precio);
		}

		private void guardar() {

			IDbCommand dbCommand = App.Instance.DbConnection.CreateCommand ();
			dbCommand.CommandText = "insert into articulo (nombre, categoria, precio) " +
				"values (@nombre, @categoria, @precio)";

			string nombre = entryNombre.Text;
			object categoria = ComboBoxHelper.GetId (comboBoxCategoria);
			decimal precio = Convert.ToDecimal(spinButtonPrecio.Value);

			DbCommandHelper.AddParameter (dbCommand, "nombre", nombre);
			DbCommandHelper.AddParameter (dbCommand, "categoria", categoria);
			DbCommandHelper.AddParameter (dbCommand, "precio", precio);

			dbCommand.ExecuteNonQuery ();
			Destroy ();
		}
	}
}
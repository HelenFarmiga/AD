package org.institutoserpis.ad;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Scanner;
import java.sql.ResultSetMetaData;

public class PruebaArticulo {
	private static Scanner tcl = new Scanner(System.in);
	public static void main(String[] args) throws SQLException{ 
			
			Connection connection = DriverManager.getConnection( "jdbc:mysql://localhost/dbprueba", "root", "sistemas" );
			Statement statment = (Statement) connection.createStatement();
	
			
			int menu=-1;
			System.out.println("0.- Salir");
			System.out.println("1.- Leer");
			System.out.println("2.- Nuevo");
			System.out.println("3.- Editar");
			System.out.println("4.- Eliminar");
			System.out.println("5.- Mostrar todos los datos");
			
			do{
				menu= tcl.nextInt();
				switch(menu){
				case 0:
				System.out.println("¡Adios!");
				break;
				case 1:
					Filas(connection, statment);
					break;
				case 2:
					Insert(connection);
					break;
				case 3:
					Update(connection,"Articulo 2", 2);
					break;
				case 4:
					Delete(connection);
					break;
				case 5:
					ShowColumns(connection, statment);
					break;
				default:
					System.out.println("Error. Opción erronea");
				}
	
			}while(menu !=0);
			connection.close();
					
		}


		public static void Filas(Connection connection,Statement statement) throws SQLException {
			System.out.println("Introduce el id del articulo:");
			int id = tcl.nextInt();
					
			ResultSet resultSet = statement.executeQuery("SELECT * FROM articulo WHERE id = " + id);
			
			while ( resultSet.next() ) {
	            String nomArticulo       = resultSet.getString("nombre");
	            String idArticulo        = resultSet.getString("id");
	            String categoriaArticulo = resultSet.getString("categoria");
	            String precioArticulo    = resultSet.getString("precio");
	            
	            System.out.println( "Nombre: "     + nomArticulo       +
	            					" Id: "        + idArticulo        + 
	            					" Categoria: " + categoriaArticulo +
	            					" Precio: "    + precioArticulo);
	            
			}
		}

		public static void ShowColumns(Connection connection, Statement statement) throws SQLException {
			ResultSet resultSet = statement.executeQuery("SELECT nombre, id, categoria, precio FROM articulo");
			ResultSetMetaData resultSetMetaData = (ResultSetMetaData) resultSet.getMetaData();
			int numColumnas = resultSetMetaData.getColumnCount();

			for (int i=1; i <= numColumnas; i++ ) {
				String nombreColumna = resultSetMetaData.getColumnName(i);
				System.out.println(nombreColumna);
			}
		}
		public static void Insert(Connection con) throws SQLException {
			System.out.println("Nombre artículo: ");
			String name =tcl.nextLine();
			System.out.println("Precio artículo:");
			String precio = tcl.nextLine();
			System.out.println("Categoria artículo:");
			int categoria = tcl.nextInt();
			
			
			
			String query = "INSERT INTO articulo (nombre, categoria, precio) VALUES ("+ name + "," + categoria + "," + precio + ")";
			
		    PreparedStatement preparedStmt = (PreparedStatement) con.prepareStatement(query);
		    preparedStmt.executeUpdate();
		}
		
	
	public static void Delete(Connection con) throws SQLException {		
		    /*PreparedStatement pstatement = (PreparedStatement) con.prepareStatement(
		    		"DELETE FROM articulo WHERE nombre = ?");
		    pstatement.setString(1, nombre);
		    pstatement.executeUpdate();*/
		System.out.println("Id del articulo:");
		int id = tcl.nextInt();
		
		String query = "DELETE FROM articulo WHERE id = " + id;
	    PreparedStatement preparedStmt = (PreparedStatement) con.prepareStatement(query);
	    preparedStmt.executeUpdate();
		}
	
	public static void Update(Connection con, String nombre, int id) throws SQLException {
	    PreparedStatement pstatement = (PreparedStatement) con.prepareStatement(
	    		"UPDATE articulo SET nombre = ? WHERE id = ?");
	    pstatement.setString(1, nombre);
	    pstatement.setInt(2, id);
	    pstatement.executeUpdate();
	    
	}

		
}





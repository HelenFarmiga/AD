package org.institutoserpis.ad;

import java.math.BigDecimal;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Scanner;

import javax.swing.JOptionPane;

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
					Update(connection);
					break;
				case 4:
					Delete(connection);
					break;
				case 5:
					ShowAllF(connection, statment);
					break;
				default:
					System.out.println("Error. Opción erronea");
				}
	
			}while(menu !=0);
			connection.close();		
		}

		public static void Filas(Connection connection,Statement statement) throws SQLException {
			System.out.println("Id del articulo a mostrar:");
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
		public static void Insert(Connection con) throws SQLException {
			tcl.nextLine();
			System.out.println("Nombre artículo: ");
			String nombre =tcl.nextLine();
		
			System.out.println("Categoria artículo:");
			int categoria = tcl.nextInt();
			tcl.nextLine();
			
			System.out.println("Precio artículo:");
			String precio = tcl.nextLine();
			
			
			
			String query = "INSERT INTO articulo (nombre, categoria, precio) VALUES (?,?,?)";
			String mensaje = "Los datos se han Modificado de Manera Satisfactoria";
			
		    PreparedStatement pstatement = (PreparedStatement) con.prepareStatement(query);
		    pstatement.setString(1,nombre);
			pstatement.setInt(2,categoria);
			pstatement.setString(3,precio);
	
		   

		  int i =  pstatement.executeUpdate();
		   if(i>0){
		    JOptionPane.showMessageDialog(null, mensaje);
			}
		}

		public static void ShowAllF(Connection connection, Statement statement) throws SQLException {
			
			ResultSet resultSet = statement.executeQuery("SELECT * FROM articulo");
			
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
		
		
	
	public static void Delete(Connection connection) throws SQLException {		
		System.out.println("Id del articulo:");
		int id = tcl.nextInt();
		
		String query = "DELETE FROM articulo WHERE id = " + id;
	    PreparedStatement pstatement = (PreparedStatement) connection.prepareStatement(query);
	    pstatement.executeUpdate();
		}
	
	public static void Update(Connection connection)  throws SQLException {
		System.out.println("Id artículo a actualizar: ");
		tcl.nextLine();
		int id = tcl.nextInt();
	
		System.out.println("Nombre artículo: ");
		String name =tcl.nextLine();
		tcl.nextLine();
		
		System.out.println("Categoria artículo:");
		int categoria = tcl.nextInt();
		tcl.nextLine();
		System.out.println("Precio artículo: ");
		String precio = tcl.nextLine();
	    
		PreparedStatement pstatement = (PreparedStatement) connection.prepareStatement(
	    		"UPDATE articulo SET nombre = ?, categoria = ?, precio =? WHERE id =?");
		String mensaje = "Los datos se han Modificado de Manera Satisfactoria";
		
		
		pstatement.setString(1,name);
		pstatement.setInt(2,categoria);
		pstatement.setString(3,precio);
		pstatement.setInt(4,id);
	   
	    int i =  pstatement.executeUpdate();
	    if(i>0){
	    	JOptionPane.showMessageDialog(null, mensaje);
		}


		
}
}




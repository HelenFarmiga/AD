package org.institutoserpis.ad;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;



public class PruebaArticulo {
	
	public static void main (String [] args) throws SQLException{
		
		Connection connection = DriverManager.getConnection(
				"jdbc:mysql://localhost/dbprueba","root","sistemas");
		Statement statement= connection.createStatement();
		ResultSet resultSet = statement.executeQuery("SELECT * FROM articulo");
		
		while (resultSet.next() ) {
			   int Id= resultSet.getInt("id");
			   String Nombre= resultSet.getString("nombre");
			   int Categoria= resultSet.getInt("categoria");
			   String Precio= resultSet.getString("precio");
			   
			   System.out.println(  "Id: "+ Id +"\n" + 
					   				"Nombre: "+Nombre+
					   			  
			   					   " Categoria: " + Categoria +
			   					   " Precio: "    + Precio);
			}
		connection.close();
		System.out.println("fin");
	}			
	

			}
		
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
	
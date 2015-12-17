package org.institutoserpis.ad;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;

import com.mysql.jdbc.Statement;

public class PruebaArticulo {
	
	public static void main (String [] args) throws SQLException{
		
		Connection connection = DriverManager.getConnection(
				"jdbc:mysql://localhost/dbprueba","root","sistemas");
		connection.close();
		System.out.println("fin");
	}			
	

		public  void MostarArticulo (Connection connection, Statement statement) throws SQLException {
			String instruccion = "SELECT * FROM articulo";
			ResultSet resultSet = statement.executeQuery(instruccion);
		}
	}
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
	
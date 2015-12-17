package org.institutoserpis.ad;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.sql.ResultSetMetaData;

public class PruebaArticulo {
	
	public static void main (String [] args) throws SQLException{
		
		Connection connection = DriverManager.getConnection(
				"jdbc:mysql://localhost/dbprueba","root","sistemas");
		Statement statement= connection.createStatement();
		ResultSet resultSet = statement.executeQuery("SELECT * FROM articulo");
		ArrayList<String> nombres = new ArrayList<String>();
		ResultSetMetaData meta = resulset.getMetaData();
		
		int colum=meta.getColumnCount();
		
		for(int i = 1; i<=colum;i++){
			nombres.add(meta.getColumnName(i));
		}
		
		while(resulset.next()){
			ArrayList<Object> lista = new ArrayList<Object>();
			for(int i = 0; i<colum;i++){
				lista.add(resulset.getObject(nombres.get(i)));
			}
			for(int i = 0; i<colum;i++){
			System.out.print(nombres.get(i)+" : "+lista.get(i).toString()+"\t");
			}
			System.out.println();
		}
				
		connection.close();
		System.out.println("fin");
	}			
	
	public static void showColumns(Connection connection, Statement statement) throws SQLException {
		ResultSet resultSet = statement.executeQuery("SELECT  id, nombre, categoria, precio FROM articulo");
		ResultSetMetaData resultSetMetaData = resultSet.getMetaData();
		int numColumnas = resultSetMetaData.getColumnCount();

		for (int i=1; i <= numColumnas; i++ ) {
		  String nombreColumna = resultSetMetaData.getColumnName(i);
		  System.out.println(nombreColumna);
		}
			}
		
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
			 
	

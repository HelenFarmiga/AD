package org.institutoserpis.ad;
import java.util.Date;
import java.util.List;
import java.util.logging.*;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

	
public class PruebaHibernate {
	public static void main(String[] args) { 
		Logger.getLogger("org.hibernate").setLevel(Level.SEVERE);  
				System.out.println("inicio");
				EntityManagerFactory entityManagerFactory = 
						Persistence.createEntityManagerFactory("org.institutoserpis.ad");
				
				EntityManager entityManager = entityManagerFactory.createEntityManager();
				entityManager.getTransaction().begin();
				Articulo articuloNuevo = new Articulo();
				articuloNuevo.setNombre("nuevo " + new Date());
				entityManager.persist(articuloNuevo);
				
				List<Articulo> articulos = entityManager.createQuery("from Articulo", Articulo.class).getResultList();
				for (Articulo articulo : articulos)
					System.out.printf("%5s %-30s %5s %10s\n", 
							articulo.getId(), 
							articulo.getNombre(), 
							articulo.getCategoria(), 
							articulo.getPrecio()
					);
				entityManager.getTransaction().commit();
				entityManager.close();
				
				entityManagerFactory.close();
			
	}
	
	private static void query(){}
	}
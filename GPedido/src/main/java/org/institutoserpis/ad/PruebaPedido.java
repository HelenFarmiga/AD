package org.institutoserpis.ad;

import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class PruebaPedido {
	private static EntityManagerFactory entityManagerFactory;
	public static void main(String[] args) {
		Logger.getLogger("org.hibernate").setLevel(Level.SEVERE);
		System.out.println("inicio");
		entityManagerFactory = 
				Persistence.createEntityManagerFactory("org.institutoserpis.ad");
		
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		List<Cliente> clientes = entityManager.createQuery("from Cliente", Cliente.class).getResultList();
			for (Cliente cliente : clientes)
			System.out.println(cliente);
			entityManager.getTransaction().commit();
			entityManager.close();
		
		entityManagerFactory.close();
		System.out.println("fin");
	}

	}



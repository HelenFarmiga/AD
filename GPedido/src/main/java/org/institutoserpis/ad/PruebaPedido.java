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
		query();
		entityManagerFactory.close();
		System.out.println("fin");
	}
	private static void query() {
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		List<Pedido> Pedidos = entityManager.createQuery("from Pedido", Pedido.class).getResultList();
			for (Pedido Pedido : Pedidos)
			System.out.println(Pedido);
		entityManager.getTransaction().commit();
		entityManager.close();
		}
	}



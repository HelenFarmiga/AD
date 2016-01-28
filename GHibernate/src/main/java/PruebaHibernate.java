	import java.math.BigDecimal;
	import java.util.List;
	import java.util.Scanner;

	import javax.persistence.EntityManager;
	import javax.persistence.EntityManagerFactory;
	import javax.persistence.Persistence;
	
public class PruebaHibernate {
	public static void main(String[] args) { 
				System.out.println("inicio");
				EntityManagerFactory entityManagerFactory = 
						Persistence.createEntityManagerFactory("org.institutoserpis.ad");
				
				EntityManager entityManager = entityManagerFactory.createEntityManager();
				entityManager.getTransaction().begin();
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
			
			
			Scanner tcl = new Scanner(System.in);
	        int menu = -1;
	        System.out.println("0.- Salir");
			System.out.println("1.- Leer");
			System.out.println("2.- Nuevo");
			System.out.println("3.- Editar");
			System.out.println("4.- Eliminar");
			System.out.println("5.- Mostrar todos los datos");
            System.out.println("Selecciona una opción:");
            menu=tcl.nextInt();
	        
	        do{
	            switch (menu) {
	                case 0: 
	                	System.out.println("Has salido"); 
	                    break;
	                case 1: 
	                	ShowAr();
	                    break;
	                case 2: 
	                	Insert();
	                    break;
	                case 3: 
	                	edit();
	                    break;
	                case 4: 
	                	delete();
	                    break;
	                case 5: 
	                	ShowALL();
	                    break;
	                default: 
	                    System.out.println("Opción inválida");
	            }
	        	} while (menu != 0);
	        	tcl.close();
	        	entityManager.getTransaction().commit();
	        	entityManager.close();
	        	entityManagerFactory.close();
		}
		
	}

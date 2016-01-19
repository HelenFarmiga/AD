import java.math.BigDecimal;

public class Articulo {
private long id;
private String nombre;
private long categoria;
private BigDecimal precio;
	public Articulo(){
		
	}
	public Articulo(long id, String nombre, long categoria, BigDecimal precio ){
		this.id= id;
		this.nombre = nombre;
		this.categoria= categoria;
		this.precio=precio;
}
    public long getId() {
		return id;
    }

    public void setId(long id) {
		this.id = id;
    }
    public String getNombre() {
		return nombre;
    }

    public void setNombre(String nombre) {
		this.nombre = nombre;
    }

    public long getCategoria() {
		return categoria;
    }

    public void setCategoria(long Categoria) {
		this.categoria = categoria;
    }
    
    public BigDecimal getPrecio(){
    	return precio;
    }
    public void setPrecio(BigDecimal precio){
    	this.precio= precio;
    }
}
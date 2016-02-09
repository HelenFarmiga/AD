package org.institutoserpis.ad;

import java.math.BigDecimal;
import java.util.Calendar;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;

import org.hibernate.annotations.GenericGenerator;

@Entity
public class Pedido {
	private Long id;
	private Cliente cliente;
	private Calendar fecha;
	/*
	private BigDecimal importe;
	*/
	@Id
	@GeneratedValue(generator="increment")
	@GenericGenerator(name="increment", strategy = "increment")
	public Long getId() {
		return id;
	}
	public void setId(Long id) {
		this.id = id;
	}
	
	@ManyToOne
	@JoinColumn(name="cliente")
	public Cliente getCliente() {
		return cliente;
	}
	public void setCliente(Cliente cliente) {
		this.cliente = cliente;
	}
	public Calendar fecha(){
		return fecha;
	}
	
	public void setFecha(Calendar fecha){
		this.fecha = fecha;
	}
	/*
	public BigDecimal getImporte() {
		return importe;
	}
	
	public void setImporte(BigDecimal importe) {
		this.importe = importe;
	}
	*/
	public String toString(){
		return String.format("%s %-20s %s %s", id,cliente,fecha,importe);
	}
	
	
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlParacaidas : MonoBehaviour {

	public float imp_viento = 100f;
	public Rigidbody obj_paracaidas;
	public string objetivo_desaparicion = "plataforma";
	string direccion_x, direccion_z;

	void Start () {
		
		obj_paracaidas = GetComponent<Rigidbody> ();
		obj_paracaidas.drag = 1f; 

		if (transform.position.x < 0)
			direccion_x = "derecha";
		else if(transform.position.x > 0)
			direccion_x = "izquierda";
		if (transform.position.z < 0)
			direccion_z = "delante";
		else if (transform.position.z > 0)
			direccion_z = "atras";

		//print ("X: "+direccion_x.ToString()+"Z: "+direccion_z.ToString());
	}
	

	void Update ()
	{
		if (obj_paracaidas != null)
			add_viento (direccion_x,direccion_z);
		
	}
		

	void add_viento(string direccion_x, string direccion_z)
	{
		if(direccion_x == "derecha")
			obj_paracaidas.AddForce (new Vector3 (imp_viento*Time.deltaTime,0,0), ForceMode.Force);
		else if(direccion_x == "izquierda")
			obj_paracaidas.AddForce (new Vector3 (-imp_viento*Time.deltaTime,0,0), ForceMode.Force);
		if(direccion_z == "delante")
			obj_paracaidas.AddForce (new Vector3 (0,0,imp_viento*Time.deltaTime), ForceMode.Force);
		else if(direccion_z == "atras")
			obj_paracaidas.AddForce (new Vector3 (0,0,-imp_viento*Time.deltaTime), ForceMode.Force);
	}

	public void OnCollisionEnter(Collision obj_col)
	{
		if (obj_col.gameObject.name == objetivo_desaparicion) 
			Destroy (obj_paracaidas.gameObject, 2f);
		if (obj_col.gameObject.name == "barco_juego") 
			Destroy (obj_paracaidas.gameObject);
	}


}

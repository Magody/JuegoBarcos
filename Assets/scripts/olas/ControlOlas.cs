using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlOlas : MonoBehaviour {

	Rigidbody ola;
	Transform transform_nueva;
	float direccion_x, direccion_z;
	float vel = 10f;

	void Awake()
	{
		ola = GetComponent<Rigidbody> ();
		transform_nueva = transform;
	}

	void Start () 
	{
		transform_nueva.localScale = new Vector3 (2, 1.5f, 3);
		Destroy (ola.gameObject, InstanciadorOlas.timer_inicial*3f);

		if (transform_nueva.position.x < 0)
			direccion_x = 1f;
		else 
			direccion_x = -1f;
			
		if (transform_nueva.position.z < 0)
			direccion_z = 1f;
		else 
			direccion_z = -1f;

	}

	void Update () 
	{
		if (ola != null)
			transform.Translate (direccion_x*Time.deltaTime*2f, 0, direccion_z*Time.deltaTime*vel);
	}

	void OnCollisionEnter(Collision obj_col)
	{
		if (obj_col.gameObject.name == "barco_juego")
			Destroy (ola.gameObject);
		if (obj_col.gameObject.name == "plataforma")
			vel *= 10f;
	}


}

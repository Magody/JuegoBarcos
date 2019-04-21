using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTiburon : MonoBehaviour {

	//float distancia;
	Transform transform_nueva, target;

	public float vel = 3f;
	private float rotationSpeed = 6;

	void Start () 
	{
		transform_nueva = transform;
		target = GameObject.Find ("barco_juego").transform;

	}

	void Update () 
	{
		//Voltear
		transform_nueva.rotation = Quaternion.Slerp(transform_nueva.rotation, Quaternion.LookRotation(-target.position + transform_nueva.position), rotationSpeed*Time.deltaTime);

		//Caminar
		transform_nueva.position += transform_nueva.forward * -vel * Time.deltaTime;
		//Lineas de debug que aparecen en la ventana Scene
		//Debug.DrawLine (target.transform.position, transform.position, Color.red,  Time.deltaTime, false);

	}
		
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorParacaidas : MonoBehaviour {

	GameObject plataforma;
	public GameObject paracaidas;
	float timer_respawn ;
	public static float timer_inicial = 2f;
	public static int contador_paracaidas = 0;
	public float altura = 30f;



	void Start () {
		plataforma = GameObject.Find ("plataforma");
		timer_respawn = timer_inicial;

	}
	
	// Update is called once per frame
	void Update () 
	{
		timer_respawn -= Time.deltaTime;
		if (timer_respawn < 0)
		{
			float pos_ale_x = Random.Range(-plataforma.transform.localScale.x,plataforma.transform.localScale.x);
			float pos_ale_z = Random.Range(-plataforma.transform.localScale.z,plataforma.transform.localScale.z);

			Instantiate (paracaidas, new Vector3(pos_ale_x,altura,pos_ale_z), transform.rotation);
			timer_respawn = timer_inicial;
			contador_paracaidas++;
		}
			

	}
		

}

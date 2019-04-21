using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorOlas : MonoBehaviour {

	GameObject plataforma;
	public GameObject ola;
	float timer_respawn;
	public static float timer_inicial = 0.7f;


	void Start () {
		timer_respawn = timer_inicial;
		plataforma = GameObject.Find ("plataforma");
	}

	// Update is called once per frame
	void Update () 
	{
		timer_respawn -= Time.deltaTime;
		if (timer_respawn < 0)
		{
			float pos_ale_x = 4f*Random.Range(-plataforma.transform.localScale.x,plataforma.transform.localScale.x);
			float pos_ale_z = 4f*Random.Range(-plataforma.transform.localScale.z,plataforma.transform.localScale.z);

			Instantiate (ola, new Vector3(pos_ale_x,7f,pos_ale_z), transform.rotation);
			//print ("x : " + pos_ale_x + " , z: " + pos_ale_z);

			timer_respawn = timer_inicial;
		}
	}



}

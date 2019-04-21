using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorTiburon : MonoBehaviour {

	GameObject plataforma;
	public GameObject tiburon;
	public float timer_respawn = 5f;
	public int numero_tiburones = 2;

	void Start () {
		plataforma = GameObject.Find ("plataforma");

	}

	// Update is called once per frame
	void Update () 
	{
		timer_respawn -= Time.deltaTime;
		if (timer_respawn < 0 && numero_tiburones!=0)
		{
			float pos_ale_x = Random.Range(-plataforma.transform.localScale.x,plataforma.transform.localScale.x);
			float pos_ale_z = Random.Range(-plataforma.transform.localScale.z,plataforma.transform.localScale.z);

			Instantiate (tiburon, new Vector3(pos_ale_x,2f,pos_ale_z), transform.rotation);
			//print ("x : " + pos_ale_x + " , z: " + pos_ale_z);
			numero_tiburones--;
			timer_respawn = 5f;
		}


	}
}

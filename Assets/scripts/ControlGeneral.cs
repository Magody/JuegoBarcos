using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGeneral : MonoBehaviour {


	public float timer_paracaidas;




	void Awake () {
		
		timer_paracaidas = InstanciadorParacaidas.timer_inicial;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		timer_paracaidas -= Time.deltaTime;

		if(timer_paracaidas < 0f)
		{
			timer_paracaidas = InstanciadorParacaidas.timer_inicial;
		}


			

	}

	void OnGUI()
	{
		
		GUI.Label (new Rect (20, 20, 150, 20), "Tiempo respawn cajas: "+((int)timer_paracaidas).ToString());
		GUI.Label (new Rect (30, 40, 150, 20), "Cajas Generadas: "+(InstanciadorParacaidas.contador_paracaidas).ToString());
		GUI.Label (new Rect (20, 100, 150, 20), "Tiempo: "+((int)Time.time).ToString());
	}



}

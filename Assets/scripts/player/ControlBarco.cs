using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBarco : MonoBehaviour {

	Rigidbody barco;
	int cajas_recogidas = 0;
	public float vel = 20f,rot = 40f, max_distance = 10f, pos_y= 2f;
	public static byte vidas_barco = 3;
	bool flying = false;

	RaycastHit fin_rayo;
	public LineRenderer line;

	void Start () {
		barco = GetComponent<Rigidbody> ();
	}

	void Update () 
	{
		ataque ();
		mov ();	
	}

	void mov()
	{
		if (Input.GetKey (KeyCode.UpArrow))
			transform.Translate (Vector3.back * vel * Time.deltaTime);

		if (Input.GetKey (KeyCode.DownArrow))
			transform.Translate (Vector3.forward * vel * Time.deltaTime);
		
		if (Input.GetKey (KeyCode.LeftArrow))
			transform.Rotate(0,-rot * Time.deltaTime,0);

		if (Input.GetKey (KeyCode.RightArrow))
			transform.Rotate(0,rot * Time.deltaTime,0);

		if (Input.GetKeyUp (KeyCode.Space))
		{
			barco.AddForce (Vector3.up*vel*35f, ForceMode.Impulse );
			flying = true;
		}
			
		if (flying)
			barco.drag = 0;
		else
			barco.drag = 2;
		
	}

	void OnCollisionEnter(Collision obj_col)
	{
		if (obj_col.gameObject.name == "paracaidas_prefab(Clone)")
		{
			cajas_recogidas++;
		}
		else if(obj_col.gameObject.name == "plataforma")
		{
			flying = false;
		}
		else if(obj_col.gameObject.name == "tiburon_prefab(Clone)")
		{
			vidas_barco--;
		}
		else if(obj_col.gameObject.name == "olas_prefab(Clone)")
		{
			vidas_barco--;
		}

			
		
	}

	void OnGUI()
	{
		GUI.Label (new Rect (10, 60, 140, 20), "Cajas recogidas: " + cajas_recogidas.ToString ());
		GUI.Label (new Rect (150, 60, 150, 20), "Vidas: " + vidas_barco.ToString ());
	}

	void ataque()
	{
		if (Input.GetKeyDown (KeyCode.Alpha1)) 
		{
			
			if(Physics.Raycast( new Vector3(transform.position.x, pos_y , transform.position.z), -transform.forward , out fin_rayo, max_distance))
			{ 
				line.enabled = true;
				line.SetPosition (1, fin_rayo.point);
				if (fin_rayo.collider.gameObject.name == "tiburon_prefab(Clone)") 
				{ 
					fin_rayo.collider.transform.Translate (transform.forward);
					Destroy (fin_rayo.collider.gameObject);
					line.enabled = false;
				}
			}

		}

	}



}

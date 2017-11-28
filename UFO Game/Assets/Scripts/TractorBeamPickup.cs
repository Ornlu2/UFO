using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeamPickup : MonoBehaviour {

	Vector3 player;
	public float speed = 4;
	Rigidbody rb;
	float  pickeduprotationspeed = 84;
	Component halo;




	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
		halo = GetComponent ("Halo");


	}
	
	// Update is called once per frame

	void Update () {
		player = GameObject.FindGameObjectWithTag("TractorBeam").transform.position;
		//playerrotation = GameObject.FindGameObjectWithTag("TractorBeam").transform.rotation;

		if (gameObject.tag == "PickedUp") 
		{
			HaloEnablePickup ();
			gameObject.transform.position = Vector3.Lerp (gameObject.transform.position, player, speed * Time.deltaTime);	
			//rb.isKinematic = true;
			gameObject.layer = 2;
			gameObject.transform.Rotate (pickeduprotationspeed*Time.deltaTime,pickeduprotationspeed*Time.deltaTime,pickeduprotationspeed*Time.deltaTime);
		}
		  if (Input.GetKeyDown(KeyCode.Space) & gameObject.tag == "PickedUp" )
			
		{

			//Physics.Linecast (player,  0);
			//Debug.DrawLine (player.x, 0);

			Debug.Log("did thing");
			//rb.useGravity = true;
			//rb.isKinematic = false;

			gameObject.tag = "Untagged";

			//rb.AddForceAtPosition (player/25, , ForceMode.Impulse);
			HaloDisabled ();
			StartCoroutine (TimeLeftBeforePickable ());


		}


	}

	IEnumerator TimeLeftBeforePickable()
	{

		yield return new WaitForSecondsRealtime (3);
		gameObject.layer = 0;


	}


	void LateUpdate()
	{
		PickUpIndicator ();
	}

	void HaloDisabled()
	{
		halo.GetType ().GetProperty ("enabled").SetValue (halo, false, null);
	}
	void HaloEnablePickup()
	{
		halo.GetType ().GetProperty ("enabled").SetValue (halo, true, null);
	}


	void PickUpIndicator()
	{
		RaycastHit hit;
		if (Physics.Raycast (transform.position, Vector3.up, out hit)  & gameObject.tag == "Untagged") {
			HaloEnablePickup ();

		}
		else if (Physics.Raycast (transform.position, Vector3.up, out hit)  & gameObject.tag == "PickedUp")
		{
			HaloEnablePickup ();
		}
		else if (Physics.Raycast (transform.position, Vector3.up, out hit) & gameObject.tag == "PickedUp")
		{
			HaloDisabled ();
		}
		else if (Physics.Raycast (transform.position, Vector3.up, out hit)  & gameObject.tag == "Untagged")
		{
			HaloDisabled ();
		}
		else if ( gameObject.tag == "PickedUp")
		{
			HaloEnablePickup ();
		}
		else 
		{
			HaloDisabled ();
		}

	}

	

}

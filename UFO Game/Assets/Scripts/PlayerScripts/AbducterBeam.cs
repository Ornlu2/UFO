using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbducterBeam : MonoBehaviour {

	Transform player;
	float Height;
	Component halo;

	Vector3 AttractedObject;



	void Start()
	{
		Height = GameObject.Find ("PlayerTiltController").GetComponent<PlayerTilt> ().floatValue;
		player = GameObject.FindGameObjectWithTag("TractorBeam").transform;


	}
	void Update()
	{


		//Debug.DrawLine(Height, hit.point);


		if(Input.GetKeyUp(KeyCode.Space))
		{
			GrabObject ();
			MoveToObject ();
		}
	}

	void MoveToObject()
	{
		GameObject[] objectsHeld = GameObject.FindGameObjectsWithTag ("PickedUp");

		if(objectsHeld.Length >0) 
		{
			AttractedObject = GameObject.FindGameObjectWithTag ("PickedUp").transform.position;

			gameObject.transform.position = Vector3.Lerp (gameObject.transform.position, AttractedObject, Time.deltaTime*3);	
		}
		else
		{
			
		}
	}

	void GrabObject()
	{


		Vector3 sphereLocation = new Vector3 (transform.position.x, transform.position.y - Height+1, transform.position.z);

        var colliders = Physics.OverlapSphere (sphereLocation, 20);

		foreach (var gameObject in colliders ) {

			if (gameObject.tag == "Terrain")
			{
				gameObject.tag = ("Terrain");
			}
			else
			{
				gameObject.tag = ("PickedUp");


			}
		}
	}
		



	private void OnDrawGizmos() {
		Vector3 sphereLocation = new Vector3 (transform.position.x, transform.position.y , transform.position.z);

		Gizmos.color = Color.red;
			//Use the same vars you use to draw your Overlap Sphere to draw your Wire Sphere.
		Gizmos.DrawWireSphere (sphereLocation, 20);
	}


}


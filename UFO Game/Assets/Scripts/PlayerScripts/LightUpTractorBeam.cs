using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpTractorBeam : MonoBehaviour {

	Component halo;

	public bool PickedUp;

	// Use this for initialization
	void Start () {
		halo = GetComponent ("Halo");
	}
	
	// Update is called once per frame
	void Update () {


		GameObject[] objectsHeld = GameObject.FindGameObjectsWithTag ("PickedUp");



		if (objectsHeld.Length <=0)
		{
			HaloDisabled ();

		}
		else if (objectsHeld.Length >0)
		{
			HaloEnablePickup ();

		}

	}
	void HaloDisabled()
	{
		halo.GetType ().GetProperty ("enabled").SetValue (halo, false, null);
	}
	void HaloEnablePickup()
	{
		halo.GetType ().GetProperty ("enabled").SetValue (halo, true, null);
	}
}

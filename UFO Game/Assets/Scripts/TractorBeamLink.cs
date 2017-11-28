using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeamLink : MonoBehaviour {

	public Rigidbody anchor;
	public GameObject TractorBeamAttractor;
	public GameObject linkPrefab;

	public float distanceFromChainEnd = 0.6f;
	public int links = 7;

	void Start () {
		GenerateBeam();
	}

	void GenerateBeam ()
	{
		Rigidbody previousRB = anchor;
		for (int i = 0; i < links; i++)
		{
			GameObject link = Instantiate(linkPrefab, transform);
			HingeJoint joint = link.GetComponent<HingeJoint>();
			joint.connectedBody = previousRB;

			if (i < links - 1)
			{
				previousRB = link.GetComponent<Rigidbody>();

			} else
			{
				link.gameObject.name = "LastLink";

			}


		}
	}

}

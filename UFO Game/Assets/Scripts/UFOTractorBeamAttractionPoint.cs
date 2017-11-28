using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOTractorBeamAttractionPoint : MonoBehaviour {

	public float distanceFromChainEnd = 0.6f;

	void Start()
	{
		FixedJoint joint = gameObject.GetComponent<FixedJoint> ();
		joint.autoConfigureConnectedAnchor = false;

		StartCoroutine (TimeLeftBeforePickable ());




		joint.anchor = Vector2.zero;
		joint.connectedAnchor = new Vector2(0f, -distanceFromChainEnd);
	}
	IEnumerator TimeLeftBeforePickable()
	{
		FixedJoint joint = gameObject.GetComponent<FixedJoint> ();

		yield return new WaitForSecondsRealtime (0.5f);

		joint.connectedBody = GameObject.Find("LastLink").GetComponent<Rigidbody>();

	}

	public void ConnectRopeEnd (Rigidbody endRB)
	{
		FixedJoint joint = gameObject.GetComponent<FixedJoint> ();
		//HingeJoint joint = gameObject.AddComponent<HingeJoint>();

		joint.autoConfigureConnectedAnchor = false;
		joint.connectedBody = endRB;
		joint.anchor = Vector2.zero;
		joint.connectedAnchor = new Vector2(0f, -distanceFromChainEnd);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeamLineRenderer : MonoBehaviour {

	Vector3 lineStart;
	Vector3 lineEnd;


	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {

		lineStart = GameObject.Find ("TractorBeamAnchor").transform.position;

		lineEnd = GameObject.Find ("TractorBeamAttractor").transform.position;



		LinkPositions ();

	}


	void LinkPositions()
	{
		LineRenderer linerenderer = gameObject.GetComponent<LineRenderer> ();

		linerenderer.SetPosition (1, lineStart);
		linerenderer.SetPosition (0, lineEnd);


	}
}
		



	
	


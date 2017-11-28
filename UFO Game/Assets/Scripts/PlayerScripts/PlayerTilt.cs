using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTilt : MonoBehaviour {


	public float speed ;
	public float floatValue ;

	Rigidbody rb;
	Animator animator;
	ParticleSystem LeftEngine;
	ParticleSystem RightEngine;
	ParticleSystem TopEngine;





	public bool EnableMovement;


	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();


	}


	void Update() {
		if (EnableMovement == true) {
			tilt ();
		}



	
		//int layerMask =  6;
		var GameObjectFloat = gameObject.transform.position;
		RaycastHit hit;
		if (Physics.Raycast (GameObjectFloat, Vector3.down, out hit)) {
			gameObject.transform.Translate (0, (floatValue - hit.distance), 0);

		}
		Debug.DrawLine(GameObjectFloat, hit.point);


	}


	void VerticalMovement()
	{
	



	
		//Debug.Log (Input.mousePosition);
		if(Input.GetKey(KeyCode.DownArrow))
		{
			//Code for action on mouse moving down
			transform.Translate(0, -0.1f,0);	
			Debug.Log ("Mouse down");
		}
		else if (Input.GetKey(KeyCode.UpArrow))
		{
			//Code for action on mouse moving up
			transform.Translate(0, 0.1f, 0);
			Debug.Log ("Mouse up");
		}
	}



	void tilt()
	{
		
		//Directional Tilt
		float dampTimeLeft = Mathf.Lerp(animator.GetFloat("XMovement") , -1, 2f*Time.deltaTime);
		float dampTimeRight = Mathf.Lerp(animator.GetFloat("XMovement") , 1, 2f*Time.deltaTime);
		float dampTimeForward = Mathf.Lerp(animator.GetFloat("ZMovement") , 1, 2f*Time.deltaTime);
		float dampTimeBack = Mathf.Lerp(animator.GetFloat("ZMovement") , -1, 2f*Time.deltaTime);

		//Tilt Reset to Idle
		float dampTimeHorizontalIdle = Mathf.Lerp(animator.GetFloat("XMovement") , 0, 2f*Time.deltaTime);
		float dampTimeVerticalIdle = Mathf.Lerp(animator.GetFloat("ZMovement") , 0, 2f*Time.deltaTime);


		if (Input.GetKey(KeyCode.A)) 
		{
			animator.SetFloat ("XMovement", dampTimeLeft);
			//transform.Translate (-0.25f, 0, 0);

		}
		else 
		{
			animator.SetFloat ("XMovement", dampTimeHorizontalIdle);

		}
		 if (Input.GetKey(KeyCode.D))
		{
	
			animator.SetFloat ("XMovement",dampTimeRight);
			//transform.Translate (0,0.25f, 0, 0);


		}
		 if (Input.GetKey(KeyCode.W))
		{
			animator.SetFloat ("ZMovement",dampTimeForward);

			transform.Translate (0, 0, speed);


		}
		else
		{
			animator.SetFloat ("ZMovement", dampTimeVerticalIdle);
		}

		if (Input.GetKey(KeyCode.S))
		{
			animator.SetFloat ("ZMovement",dampTimeBack);
			transform.Translate (0, 0, -speed);

		
		}



	}
}

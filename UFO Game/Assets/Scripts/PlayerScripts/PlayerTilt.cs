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
    public Transform ParentTransform;
    public Transform rotationcenter;

    public float TurnAmount;

    void Start()
	{
		rb = GameObject.FindWithTag("Player").GetComponentInParent<Rigidbody> ();
		animator = GetComponent<Animator> ();

	}


	void Update() {
		if (EnableMovement == true) {
			tilt ();
            VerticalMovement();
		}



	

	}
    

	void VerticalMovement()
	{
	



	
		//Debug.Log (Input.mousePosition);
		if(Input.GetKey(KeyCode.DownArrow))
		{
			//Code for action on mouse moving down
			transform.Translate(0, -0.5f,0);	
			Debug.Log ("down");
		}
		else if (Input.GetKey(KeyCode.UpArrow))
		{
			//Code for action on mouse moving up
			transform.Translate(0, 0.5f, 0);
			Debug.Log ("up");
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
            ParentTransform.RotateAround(rotationcenter.transform.position, Vector3.up, -TurnAmount);


        }
        else 
		{
			animator.SetFloat ("XMovement", dampTimeHorizontalIdle);

		}
		 if (Input.GetKey(KeyCode.D))
		{
	
			animator.SetFloat ("XMovement",dampTimeRight);
            ParentTransform.RotateAround(rotationcenter.transform.position, Vector3.up, TurnAmount);

        }
        if (Input.GetKey(KeyCode.W))
		{
			animator.SetFloat ("ZMovement",dampTimeForward);

			transform.Translate (0, 0.4f, speed);
        }
        else
		{
			animator.SetFloat ("ZMovement", dampTimeVerticalIdle);
		}

		if (Input.GetKey(KeyCode.S))
		{
			animator.SetFloat ("ZMovement",dampTimeBack);
			transform.Translate (0, 0, -speed);
            rb.AddForce(0, 0.4f, 0);

		
		}



	}
}

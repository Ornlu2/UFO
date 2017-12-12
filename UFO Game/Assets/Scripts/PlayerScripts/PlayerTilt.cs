using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTilt : MonoBehaviour {


	public float Horizontalspeed  =75;
    public float VerticalSpeed = 10;
	Rigidbody rb;
	Animator animator;
	ParticleSystem LeftEngine;
	ParticleSystem RightEngine;
	ParticleSystem TopEngine;
    Vector3 MovementVectorStart;
	public bool EnableMovement;
    public Transform ParentTransform;
    public Rigidbody ParentRigidbody;
    public Transform rotationcenter;
    public static float DragAmount;


    public float TurnAmount;
    private Vector3 ObjectPlayerDragStart;

    public Quaternion UFOTransform { get; private set; }

    void Start()
	{
		rb = GameObject.FindWithTag("Player").GetComponentInParent<Rigidbody> ();
		animator = GetComponent<Animator> ();
	}


	void Update() {
		if (EnableMovement == true) {
			tilt ();
            VerticalMovement();
            VerticleDecline();
            
		}
        ObjectPlayerDragStart = ParentRigidbody.position;


        if(Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }


        Debug.Log(DragAmount);
    }
    void VerticalMovement()
	{
		if(Input.GetKey(KeyCode.LeftShift))
		{
            ParentRigidbody.MovePosition(ParentRigidbody.position - ParentRigidbody.transform.TransformDirection(Vector3.up) * VerticalSpeed * Time.deltaTime);
            Debug.Log ("down");
		}
		else if (Input.GetKey(KeyCode.Space))
		{
			ParentRigidbody.MovePosition(ParentRigidbody.position + ParentRigidbody.transform.TransformDirection(Vector3.up) * VerticalSpeed * Time.deltaTime);
           
			Debug.Log ("up");
		}
        else
        {
            ParentRigidbody.MovePosition(ParentRigidbody.position + ParentRigidbody.transform.TransformDirection(Vector3.down) * DragAmount * Time.deltaTime);

        }
    }
    void VerticleDecline()
    {
        Debug.Log("declining");
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

        MovementVectorStart = new Vector3(ParentRigidbody.transform.position.x, ParentRigidbody.transform.position.y, ParentRigidbody.transform.position.z);

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
            ParentRigidbody.MovePosition(MovementVectorStart +ParentRigidbody.transform.TransformDirection(Vector3.forward) *Horizontalspeed * Time.deltaTime);
        }
        else
		{
			animator.SetFloat ("ZMovement", dampTimeVerticalIdle);
		}

		if (Input.GetKey(KeyCode.S))
		{
			animator.SetFloat ("ZMovement",dampTimeBack);
            
            ParentRigidbody.MovePosition(MovementVectorStart - ParentRigidbody.transform.TransformDirection(Vector3.forward) * Horizontalspeed * Time.deltaTime);


        }

       else if(!Input.GetKeyDown(KeyCode.A)|| !Input.GetKeyDown(KeyCode.A)|| !Input.GetKeyDown(KeyCode.S)|| !Input.GetKeyDown(KeyCode.A)|| !Input.GetKeyDown(KeyCode.D))
        {
            ParentRigidbody.drag = 100f;
            Debug.Log("Setting Drag");
        }
        
    }
}

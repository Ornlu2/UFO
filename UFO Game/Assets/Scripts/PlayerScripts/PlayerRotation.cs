using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

	public float rotateVelocity;

	public Transform pivot;
	private Transform wheel;

	void Awake () {

		wheel = transform;
	}

	void Update () {
		if(Input.GetKey(KeyCode.D))
			{
				wheel.RotateAround (pivot.position, Vector3.up, rotateVelocity * Time.deltaTime);

			}	
		if(Input.GetKey(KeyCode.A))
			{
				wheel.RotateAround (pivot.position, Vector3.up, -rotateVelocity * Time.deltaTime);

			}
		}
}


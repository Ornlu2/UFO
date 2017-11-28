using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOThrustersParticleSpeed : MonoBehaviour {

	private ParticleSystem ps;
	public float MaxSpeed = 5.0F;
	private float RestingSpeed = 0f;

	void Start()
	{
		ps = GetComponent<ParticleSystem>();
	}

	void Update()
	{
		var main = ps.main;
		if (Input.GetKey(KeyCode.W)) 
		{
			main.startSpeed = Mathf.Lerp (MaxSpeed, RestingSpeed, 1 * Time.deltaTime);
		}
		else
		{
			main.startSpeed = Mathf.Lerp (RestingSpeed, MaxSpeed, 1 * Time.deltaTime);

		}
	}


}

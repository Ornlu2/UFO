using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TractorBeamPickUp : MonoBehaviour {

    Rigidbody playerRB;


    Rigidbody rb;
    float pickeduprotationspeed = 84;
    Component halo;
    private float playerHeight;
    private Component SJoint;
    public float SpringAmount = 10;
    public float DamperAmount = 10;
    public float MaxdistanceFromAnchor = 10;
    public float MindistanceFromAnchor = 0;
    private Transform Anchor;
    public UnityEvent Pickup;
    private Rigidbody PlayerParent;
    public float Weight;
    private Vector3 ObjectPlayerDragStart;


    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        playerRB = GameObject.FindGameObjectWithTag("TractorBeamAnchor").GetComponent<Rigidbody>();
        PlayerParent = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        Anchor = GameObject.Find("TractorBeamCollider").GetComponent<Transform>();
        halo = GetComponent("Halo");
    }
	
	// Update is called once per frame
	void Update () {

        if (gameObject.tag =="CanPickUp" )
        {
            HaloEnablePickup();
        }

        if (gameObject.tag == "CanPickUp" & Input.GetMouseButtonUp(0))
        {
            gameObject.tag = "PickedUp";
            HaloEnablePickup();
            gameObject.layer = 2;
            gameObject.transform.Rotate(pickeduprotationspeed * Time.deltaTime, pickeduprotationspeed * Time.deltaTime, pickeduprotationspeed * Time.deltaTime);
            SJoint= gameObject.AddComponent<SpringJoint>();
            SJoint.GetComponent<SpringJoint>().connectedBody = playerRB;
            SJoint.GetComponent<SpringJoint>().spring = SpringAmount;
            SJoint.GetComponent<SpringJoint>().autoConfigureConnectedAnchor = false;
            SJoint.GetComponent<SpringJoint>().connectedAnchor = Anchor.transform.localPosition ;
            SJoint.GetComponent<SpringJoint>().damper = DamperAmount;
            SJoint.GetComponent<SpringJoint>().maxDistance = MaxdistanceFromAnchor;
            SJoint.GetComponent<SpringJoint>().maxDistance = MindistanceFromAnchor;
            Pickup.Invoke();



            PlayerTilt.DragAmount = PlayerTilt.DragAmount+Weight;

            Debug.Log("Picked Up Object");

        }
       
       if (Input.GetMouseButtonUp(1) && gameObject.tag == "PickedUp")
        {

            Destroy(SJoint);
            HaloDisabled();
            Debug.Log("Dropped Object");
            PlayerTilt.DragAmount = PlayerTilt.DragAmount - Weight;
            gameObject.tag = "CantPickUp";
            StartCoroutine("CanPickUpAgainTime");

        }
        
    }


    void OnTriggerEnter(Collider col)
    {
        if (gameObject.tag == "Untagged")
        {
            Debug.Log("Triggered");
            gameObject.tag = "CanPickUp";
        }
    }
        void OnTriggerExit(Collider col)
    {
        if (gameObject.tag == "CanPickUp")
        {
            HaloDisabled();
            gameObject.tag = "Untagged";

        }
    }
    

    
    public void HaloDisabled()
    {
        halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
    }
    public void HaloEnablePickup()
    {
        halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
    }
    IEnumerator CanPickUpAgainTime()
    {
        Debug.Log("CantPickup");
        yield return new WaitForSecondsRealtime(3);
        HaloDisabled();

        gameObject.tag = "Untagged";
    }

}



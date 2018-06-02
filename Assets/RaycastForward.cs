using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastForward : MonoBehaviour
{
    public GameObject currentObject;
    public Transform glow;
    public float theDistance;

    private Vector3 forward;
	
	void Update ()
    {
        RaycastHit hit;
        //float theDistance;

        //Direction for raycast
        this.forward = this.transform.TransformDirection(Vector3.forward) * 10;

        //Debugging display and glow object instantiated when raycast is in contact with an object
        if(Physics.Raycast(this.transform.position, forward, out hit))
        {
            this.theDistance = hit.distance;
            //Debug.Log(theDistance + " units from " + hit.collider.gameObject.name);
            this.currentObject = hit.collider.gameObject;
            if(GameObject.Find("Glow(Clone)") == null)
            {
                StartGlowing();
            }
        }
        else
        {
            this.currentObject = null;
            Destroy(GameObject.Find("Glow(Clone)"));
        }
	}

    public void StartGlowing()
    {
        Instantiate(glow, currentObject.transform.position, Quaternion.identity);
    }
}

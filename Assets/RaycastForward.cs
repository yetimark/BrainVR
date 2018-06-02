using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastForward : MonoBehaviour
{
    public GameObject currentObject;
    public Transform glow;
    public Vector3 forward;
	
	void Update ()
    {
        RaycastHit hit;
        float theDistance;

        //creates a visual beam but only on the scene side, not game side
        this.forward = this.transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(this.transform.position, forward, Color.white);

        //Debugging display and glow object instantiated when raycast is in contact with an object
        if(Physics.Raycast(this.transform.position, forward, out hit))
        {
            theDistance = hit.distance;
            Debug.Log(theDistance + " units from " + hit.collider.gameObject.name);
            currentObject = hit.collider.gameObject;
            if(GameObject.Find("Glow(Clone)") == null)
            {
                StartGlowing();
            }
        }
        else
        {
            Destroy(GameObject.Find("Glow(Clone)"));
        }
	}

    public void StartGlowing()
    {
        Instantiate(glow, currentObject.transform.position, Quaternion.identity);
    }

    //also only shows up on scene side.. look at Line Renderer next
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(this.transform.position, forward);
    }
}

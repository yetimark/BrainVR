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

        //Direction for raycast
        this.forward = this.transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(this.transform.position, this.forward, Color.cyan);

        if (Physics.Raycast(this.transform.position, this.forward, out hit))
        {
            this.theDistance = hit.distance;
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
        Instantiate(this.glow, currentObject.transform.position, Quaternion.identity, this.currentObject.transform);//Instantiate(object, position, rotation, parent)
    }
}

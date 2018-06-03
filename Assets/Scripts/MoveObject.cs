using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public GameObject currentObject;
    public Transform objectTransform;
    public float theDistance;

    private float skipZ = 0.01f;
    private bool selected = false;
    private bool atLeastOneSelection = false;
    private float zoom;

	
	void Update ()
    {
        this.currentObject = this.GetComponent<RaycastForward>().currentObject;
        if(this.currentObject != null)
        {
            this.objectTransform = this.currentObject.transform;
        }
        else
        {
            this.objectTransform = null;
        }
        this.theDistance = this.GetComponent<RaycastForward>().theDistance;

        //Input
        this.zoom = Input.GetAxis("Mouse ScrollWheel");

        SelectObject();
        ObjectMove();
	}

    public void SelectObject()
    {
        if (Input.GetMouseButtonDown(0) && this.currentObject != null)      //select button and pointing at an object
        {
            this.selected = !this.selected;
            this.objectTransform.parent = null;     //Orphan maker
        }
    }

    public void ObjectMove()
    {

        if (this.selected)
        {
            this.atLeastOneSelection = true;
            this.objectTransform.parent = this.transform;

            if(this.zoom != 0 && this.theDistance > 0.5 && this.theDistance < 10)
            {
                this.objectTransform.transform.Translate(Vector3.forward * this.zoom);
            }
            else if(this.theDistance <= 0.5)
            {
                this.objectTransform.Translate(Vector3.forward * this.skipZ);
            }
            else if(this.theDistance >= 10)
            {
                this.objectTransform.Translate(Vector3.back * this.skipZ);
            }
        }
    }
}

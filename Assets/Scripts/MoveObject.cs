using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public GameObject currentObject;
    public Transform objectTransform;
    public float theDistance;

    private float skipZ = 0.01f;
    private float rotateSpeed = 100f;
    private bool selected = false;
    private float zoom;
	
	void Update ()
    {
        this.currentObject = this.GetComponent<RaycastForward>().currentObject;
        this.objectTransform = this.currentObject.transform;
        this.theDistance = this.GetComponent<RaycastForward>().theDistance;

        //Inputs
        this.zoom = Input.GetAxis("Mouse ScrollWheel");

        SelectObject();
        ObjectMove();
	}

    public void SelectObject()
    {
        if (Input.GetMouseButtonDown(0) && this.currentObject != null)
        {
            this.selected = !this.selected;
            Debug.Log(this.selected);
        }
    }

    public void ObjectMove()
    {
        Debug.Log(this.theDistance);
        Debug.Log(this.zoom);

        if (this.selected)
        {
            this.currentObject.transform.parent = this.transform;

            if(this.zoom != 0 && this.theDistance > 0.5 && this.theDistance < 10)
            {
                this.currentObject.transform.Translate(Vector3.forward * this.zoom);
            }
            else if(this.theDistance <= 0.5)
            {
                this.currentObject.transform.Translate(Vector3.forward * this.skipZ);
            }
            else if(this.theDistance >= 10)
            {
                this.currentObject.transform.Translate(Vector3.back * this.skipZ);
            }
        }
        else
        {
            this.currentObject.transform.parent = null;
        }

    }
}

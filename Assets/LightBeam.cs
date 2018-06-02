using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeam : MonoBehaviour
{
    public GameObject currentObject;//should be able to manipulate object position from this
    public Vector3 start;
    public Vector3 end;
    public float width;
    public float theDistance;

    private LineRenderer beam;
    private Vector3 forward;
    private float distance;


	void Awake ()
    {
        //color and width
        this.beam = this.GetComponent<LineRenderer>();
        this.beam.startWidth = width;
        this.beam.endWidth = width;
	}

    void Update()
    {
        this.currentObject = this.GetComponent<RaycastForward>().currentObject;
        this.theDistance = this.GetComponent<RaycastForward>().theDistance;

        this.start = Vector3.zero;
        this.beam.SetPosition(0, this.start);

        this.forward = this.transform.TransformDirection(Vector3.forward) * 10;
        //if something in is in the way, go to that position, otherwise be 10
        if (this.currentObject != null)
        {
            this.end = new Vector3(0, 0, theDistance);
            this.beam.SetPosition(1, this.end);
        }
        else
        {
            this.end = this.forward;
            this.beam.SetPosition(1, this.end);
        }
        Debug.Log(this.end);

    }
}

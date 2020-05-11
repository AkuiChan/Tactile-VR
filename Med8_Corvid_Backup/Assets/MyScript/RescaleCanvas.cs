using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescaleCanvas : MonoBehaviour
{
    public GameObject P1, P2, P3, P4;
    public GameObject ThisCanvas;

    private float xDistance, zDistance;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ReposiitonCanvas();
    }

    public void ReposiitonCanvas()
    {
        
        // Get the middle of the mesh and place the Canvas there. 
        Vector3 Center = 0.5f * (P1.transform.position + P3.transform.position);
        // Get the largest y and determine the height of the plane.
        float newLargetsY = (P1.transform.position.y + P2.transform.position.y + P3.transform.position.y + P4.transform.position.y) / 4;
        float largestY = Mathf.Max(P1.transform.position.y, P2.transform.position.y, P3.transform.position.y, P4.transform.position.y);
        // Actually place the Plane. 
        this.transform.position = new Vector3(Center.x, (newLargetsY), Center.z);

        // Determine the scale of the Canvas.
        float minZ = Mathf.Min(Vector3.Distance(P1.transform.position, P2.transform.position) + Vector3.Distance(P3.transform.position, P4.transform.position));
        float minX = Mathf.Min(Vector3.Distance(P2.transform.position, P3.transform.position) + Vector3.Distance(P1.transform.position, P4.transform.position));

        zDistance = minZ / 30f;
        xDistance = minX / 30f;

        // Transform the sacle of the canvas. 
        this.transform.localScale = new Vector3(xDistance, 1, zDistance);

        // Find rotation position to be looked at
        Vector3 p1p4Center = 0.5f * (P1.transform.position + P4.transform.position);
        p1p4Center = new Vector3(p1p4Center.x, newLargetsY, p1p4Center.z);  // Move y to largest y as to avoid unwanted rotation on x axis.

        // Canvas look at rotation position. Vector to determine that its up.
        this.transform.LookAt(p1p4Center, new Vector3(0, 1, 0));
        
    }
}

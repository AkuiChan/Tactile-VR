using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescaleCanvas : MonoBehaviour
{
    public GameObject p1, p2, p3, p4;

    Vector3 OGScale;

    private float xDistance, zDistance;

    // Start is called before the first frame update
    void Start()
    {
        OGScale = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 middleDistance = 0.5f * (p1.transform.position + p3.transform.position);
        float largestY = Mathf.Max(p1.transform.position.y, p2.transform.position.y, p3.transform.position.y, p4.transform.position.y);
        this.transform.position = new Vector3(middleDistance.x, (largestY + 0.0001f), middleDistance.z);

        float minZ = Mathf.Min(Vector3.Distance(p1.transform.position, p2.transform.position) + Vector3.Distance(p3.transform.position, p4.transform.position));
        float minX = Mathf.Min(Vector3.Distance(p2.transform.position, p3.transform.position) + Vector3.Distance(p1.transform.position, p4.transform.position));

        zDistance = minZ/30f;
        xDistance = minX/30f;

        this.transform.localScale = new Vector3(xDistance, 1, zDistance);

        Debug.Log("Angle between objects " + Vector3.Angle(p1.transform.position, p4.transform.position));
        
    }
}

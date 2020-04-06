using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeScale : MonoBehaviour
{
    [SerializeField]
    GameObject go;
    [SerializeField]
    float height;
    [SerializeField]
    float width;
    [SerializeField]
    float depth;
    Vector3 oldScale;
    Vector3 newScale;

    private void Start()
    {
        height = go.transform.localScale.y;
        width = go.transform.localScale.x;
        depth = go.transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        newScale = new Vector3(width, height, depth);
        if (oldScale == newScale)
        {
            //do nothing
        }
        else
        {
            go.transform.localScale = new Vector3(width, height, depth);
            oldScale = go.transform.localScale = new Vector3(width, height, depth);
        }
            
    }
}


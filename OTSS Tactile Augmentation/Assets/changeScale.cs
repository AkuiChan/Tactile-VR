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

    [SerializeField]
    GameObject p1;
    [SerializeField]
    GameObject p2;
    [SerializeField]
    GameObject p3;

    private void Start()
    {
        //height = go.transform.localScale.y;
        //width = go.transform.localScale.x;
        //depth = go.transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        //newScale = new Vector3(width, height, depth);
        //if (oldScale == newScale)
        //{
        //    //do nothing
        //}
        //else
        //{
        //    go.transform.localScale = new Vector3(width, height, depth);
        //    oldScale = go.transform.localScale = new Vector3(width, height, depth);
        //}
        Vector3 p1V = new Vector3(p1.transform.position.x, p1.transform.position.y, p1.transform.position.z);
        Vector3 p2V = new Vector3(p2.transform.position.x, p2.transform.position.y, p2.transform.position.z);
        Vector3 p3V = new Vector3(p3.transform.position.x, p3.transform.position.y, p3.transform.position.z);
        setLength(p1V, p2V, p3V, go);
    }

    void setLength(Vector3 pos1, Vector3 pos2, Vector3 pos3, GameObject GO)
    {
        //Vector3 centerPos = new Vector3(startPos.x + endPos.x, startPos.y + endPos.y) / 2;
        float calibrateX = Mathf.Abs(1 - 1.3982F);
        float calibrateY = Mathf.Abs(1 - 0.7275F);
        float calibrateZ = Mathf.Abs(1 - 0.6926F);
        float scaleX = Mathf.Abs(pos1.z - pos2.z);
        float scaleZ = Mathf.Abs(pos2.x - pos3.x);
        float scaleY = Mathf.Abs((pos1.y + pos2.y + pos3.y)/3);
        //GO.transform.position = centerPos;
        GO.transform.localScale = new Vector3(scaleX- calibrateX, scaleY+calibrateY, scaleZ+ calibrateZ);

        height = go.transform.localScale.y;
        depth = go.transform.localScale.z;
        width = go.transform.localScale.x;
    }
}


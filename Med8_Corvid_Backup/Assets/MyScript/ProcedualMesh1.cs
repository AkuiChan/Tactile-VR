using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class ProcedualMesh1 : MonoBehaviour
{
    //public LockPosition LP;

    Mesh mesh;
    public GameObject p1, p2, p3, p4;
    public RescaleCanvas1 _rescaleCanvas;
    
    Vector2[] uv = new Vector2[] 
    {
        new Vector2(0, 0),
        new Vector2(0, 1),
        new Vector2(1, 1),
        new Vector2(1, 0)
    };

    Vector3[] vertices;
    int[] triangles;
    

    private void Awake()
    {
        mesh = GetComponent<MeshFilter> ().mesh;
    }

    // Update is called once per frame
    void Update()
    {
            MakeMeshData();
            updateMesh();
        _rescaleCanvas.RepositonCanvas();
    }

    void MakeMeshData()
    {
        //Create an array of vertices
        vertices = new Vector3[]
        {
            p1.transform.position + new Vector3(0, 0.1f, 0),
            p2.transform.position + new Vector3(0, 0.1f, 0),
            p4.transform.position + new Vector3(0, 0.1f, 0),
            p3.transform.position + new Vector3(0, 0.1f, 0)
        };

        //create an array of integers
        triangles = new int[] 
        { 
            0, 1, 2, 
            2, 3, 0
        };
    }

    void updateMesh()
    {
        mesh.Clear(); // Clear previus mesh so we dont have infinet objects
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;

        mesh.RecalculateNormals(); // Makes it so Texture and light works.
        mesh.Optimize();
        mesh.RecalculateBounds();
    }

}

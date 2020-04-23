using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HardCodeProcedualCube : MonoBehaviour
{
    Mesh mesh;

    // Object for position tracking. 
    public GameObject p1, p2, p3, p4;

    // Procedual stuff
    Vector3[] vertices;
    List<int> triangles;
    int[][] faceTriangles = new int[][]
        {
            new int[] {0, 1, 2, 3},
            new int[] {5, 0, 3, 6},
            new int[] {4, 5, 6, 7},
            new int[] {1, 4, 7, 2},
            new int[] {5, 4, 1, 0},
            new int[] {3, 2, 7, 6}
        };

    Vector2[] uvs;

    // Start is called before the first frame update
    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    // Update is called once per frame
    void Update()
    {
        triangles = new List<int>();

        verticesManager();
        
        for (int i = 0; i < 6; i++)
        {
            triangleManager(i);
        }
        uvManager();
        updateMesh();
    }

    // Manages the vertex data.
    void verticesManager()
    {
        vertices = new Vector3[]
        {
            p4.transform.position, //1
            p2.transform.position, //2
            new Vector3(p2.transform.position.x,0, p2.transform.position.z), //3
            new Vector3(p4.transform.position.x,0, p4.transform.position.z), //4
            p1.transform.position, //5
            p3.transform.position, //6
            new Vector3(p3.transform.position.x,0, p3.transform.position.z), //7
            new Vector3(p1.transform.position.x,0, p1.transform.position.z)  //8
        };
    }

    void triangleManager(int dir)
    {
       triangles.Add(faceTriangles[dir][0]);
       triangles.Add(faceTriangles[dir][1]);
       triangles.Add(faceTriangles[dir][2]);
       triangles.Add(faceTriangles[dir][0]);
       triangles.Add(faceTriangles[dir][2]);
       triangles.Add(faceTriangles[dir][3]);
    }

    void uvManager()
    {
        // eventually going to hold the UV code for correct texture.
    }

    // Make the cube mesh. 
    void updateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles.ToArray();
        //mesh.uv = uvs;
        mesh.RecalculateNormals();
    }
}

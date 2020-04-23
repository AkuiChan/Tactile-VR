using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class SimplePlaneMesh : MonoBehaviour
{
    Mesh _mesh;
    private void GenerateMesh()
    {
        List<Vector3> verts = new List<Vector3>();
        List<Vector2> uvs = new List<Vector2>();
        List<int> tris = new List<int>();
        List<Color32> colors = new List<Color32>();

        verts.Add(new Vector3(0, 0, 0));
        verts.Add(new Vector3(0, 1, 0));
        verts.Add(new Vector3(1, 1, 0));
        verts.Add(new Vector3(1, 0, 0));

        tris.Add(0);
        tris.Add(1);
        tris.Add(2);
        tris.Add(2);
        tris.Add(3);
        tris.Add(0);

        uvs.Add(new Vector2(0, 0));
        uvs.Add(new Vector2(0, 1));
        uvs.Add(new Vector2(1, 1));
        uvs.Add(new Vector2(1, 0));

        _mesh.vertices = verts.ToArray();
        _mesh.uv = uvs.ToArray();
        _mesh.triangles = tris.ToArray();
        _mesh.RecalculateBounds();
        _mesh.Optimize();
    }
}

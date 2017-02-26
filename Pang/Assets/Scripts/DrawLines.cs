using UnityEngine;
using System.Collections;

// Put this script on a Camera
public class DrawLines : MonoBehaviour
{
    // Fill/drag these in from the editor

    // Choose the Unlit/Color shader in the Material Settings
    // You can change that color, to change the color of the connecting lines
    public Material lineMat;

    public Mesh targetMesh;

    public Transform[] points;
    Vector3[] vertices;
    int[] indices;

    void Start()
    {
        vertices = targetMesh.vertices;
        indices = targetMesh.triangles;
    }
    // Connect all of the `points` to the `mainPoint`
    void DrawConnectingLines()
    {
        // Loop through each point to connect to the mainPoint
        //for (int i = 0; i < points.Length - 1; i += 2)
        //{
        //    GL.Begin(GL.LINES);
        //    lineMat.SetPass(0);
        //    GL.Color(new Color(lineMat.color.r, lineMat.color.g, lineMat.color.b, lineMat.color.a));
        //    GL.Vertex(points[i].position);
        //    GL.Vertex(points[i + 1].position);
        //    GL.End();
        //}

        //for (int i = 0; i < indices.Length - 1; i++)
        //{
        //    GL.Begin(GL.QUADS);
        //    lineMat.SetPass(0);
        //    GL.Color(new Color(lineMat.color.r, lineMat.color.g, lineMat.color.b, lineMat.color.a));
        //    GL.Vertex(vertices[indices[i]]);
        //    GL.Vertex(vertices[indices[i + 1]]);
        //    GL.End();
        //}
    }

    // To show the lines in the game window whne it is running
    void OnPostRender()
    {
        if (Application.isPlaying)
            DrawConnectingLines();
    }

    // To show the lines in the editor
    void OnDrawGizmos()
    {
        if (Application.isPlaying)
            DrawConnectingLines();
    }
}
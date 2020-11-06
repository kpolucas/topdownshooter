using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    // Create mesh by code
    // https://www.youtube.com/watch?v=CSeUMTaNFYk

    Vector3 origin;
    public float fov;
    public float viewDistance;
    int rayCount;
    float angle;
    float startingAngle;

    private void Start()
    {
        //viewDistance = 6f; // length of the cone
        //fov = 50f; // Angle of the cone
        rayCount = 8; // how much triangles
        origin = Vector3.zero;
        startingAngle = 0f;
    }

    void Update()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        angle = startingAngle;
        float angleIncrease = fov / rayCount;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin; // el [0] lo seteo, el resto los calculo

        int vertexIndex = 1;
        int triangleIndex = 0;
        // Loopeo y armo 1 triangulo y 3 vertices por cada raycast
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex = origin + GetVectorFromAngle(angle) * viewDistance; 
            vertices[vertexIndex] = vertex;

            if(i>0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
            vertexIndex++;
            angle -= angleIncrease;
        }

        // aplico la mesh
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetAimDirection(Vector3 aimDirection)
    {
        startingAngle = GetAngleFromVectorFloat(aimDirection) + fov / 2f;
    }

    static float GetAngleFromVectorFloat(Vector3 dir) // metodo duplicado, armar utils? 
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    Vector3 GetVectorFromAngle(float angle)
    {
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
}

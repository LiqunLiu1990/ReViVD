using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameObject cubetohit = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubetohit.transform.position = new Vector3(10, 40, 50);
        cubetohit.AddComponent<MeshCollider>();

        GameObject cubetohit2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubetohit2.transform.position = new Vector3(20, 80, 100);

        GameObject triangle = new GameObject();
        Mesh mesh = new Mesh();
        mesh.vertices = new[] { new Vector3(0, 0, 0), new Vector3(10, 0, 0), new Vector3(0, 0, 10) };
        mesh.triangles = new[] { 0, 2, 1 };
        mesh.RecalculateBounds();
        MeshFilter filter = triangle.AddComponent<MeshFilter>();
        filter.sharedMesh = mesh;
        MeshRenderer renderer = triangle.AddComponent<MeshRenderer>();
        MeshCollider collider = triangle.AddComponent<MeshCollider>();
        collider.sharedMesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {



        Vector3 start = new Vector3(3, -1, 3);
        //Vector3 end = new Vector3(100 * Mathf.Cos(2 * Mathf.PI * Time.time / 50), 50, 100 * Mathf.Sin(2 * Mathf.PI * Time.time / 50));
        Vector3 end = new Vector3(100, 50, 100);
        


        if (Physics.Raycast(start, end-start, Mathf.Infinity)) //does the ray intersect at least one object
        {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(start, end-start, Mathf.Infinity);
            Debug.DrawRay(start, end-start, Color.yellow);

            for (int i = 0; i < hits.Length; i++)
            {
                //Debug.Log("hit");
                //Debug.Log(hits[i].collider.gameObject.name);
                //Debug.Log(hits[i].collider.transform.parent.gameObject.name);
            }
        }
        else
        {
            //Debug.DrawRay(start, end-start, Color.white);
            //Debug.Log("Did not Hit");

        }

     
    }
}

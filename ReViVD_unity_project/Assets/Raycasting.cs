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
        //cubetohit.AddComponent<MeshCollider>();


        GameObject cubetohit2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubetohit2.transform.position = new Vector3(20, 80, 100);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 start = new Vector3(0, 0, 0);
        Vector3 end = new Vector3(20,80,100);

        RaycastHit[] hits;

        if (Physics.Raycast(start, end, Mathf.Infinity)) //does the ray intersect at least one object
        {
            hits = Physics.RaycastAll(start, end, Mathf.Infinity);
            Debug.DrawRay(start, end, Color.yellow);

            for (int i = 0; i < hits.Length; i++)
            {
                Debug.Log("hit");
                Debug.Log(hits[i].point);
            }
        }
        else
        {
            Debug.DrawRay(start, end * 1000, Color.white);
            Debug.Log("Did not Hit");

        }

     
    }
}

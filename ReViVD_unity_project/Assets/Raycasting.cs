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

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 start = new Vector3(0, 0, 0);
        Vector3 end = new Vector3(10,40,50);

        RaycastHit hit;
        // Does the ray intersect any objects
        if (Physics.Raycast(start, end, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(start, end* hit.distance, Color.yellow);
            Debug.Log("hit");
            Debug.Log(hit.point);
        }
        else 
        {
            Debug.DrawRay(start, end * 1000, Color.white);
            Debug.Log("Did not Hit");
        }


    }
}

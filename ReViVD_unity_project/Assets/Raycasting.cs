using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 debut = new Vector3(0, 0, 0);
        Vector3 fin = new Vector3(5, 5, 5);

        //Ray rayon = new Ray(debut, fin);
        //Debug.DrawRay(debut, fin, Color.yellow);
          
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(debut, fin, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(debut, fin* hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(debut, fin * 1000, Color.white);
            Debug.Log("Did not Hit");
        }


    }
}

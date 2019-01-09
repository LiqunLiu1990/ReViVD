using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class Controllers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        GameObject controller_left = GameObject.CreatePrimitive(PrimitiveType.Cube);
        controller_left.transform.position = new Vector3(-1, 2, 0);

        GameObject controller_right = GameObject.CreatePrimitive(PrimitiveType.Cube);
        controller_right.transform.position = new Vector3(1, 2, 0);

        var interactionSourceStates = InteractionManager.GetCurrentReading();
        foreach (var interactionSourceState in interactionSourceStates) {
                }


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetJoystickNames()[0]);
        Debug.Log(Input.GetJoystickNames()[1]);

    }
}

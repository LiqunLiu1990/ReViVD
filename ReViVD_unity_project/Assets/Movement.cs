using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float horizontalSensitivity = 150;
    public float verticalSensitivity = 150;
    public float trimSensitivity = 0.3f;
    public float maxTrimVelocity = 150;
    public float baseSpeed = 20;
    public bool invertVerticalControl = false;
    public bool followPath = false;

    private Transform camTrans;
    private Vector2 oldTouchPos = Vector2.zero;
    private float trimToDo = 0;
    private TimePath pathToFollow;
    private float startTimeToFollow = 0;
    private TimeVisualization visu;

    // Use this for initialization
    void Start () {
        camTrans = transform.GetChild(0);
        visu = GameObject.Find("airTraffic").GetComponent<TimeVisualization>();
        pathToFollow = visu.PathsAsTime[visu.GetPathIndex("28")];
    }

    void PrintVect(Vector3 vect) {
        Debug.Log(vect.x.ToString() + ' ' + vect.y.ToString() + ' ' + vect.z.ToString());
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKey(KeyCode.Return))
        {
            followPath = true;
            startTimeToFollow = Time.time;
            
        }
        if (followPath){
            

            Vector3 camRot = Time.deltaTime * (horizontalSensitivity * Input.GetAxis("Right_Hori") * camTrans.up + verticalSensitivity * (invertVerticalControl ? -1 : 1) * Input.GetAxis("Right_Vert") * camTrans.right);
            Vector2 touchPos = new Vector2(Input.GetAxis("Right_Touch_Hori"), -Input.GetAxis("Right_Touch_Vert"));
            if (!oldTouchPos.Equals(Vector2.zero) && !touchPos.Equals(Vector2.zero))
            {
                trimToDo += trimSensitivity * Vector2.SignedAngle(oldTouchPos, touchPos);
            }
            oldTouchPos.Set(touchPos.x, touchPos.y);
            if (trimToDo != 0)
            {
                float step = Mathf.Max(Mathf.Min(trimToDo, maxTrimVelocity * Time.deltaTime), -maxTrimVelocity * Time.deltaTime);
                camRot += step * camTrans.forward;
                trimToDo -= step;
            }
            transform.Rotate(camRot, Space.World);

            float timeSinceFollow = (Time.time - startTimeToFollow)*60;



            Vector3 pos;
            int index = 0;

            while (pathToFollow.AtomsAsTime[index].time < timeSinceFollow)
            {
                index += 1;
            }

            TimeAtom pointa;
            TimeAtom pointb;

            pointa = pathToFollow.AtomsAsTime[index];

            if (index < pathToFollow.AtomsAsTime.Count-1)
            {
                pointb = pathToFollow.AtomsAsTime[index + 1];
            }
            else
            {
                pointb = pathToFollow.AtomsAsTime[index];
                followPath = false;
            }

            Debug.Log("pointa");
            Debug.Log(pointa.point);

            Debug.Log("pointb");
            Debug.Log(pointb.point);

            float deltaTimePoints = pointb.time - pointa.time;
            float deltaTime = (timeSinceFollow - pointa.time);
            pos = pointa.point + deltaTime / deltaTimePoints * (pointb.point - pointa.point);

            Debug.Log("pos");
            Debug.Log(pos);
            transform.position = pos;
          
        }
        else
        {
            Vector3 camStr = Time.deltaTime * baseSpeed * (Input.GetAxis("Left_Vert") * (-camTrans.forward) + Input.GetAxis("Left_Hori") * camTrans.right);
            Vector3 camRot = Time.deltaTime * (horizontalSensitivity * Input.GetAxis("Right_Hori") * camTrans.up + verticalSensitivity * (invertVerticalControl ? -1 : 1) * Input.GetAxis("Right_Vert") * camTrans.right);

            Vector2 touchPos = new Vector2(Input.GetAxis("Right_Touch_Hori"), -Input.GetAxis("Right_Touch_Vert"));
            if (!oldTouchPos.Equals(Vector2.zero) && !touchPos.Equals(Vector2.zero))
            {
                trimToDo += trimSensitivity * Vector2.SignedAngle(oldTouchPos, touchPos);
            }
            oldTouchPos.Set(touchPos.x, touchPos.y);
            if (trimToDo != 0)
            {
                float step = Mathf.Max(Mathf.Min(trimToDo, maxTrimVelocity * Time.deltaTime), -maxTrimVelocity * Time.deltaTime);
                camRot += step * camTrans.forward;
                trimToDo -= step;
            }

            transform.Rotate(camRot, Space.World);
            transform.Translate(camStr + Vector3.Cross(camTrans.position - transform.position, camRot * 0.0174533f), Space.World);

        }
       
	}

}

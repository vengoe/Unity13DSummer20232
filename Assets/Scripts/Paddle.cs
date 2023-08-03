using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    float smooth = 5.0f;
    float tiltAngle = 60.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Getting mouse input for paddle position
     
        Vector3 pos = new Vector3((Input.mousePosition.x - Screen.width/2)/(Screen.width/10), transform.position.y, 
            (Input.mousePosition.y - Screen.height / 2) / (Screen.height / 10));

        //Getting Input for paddle rotation 
        float tiltAroundZ = Input.GetAxis("Mouse X") * tiltAngle;
        float tiltAroundx = Input.GetAxis("Mouse Y") * tiltAngle * -1;

        Quaternion targetRotation = Quaternion.Euler(tiltAroundx,0,tiltAroundZ);

        //slerp gives smoother values for smoother gameplay
        transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation, Time.deltaTime * smooth); // Must feed the slerp function 2 quaternion and 1 value
        transform.position = pos;
    }
}

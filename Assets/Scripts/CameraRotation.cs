using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    
    public Transform CameraAxisTransform;
    public float Rotation_speed;
    public float minAngle;
    public float maxAngle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime * Rotation_speed * Input.GetAxis("Mouse X"), 0);
        var newAngle = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * Rotation_speed * Input.GetAxis("Mouse Y");
        if (newAngle > 180)
            newAngle -= 360;
        newAngle = Mathf.Clamp(newAngle, minAngle, maxAngle);

        CameraAxisTransform.localEulerAngles = new Vector3(newAngle, 0, 0);
    }
}

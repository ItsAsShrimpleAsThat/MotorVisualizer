using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotCamera : MonoBehaviour
{
    public Transform cam;
    public Transform pivot;
    public float sensitivity;
    public float zoom;
    public float zoomSensitivity;

    private Vector3 rotation;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            cam.parent = null;
            pivot.position = cam.position + cam.forward * zoom;
            cam.parent = pivot;

            rotation.x -= Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;
            rotation.y += Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;

            rotation.x = Mathf.Clamp(rotation.x, -85, 85);

            pivot.localRotation = Quaternion.Euler(rotation);
        }

        float zoomDelta = Input.mouseScrollDelta.y * zoomSensitivity * Time.deltaTime;
        zoom += zoomDelta; 
        cam.position = cam.position + cam.forward * -zoomDelta;
    }
}

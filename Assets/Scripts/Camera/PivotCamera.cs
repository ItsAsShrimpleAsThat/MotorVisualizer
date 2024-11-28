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
    public float panSensitivity;
    public bool zoomAffectsPanningSpeed;
    public float zoomPanningFactor;
    public bool rightIsMostRecentClick;
    public bool shiftWasClickedBeforeMiddleMouseButton;

    public Vector3 pivot_rotation;
    public Vector3 cam_rotation;
    
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) && !Input.GetMouseButtonDown(2)) { shiftWasClickedBeforeMiddleMouseButton = true; }
        if(Input.GetMouseButtonDown(2) && !Input.GetKey(KeyCode.LeftShift)) { shiftWasClickedBeforeMiddleMouseButton = false; }
        if (Input.GetMouseButtonDown(1)) { rightIsMostRecentClick = true; }
        if (Input.GetMouseButtonDown(2)) { rightIsMostRecentClick = false; }

        if (Input.GetMouseButton(2) && !rightIsMostRecentClick)
        {
            if (shiftWasClickedBeforeMiddleMouseButton)
            {
                pivot.position += (cam.up * Input.GetAxisRaw("Mouse Y") + cam.right * Input.GetAxisRaw("Mouse X")) * panSensitivity * (zoomAffectsPanningSpeed ? zoom * zoomPanningFactor : 1.0f);
            }
            else
            {
                cam.parent = null;
                pivot_rotation += cam_rotation;
                pivot.position = cam.position + cam.TransformDirection(Vector3.forward) * zoom;
                cam_rotation = Vector3.zero;
                cam.parent = pivot;
                cam.localRotation = Quaternion.identity;

                pivot_rotation.x -= Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;
                pivot_rotation.y += Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;

                pivot_rotation.x = Mathf.Clamp(pivot_rotation.x, -85, 85);

                pivot.localRotation = Quaternion.Euler(pivot_rotation);
            }
        }
        if(Input.GetMouseButton(1) && rightIsMostRecentClick)
        {
            cam_rotation.x -= Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;
            cam_rotation.y += Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;

            cam_rotation.x = Mathf.Clamp(cam_rotation.x, -85, 85);

            cam.rotation = Quaternion.Euler(cam_rotation + pivot_rotation);
        }

        float zoomDelta = Input.mouseScrollDelta.y * zoomSensitivity * Time.deltaTime;
        zoom -= zoomDelta;
        if (zoom < 0) zoom = 0;
        cam.localPosition = new Vector3(0, 0, -zoom);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(pivot.position, 0.5f);
    }
}

using System;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Camera camera;
    public float zoomMin = 10;
    public float zoomMax = 100;
    
    public float zoomForce = 2;
    public float smoothSpeed = 2f;
    
    private float actualZoom;
    private float targetZoom;

    void Start()
    {
        actualZoom = camera.fieldOfView;
        targetZoom = actualZoom;
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0)
        {
            targetZoom -= scroll * zoomForce;
            targetZoom = Mathf.Clamp(targetZoom, zoomMin, zoomMax);
            
            
        }
        actualZoom = Mathf.Lerp(actualZoom, targetZoom, Time.deltaTime  * smoothSpeed);
        camera.fieldOfView = actualZoom;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class Create : MonoBehaviour
{
    public GameObject cubePrefab;
    public Camera camera1;

    public Joystick joystick;

    private bool onJoystick;


    void OnFingerDown(EnhancedTouch.Finger finger){
        RectTransform joystickRect = joystick.transform as RectTransform;

        bool xIn = joystickRect.offsetMin.x <= finger.screenPosition.x && finger.screenPosition.x <= joystickRect.offsetMax.x;

        bool yIn = joystickRect.offsetMin.y <= finger.screenPosition.y && finger.screenPosition.y <= joystickRect.offsetMax.y;

        onJoystick = xIn && yIn;
        if (onJoystick){
            Debug.Log("test");
        }
    }

    public void OnEnable()
    {
	EnhancedTouch.TouchSimulation.Enable();
	EnhancedTouch.EnhancedTouchSupport.Enable();
    EnhancedTouch.Touch.onFingerDown += OnFingerDown;
    }

    public void OnDisable()
    {
        EnhancedTouch.Touch.onFingerDown -= OnFingerDown;
        EnhancedTouch.TouchSimulation.Disable();
    }   

    void Update()
    {
        RaycastHit hit;
        Ray ray = camera1.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!onJoystick){
                Vector3 position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);
                DestroyCubeAfterDelay(cube, 0.5f); // Destroy the cube after 1.5 seconds
                }
            }
        }
    }

    void DestroyCubeAfterDelay(GameObject cube, float delay)
    {
        if (cube != null)
        {
            Destroy(cube, delay);
        }
    }
}


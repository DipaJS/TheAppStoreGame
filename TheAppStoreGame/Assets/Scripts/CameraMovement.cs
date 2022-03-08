using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : ComputerUI
{
    public Vector3 baseCameraPosition;
    public Vector3 baseCamperaRotation;
    public Vector3 cameraPosition;
    public Vector3 cameraRotation;
    public GameObject laptop;
    public GameObject xButton;

    // Start is called before the first frame update
    void Start()
    {
        baseCameraPosition = new Vector3(-3, 5.5f, -4);
        baseCamperaRotation = new Vector3(13.991f, 0, 0);
        cameraPosition = new Vector3(-3, 4.24f, -2.06f);
        cameraRotation = new Vector3(3.751f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                //Open computer/zoom in
                if (hit.collider.gameObject == laptop && this.transform.position == baseCameraPosition)
                {
                    move(cameraPosition, cameraRotation);
                    ChangeMonitor(activeScreen, screenSaver);
                    Debug.Log("Clicked!");
                }

                //Close window/zoom out
                if (hit.collider.gameObject == xButton)
                {
                    move(baseCameraPosition, baseCamperaRotation);
                    ChangeMonitor(screenSaver, activeScreen);
                    Debug.Log("Exited!");
                }
            }
        }
        if (Input.GetButtonDown("Cancel"))
        {
            move(baseCameraPosition, baseCamperaRotation);
            ChangeMonitor(screenSaver, activeScreen);
            Debug.Log("Cancel!");
        }
    }

    public void move(Vector3 position, Vector3 rotation)
    {
        this.transform.position = position;
        this.transform.eulerAngles = rotation;
    }

    public void Cancel()
    {
        move(cameraPosition, cameraRotation);
        ChangeMonitor(activeScreen, screenSaver);
        Debug.Log("Clicked!");
    }



}

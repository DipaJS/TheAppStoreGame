using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovementNew : MonoBehaviour
{

    public Vector3 baseCameraPosition;
    public Vector3 baseCameraRotation;
    // Camera view zoomed in on the computer
    public Vector3 cameraPosition;
    public Vector3 cameraRotation;

    public GameObject screen;
    public GameObject ui;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Projects a ray for raycasting on a mouseclick
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                //Open computer/zoom in when clicking the screen
                if (hit.collider.gameObject == screen && this.transform.position == baseCameraPosition)
                {
                    Move(cameraPosition, cameraRotation);
                    //OpenUI(ui);
                    Debug.Log("Clicked!");
                }
            }
        }

        // If the "Cancel" button (esc) is pressed, return to default view
        if (Input.GetButtonDown("Cancel"))
        {
            Cancel();
            Debug.Log("Cancel!");
        }
    }

    public void Move(Vector3 position, Vector3 rotation)
    {
        this.transform.position = position;
        this.transform.eulerAngles = rotation;
    }
    public void OpenUI(GameObject ui)
    {
        ui.SetActive(true);
    }
    public void Cancel()
    {
        Move(baseCameraPosition, baseCameraRotation);
        //ChangeMonitor(screenSaver, activeScreen);
        Debug.Log("Exited!");
    }
}

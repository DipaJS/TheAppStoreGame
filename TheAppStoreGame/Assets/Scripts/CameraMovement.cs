using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A script for moving and changing the player's perspective
// Attached to 'Main Camera' in 'GameView'
public class CameraMovement : ComputerUI
{
    // Default camera view
    public Vector3 baseCameraPosition;
    public Vector3 baseCamperaRotation;
    // Camera view zoomed in on the computer
    public Vector3 cameraPosition;
    public Vector3 cameraRotation;

    public GameObject laptop; // Screen model
    //public GameObject xButton;
    public GameObject newspaper; // Newspaper model
    public GameObject newsPopup; // Newspaper textbox
    public GameObject mailtab; 

    // Start is called before the first frame update
    void Start()
    {
        // Saves camera positions
        baseCameraPosition = new Vector3(-3, 5.5f, -4);
        baseCamperaRotation = new Vector3(13.991f, 0, 0);
        cameraPosition = new Vector3(-3, 4.24f, -2.06f);
        cameraRotation = new Vector3(3.751f, 0, 0);
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
                if (hit.collider.gameObject == laptop && this.transform.position == baseCameraPosition)
                {
                    move(cameraPosition, cameraRotation);
                    ChangeMonitor(activeScreen, screenSaver);
                    Debug.Log("Clicked!");
                }

                // Open Newspaper if the model is clicked
                if (hit.collider.gameObject == newspaper)
                {
                    NewspaperPopup(true);
                    Debug.Log("News!");
                }

                if(hit.collider.gameObject == mailtab)
                {

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

    // Change the camera view to the given vectors
        // Vector3 position - the x,y,z position coordinates
        // Vector3 rotation - the x,y,z rotation coordinates   
    public void move(Vector3 position, Vector3 rotation)
    {
        this.transform.position = position;
        this.transform.eulerAngles = rotation;
    }

    // Sets the camera to the default view, and changes the screen to the screensaver
    public void Cancel()
    {
            move(baseCameraPosition, baseCamperaRotation);
            //ChangeMonitor(screenSaver, activeScreen);
            Debug.Log("Exited!");
    }

    // Opens or closes the popup for the newspaper
        // bool open - True to open the popup, false to close it
    // Attatched to the back button for the newspaper
    public void NewspaperPopup(bool open)
    {
        int intBool = 0;
        if (open) { intBool = 1; }
        newsPopup.GetComponent<CanvasGroup>().alpha = intBool;
        newsPopup.GetComponent<CanvasGroup>().blocksRaycasts = open;
        newsPopup.GetComponent<CanvasGroup>().interactable = open;
    }

}

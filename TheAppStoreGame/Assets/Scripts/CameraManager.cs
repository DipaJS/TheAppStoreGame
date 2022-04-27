using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A script for managing the main camera so that the player can change perspective when interacting with different objects.
    //Attached to 'MainCamera' in 'GameplayView'
public class CameraManager : MonoBehaviour
{
    //Camera positions are set in the inspector

    //base camera-position and rotation sets the default camera view 
    public Vector3 baseCameraPosition;
    public Vector3 baseCameraRotation;

    //cs camera-position and rotation sets the camera view for when the player has interacted with the computer, i.e. a zoomed in view of the computer interface
    public Vector3 csCameraPosition;
    public Vector3 csCameraRotation;

    public GameObject screen;
    public GameObject ui;
    public GameObject world;

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
                    MoveCamera(csCameraPosition, csCameraRotation);
                    ui.SetActive(true);
                    world.SetActive(false);
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

    //MoveCamera changes the camera position and therefore changes the view of the game
        //Vector 3 position - changes the position of the camera to the paremeters of this vector
        //Vector 3 rotation - changes the rotation of the camera to the parameters of this vector
    public void MoveCamera(Vector3 position, Vector3 rotation)
    {
        this.transform.position = position;
        this.transform.eulerAngles = rotation;
    }
    //Cancel closes the computer interface and returns the game to default view
    public void Cancel()
    {
        MoveCamera(baseCameraPosition, baseCameraRotation);
        ui.SetActive(false);
        world.SetActive(true);
        Debug.Log("Exited!");
    }
}

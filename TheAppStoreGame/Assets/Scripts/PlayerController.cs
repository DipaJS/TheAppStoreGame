using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//OBS! Excessive script - not needed at this moment, has the same functionality as CameraManeger,
    //possible to seperate CameraManeger in to two parts - camera oriented and player interaction oriented, then place the latter components in this script

//A script for letting the player interact with things in the gamespace.

public class PlayerController : MonoBehaviour
{
    public GameObject newspaper;
    public GameObject newsPopup;

    void Update()
    {
        // Check if the newspaper was clicked, show the popup if so
        if (Input.GetMouseButton(0))
        {
            if (ifClicked(newspaper))
            {
                NewspaperPopup(true);
            }
        }

        // Let the cancel button close the popup
        if (Input.GetButtonDown("Cancel") && newsPopup)
        {
            NewspaperPopup(false);
        }
    }

    //Uses raycast to check if a GameObject was succesfully clicked on
        //Gameobject o - the GameObject 
        //Returns a boolean
    public bool ifClicked(GameObject o){

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            return hit.collider.gameObject == o;
        }
        else return false;
    }

    // Opens or closes the popup for the newspaper
        // bool open - True to open the popup, false to close it
    // Attatched to the back button for the newspaper popup
    public void NewspaperPopup(bool open)
    {
        int intBool = 0;
        if (open) { intBool = 1; }
        newsPopup.GetComponent<CanvasGroup>().alpha = intBool;
        newsPopup.GetComponent<CanvasGroup>().blocksRaycasts = open;
        newsPopup.GetComponent<CanvasGroup>().interactable = open;
    }

    public void CloseObject(GameObject o){
        o.SetActive(false);
    }
}

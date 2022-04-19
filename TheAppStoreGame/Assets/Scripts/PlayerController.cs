using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//OBS! Excessive script - not needed at this moment, has the same functionality as CameraManeger,
    //possible to seperate CameraManeger in to two parts - camera oriented and player interaction oriented, then place the latter components in this script

//A script for letting the player interact with things in the gamespace.

public class PlayerController //: MonoBehaviour
{

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
}

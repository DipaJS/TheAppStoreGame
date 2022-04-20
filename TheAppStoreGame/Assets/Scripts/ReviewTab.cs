using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JsonHandler;
using TMPro;
using System.IO;

//A script for player interaction with the ReviewTab 
//Attached to 'Computer Screen' in 'GameView'

public class ReviewTab : MonoBehaviour
{
    //Gameobjects that are present on the Review Appliction Tab in 'GameView'
	public TextMeshProUGUI descriptionField;
	public TextMeshProUGUI titleField;
	public GameObject imageField;
    public GameObject standardView;
    public GameObject noApplicationsView;

    //A list with all the images for the current application and an int for keeping track of which image is on display
    public string[] images;

    public int imageIndex = 0;


    //public GameObject ACM; Keep me 

    //The app that is currently being reviewed
    private Apps currentApp;
   
    // Start is called before the first frame update
        //Loads the first application from apps-queue to the main screen

    //This doesnt work (therefore outcommented) not sure why but needs fixing!
    void Start()
    {
        currentApp = (Apps)GameManager.instance.apps.Dequeue();
        images = currentApp.Images;
        SetApp(currentApp);
    }

    // Saves the players choice to accept the application for publication and loads a new application to screen
    public void Evaluate(bool accepted)
    {
        ConsequenceManager.instance.AppChoice(currentApp, accepted); // Saves currentApp to GameManager
        //ConsequenceManager.instance.LoadConsequences();
        if (GameManager.instance.apps.Count == 0)
        {
           NoApplications();
        }
        else
        {
            currentApp = (Apps)GameManager.instance.apps.Dequeue(); // Sets the next App as currentApp
            SetApp(currentApp); // Updates the screen with the new currentApp
        } 
    }

    // Loads an app to the main screen
        // Apps app - the app to be uploaded
    public void SetApp(Apps app){
        titleField.text = app.Name;
        descriptionField.text = app.Description;
        imageField.GetComponent<Image>().sprite = Resources.Load<Sprite>(Path.Combine("wireframes", app.Images[0]));
    }

    // Loads the 'No Applications' content on the review tab
    public void NoApplications()
    {
        noApplicationsView.SetActive(true);
        standardView.SetActive(false);
    }

    public void BrowseImage(){
        imageIndex = ((imageIndex + 1) % images.Length);
        imageField.GetComponent<Image>().sprite = Resources.Load<Sprite>(currentApp.Images[imageIndex]);
    }

    //CheckMe is a onClick function that displays (or removes) a checkmark when the button is pressed depending if the checkmark was previosly displayed or not
        //GameObject checkedBox is the checkmark to be displayed (set in the inspector)
    public void CheckMe(GameObject checkedBox){
        checkedBox.SetActive(!checkedBox.activeSelf);
    }
}

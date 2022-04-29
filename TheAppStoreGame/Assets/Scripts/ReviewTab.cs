using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JsonHandler;
using TMPro;
using System.IO;

//A script for player interaction with the ReviewTab 
//Attached to 'ReviewTab Active' in 'GameView'

public class ReviewTab : MonoBehaviour
{
    //Gameobjects that are present on the Review Appliction Tab in 'GameView'
	public TextMeshProUGUI descriptionField;
	public TextMeshProUGUI titleField;
	public GameObject imageField;
    public GameObject logoImage;
    public GameObject standardView;
    public GameObject noApplicationsView;

    public GameObject doChecklistNote;

    public GameObject[] checkMarks;
    public GameObject[] boxes;

    //A list with all the images for the current application and an int for keeping track of which image is on display
    public string[] images;

    public int imageIndex = 0;


    //public GameObject ACM; Keep me 

    //The app that is currently being reviewed
    public Apps currentApp;
   
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
        if(checkMarksComplete()){
            ConsequenceManager.instance.AppChoice(currentApp, accepted); // Saves currentApp to GameManager
            ConsequenceManager.instance.LoadConsequences();
            imageIndex = 0;
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
        else {doChecklistNote.SetActive(true);}
    }

    // Loads an app to the main screen
        // Apps app - the app to be uploaded
    public void SetApp(Apps app){
        titleField.text = app.Name;
        descriptionField.text = app.Description;
        imageField.GetComponent<Image>().sprite = Resources.Load<Sprite>(Path.Combine("wireframes", app.Images[0]));
        logoImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(Path.Combine("wireframes", app.Logo));
    }

    // Loads the 'No Applications' content on the review tab
    public void NoApplications()
    {
        noApplicationsView.SetActive(true);
        standardView.SetActive(false);
    }

    public void BrowseImage(bool next){
        if(next){
            if (imageIndex == currentApp.Images.Length-1){imageIndex=0;}
            else{imageIndex++;}
        }
        else{
            if (imageIndex == 0){imageIndex=currentApp.Images.Length-1;}
            else{imageIndex--;}
        }
        imageField.GetComponent<Image>().sprite = Resources.Load<Sprite>(Path.Combine("wireframes", currentApp.Images[imageIndex]));
    }

    public void ClearCheckmarks(){
        foreach (GameObject checkmark in checkMarks){
            checkmark.SetActive(false);
        }
    }
    //CheckMe is a onClick function that displays (or removes) a checkmark when the button is pressed depending if the checkmark was previosly displayed or not
        //GameObject checkedBox is the checkmark to be displayed (set in the inspector)
    public void CheckMe(int index){
        int start = index - (index % 3);
        for (int i = start; i<start+3; i++){
            if (i != index){
                checkMarks[i].SetActive(false);
            }
        }
        checkMarks[index].SetActive(!checkMarks[index].activeSelf);
    }

    public bool checkMarksComplete(){
        int i = 0;
        foreach (GameObject checkmark in checkMarks){
            if (checkmark.activeSelf){i++;}
        }
        if (i == 7){return true;}
        else {return false;}
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro package
using JsonHandler;
using System.IO;

// A GameManager singleton
// Attached to GameManager
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    // Can be called with "GameManager.instance"
    // Creates a public GameManager with get option
    public static GameManager instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.Log("GameManager is NULL");
            }
            return _instance;
        }
    }

    // Lists of the Apps that have been accepted and rejected.
    public List<Apps> acceptedApps;
    public List<Apps> rejectedApps;

    // App queue and an array for conversion from Json
    public Queue apps;
    public Queue evaluatedApps;
    private Apps[] appsArray;

    // Components and objects for the news popup, set in the Inspector
    public GameObject titleField;
    public GameObject descriptionField;
    public Image imageField;
    public GameObject newsPopup;
    public GameObject newspaperModel;

    public GameObject textMail;
    public GameObject nameMail;

    // Initialize private instances
    private void Awake()
    {
        _instance = this;
        evaluatedApps = new Queue();

        //Loads the json-file and creates an array with applications.
        TextAsset jsonString = Resources.Load<TextAsset>(Path.Combine("json", "jsonString"));
        appsArray = Apps.FromJson(jsonString.text);
        Debug.Log("Loaded Json");

        apps = new Queue(appsArray);
    }

    // Adds an app to evaluatedApps Queue and sets the status to either accepted (true) or rejected (false)
    // Also activates the newspaper model
    //  App app         - the App to be added
    //  bool accepted   - true if the App is to be accepted, false if it is rejected
    public void AppChoice(Apps app, bool accepted)
    {
        app.Status = accepted;  
        evaluatedApps.Enqueue(app);
        newspaperModel.SetActive(true); 
    }

    /* Uses the most recently evaluated application and checks if there are any consequences that should be 
    displayed, if there are - this method calls for the corresponding Display-method (e.g. NewspaperDisplay) */
    // Method called in UIManager.Evaluate
    public void LoadConsequences(){

        Apps app;
        Consequence[] consequences; 
        Consequence newsPaperConsequence = null;
        Consequence emailConsequence = null;

        if (evaluatedApps.Count != 0){                                  
            app = (Apps)evaluatedApps.Dequeue(); //app is the most recently reviewed application

            //Checks if the application was accepted or rejected and loads the corresponding consqequences to variable         
            if (app.Status){consequences = app.Accepted.Consequences;}  
            else {consequences = app.Rejected.Consequences;}

            //Checks where each consequence should be displayed and saves them in the corresponding variable
                //Implemented as a switch method so it is easy to add more display locations in future development
            foreach (Consequence c in consequences){
                switch (c.DisplayLocation){
                case 1: newsPaperConsequence = c; break;
                case 2: emailConsequence = c; break;
                }
                Debug.Log("Test: " + newsPaperConsequence.TextToDisplay);
            }
            //Calls for the corresponding Display-method if there are any new consequences to display in that location
            if (newsPaperConsequence != null){NewspaperDisplay(newsPaperConsequence, app);}
            if (emailConsequence != null){EmailDisplay(emailConsequence, app);}
        }
    }
    // Loads the newspaper with consquence text and title+image for the corresponding application
    public void NewspaperDisplay(Consequence c, Apps app)
    {
        Debug.Log(app.Title);
        titleField.GetComponent<TextMeshProUGUI>().text = app.Title;
        descriptionField.GetComponent<TextMeshProUGUI>().text = c.TextToDisplay;
        imageField.sprite = Resources.Load<Sprite>(app.Images[0]);
    }

    public void EmailDisplay(Consequence c, Apps app){
        //Load the parameters of consequence c to a new Email in the Email-tab
        nameMail.GetComponent<TextMeshProUGUI>().text = c.Name;
        textMail.GetComponent<TextMeshProUGUI>().text = c.TextToDisplay;

    }
}

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
    private Apps[] appsArray;

    // Components and objects for the news popup, set in the Inspector
    public GameObject titleField;
    public GameObject descriptionField;
    public Image imageField;
    public GameObject newsPopup;
    public GameObject newspaperModel;

    // Initialize private instances
    private void Awake()
    {
        _instance = this;

        acceptedApps = new List<Apps>();
        rejectedApps = new List<Apps>();

        //Loads the json-file and creates an array with applications.
        StreamReader r = new StreamReader("jsonString.json");
        string jsonString = r.ReadToEnd();
        appsArray = Apps.FromJson(jsonString);

        apps = new Queue(appsArray);
    }

    // Adds an App to either acceptedApps or rejectedApps
    //  App app         - the App to be added
    //  bool accepted   - true if the App is to be accepted, false if it is rejected
    public void AppChoice(Apps app, bool accepted)
    {
        if (accepted)
        {
            Debug.Log("Accepted before: " + string.Join(",", acceptedApps));
            acceptedApps.Add(app);
            Debug.Log("Accepted after: " + string.Join(",", acceptedApps));
        }
        else
        {
            Debug.Log("Rejected before: " + string.Join(",", rejectedApps));
            rejectedApps.Add(app);
            Debug.Log("Rejected after: " + string.Join(",", rejectedApps));
        }
        //displayConsequences(app); 
    }

    // Checks if there is either an accepted or a rejected app logged
    // If there is it activates the newspaper model
    // and writes it on the newspaper popup
    public void newspaperDisplay()
    {
        Apps app;
        if (acceptedApps.Count != 0)
        {
            app = acceptedApps[0];
            titleField.GetComponent<TextMeshProUGUI>().text = app.Title;
            descriptionField.GetComponent<TextMeshProUGUI>().text = app.Accepted.Consequences[0].TextToDisplay;
            imageField.sprite = Resources.Load<Sprite>(app.Images[0]);
            newspaperModel.SetActive(true);
        }
        else if (rejectedApps.Count != 0)
        {
            app = rejectedApps[0];
            titleField.GetComponent<TextMeshProUGUI>().text = app.Title;
            descriptionField.GetComponent<TextMeshProUGUI>().text = app.Rejected.Consequences[0].TextToDisplay;
            imageField.sprite = Resources.Load<Sprite>(app.Images[0]);
            newspaperModel.SetActive(true);
        }
        else
        {
            //throw some error
        }
    }
}

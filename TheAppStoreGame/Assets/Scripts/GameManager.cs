using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// A GameManager singleton
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
    public List<App> acceptedApps;
    public List<App> rejectedApps;

    // The apps to be reviewed
    public Queue apps;

    // Components and objects for the news popup
    public GameObject titleField;
    public GameObject descriptionField;
    public Image imageField;
    public GameObject newsPopup; // Set in the Inspector

    // Initialize private instances
    private void Awake()
    {
        _instance = this;

        acceptedApps = new List<App>();
        rejectedApps = new List<App>();
        apps = new Queue();

        // Hard-coded apps for the MVP
        apps.Enqueue(new App("App 1", "Text för app 1", Resources.Load<Sprite>("ework"), "Konsekvens för app1"));
        apps.Enqueue(new App("App 2", "Text för app 2", Resources.Load<Sprite>("PAWsitive"), "Konsekvens för app2"));

        // Initiates the fields for the news popup
        /*titleField = GameObject.Find("News Title Text").GetComponent<Text>();
        descriptionField = GameObject.Find("News Text").GetComponent<Text>();
        imageField = GameObject.Find("News Image").GetComponent<Image>();*/
    }

    // Adds an App to either acceptedApps or rejectedApps
    //  App app         - the App to be added
    //  bool accepted   - true if the App is to be accepted, false if it is rejected
    public void AppChoice(App app, bool accepted)
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

    public void newspaperDisplay()
    {
        if (acceptedApps.Count != 0)
        {
            Debug.Log(titleField);
            /*titleField.GetComponent<TextMesh>().text = "Accepted!";
            descriptionField.GetComponent<TextMesh>().text = "Great!";*/
            //imageField.sprite = app.getImage();
        }
        else if (rejectedApps.Count != 0)
        {
            //rejected code
        }
        else
        {
            //throw some error
        }
    }

    /*private void displayConsequences(App app)
    {
        titleField.text = app.getTitle();
        descriptionField.text = app.getConsequence();
        imageField.sprite = app.getImage();
    }*/

    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}

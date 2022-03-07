using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    // Start is called before the first frame update
    /*void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}

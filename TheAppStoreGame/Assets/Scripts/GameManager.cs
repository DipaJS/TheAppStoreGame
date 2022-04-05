using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro package
using JsonHandler;
using System.IO;

// Attached to GameManager
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // App queue and an array for conversion from Json
    public Queue apps;
    public Queue evaluatedApps;
    private Apps[] appsArray;

    private void Awake()
    {
        // Creates a persistent instance
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);

        //Loads the json-file and creates an array with applications.
        TextAsset jsonString = Resources.Load<TextAsset>(Path.Combine("json", "jsonString"));
        appsArray = Apps.FromJson(jsonString.text);
        Debug.Log("Loaded Json");

        Initialize();
    }

    // Sets the initial values for a fresh game
    private void Initialize()
    {
        evaluatedApps = new Queue();
        apps = new Queue(appsArray);
    }
}

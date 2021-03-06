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

    public List<Apps> allEvaluatedApps;
    private Apps[] appsArray;

    // Player detail variables
    public bool playerDetailsFilled;
    private string playerName;
    private string playerGender;
    private int playerAge;
    private string playerCountry;

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
    public void Initialize()
    {
        evaluatedApps = new Queue();
        apps = new Queue(appsArray);
        allEvaluatedApps = new List<Apps>();
    }

    // Sets the player details variables
    public void PlayerDetails(string name, string gender, int age, string country)
    {
        playerName = name;
        playerGender = gender;
        playerAge = age;
        playerCountry = country;
        playerDetailsFilled = true;
    }
}

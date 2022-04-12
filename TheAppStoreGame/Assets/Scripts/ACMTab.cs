using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using AcmCodeJsonHandler;
using System.IO;
// A script for handling the ACM codes
// Attached to 'ACMStart' in 'GameView'

//check* - left some old code out-commented so we can doublecheck that the functionality is the same and no bugs before deleting

public class ACMTab : ComputerUI
{
    //Old variables no longer needed, can be removed after check*
    //private static ACMTab _instance;
    /*public GameObject code2;
    public GameObject code3;
    public GameObject code4;
    public GameObject code5;
    public GameObject code6;
    public GameObject code7;*/

    //variables manually set in Unity to the corresponding object in 'GameView' scene.
    public GameObject code1;
    public GameObject acmTab;
    public TextMeshProUGUI codeDescription;
    public TextMeshProUGUI title;

    //array with the codes 
    public AcmCode[] acmCodes;

    // Initialize private instances
    private void Awake(){

        //loads the json-file with codes to acmCodes
        //StreamReader r = new StreamReader("ACMCodes.json"); // Kept as I changed how we load json without input from anyone else, feel free to delete
        //string jsonString = r.ReadToEnd();
        TextAsset jsonString = Resources.Load<TextAsset>(Path.Combine("json", "ACMCodes"));
        acmCodes = AcmCode.FromJson(jsonString.text);
    }

    //Method for activating a page with title and description for the corresponding applications
    public void LoadCode(int i){
        codeDescription.text = acmCodes[i].Description;
        title.text = acmCodes[i].Title;
        acmTab.SetActive(false);
        code1.SetActive(true);
        //acmTabTitle.SetActive(false);
    }

    // Method for returning to the main ACM page
    public void backToACM() 
    {
        ChangeMonitor(acmTab, code1);
        //acmTabTitle.SetActive(false);
    }
}
   
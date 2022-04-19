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

    //variables manually set in Unity to the corresponding object in 'GameView' scene.
    //public GameObject code;

    //public GameObject acmTab;
    public TextMeshProUGUI codeDescription;
    public TextMeshProUGUI title;

    //array with the codes 
    public AcmCode[] acmCodes;

    // Initialize private instances
    private void Awake(){

        //loads the json-file with codes to acmCodes
        TextAsset jsonString = Resources.Load<TextAsset>(Path.Combine("json", "ACMCodes"));
        acmCodes = AcmCode.FromJson(jsonString.text);
    }

    //Method for activating a page with title and description for the corresponding applications
    public void LoadCode(int i){
        codeDescription.text = acmCodes[i].Description;
        title.text = acmCodes[i].Title;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using AcmCodeJsonHandler;
using System.IO;

// A script for managing the ACM-tab
// Attached to 'ACMTab Active' in 'GamePlayView'

public class ACMTab : ComputerUI
{
    //Variables manually set in Unity to the corresponding object in 'GameView' scene.
    public TextMeshProUGUI codeDescription;
    public TextMeshProUGUI title;

    //Array with the codes 
    public AcmCode[] acmCodes;

    // Initialize private instances
    private void Awake(){

        //Loads the codes from the jsonFile ACMCodes.json to acmCodes 
        TextAsset jsonString = Resources.Load<TextAsset>(Path.Combine("json", "ACMCodes"));
        acmCodes = AcmCode.FromJson(jsonString.text);
    }

    //Method for activating a page with title and description for the corresponding applications
        //attached to buttons in 'GamePlayView' called aboutACM, code1.1, code1.2... etc.
        //int i represents the code to be loaded, 1 is for code 1.1, 2 for 1.2 etc. 0 is for ACM overview
    public void LoadCode(int i){
        codeDescription.text = acmCodes[i].Description;
        title.text = acmCodes[i].Title;
    }
}
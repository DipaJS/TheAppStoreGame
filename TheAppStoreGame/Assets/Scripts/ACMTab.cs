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
        StreamReader r = new StreamReader("ACMCodes.json");
        string jsonString = r.ReadToEnd();
        acmCodes = AcmCode.FromJson(jsonString);
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
    //OBS! Old functions below, can be removed after check* 

    //Method for activating the corresponding page for each code
    /*public void code(GameObject code)
    {
        ChangeMonitor(codePage, acmTab);
        code.SetActive(true);
        acmTabTitle.SetActive(false);
    }
}
    /*public void backToACM()
    {
        ChangeMonitor(acmTab, code1);
    }

    public void backToACM2()
    {
        ChangeMonitor(acmTab, code2);
    }

    public void backToACM3()
    {
        ChangeMonitor(acmTab, code3);
    }

    public void backToACM4()
    {
        ChangeMonitor(acmTab, code4);
    }

    public void backToACM5()
    {
        ChangeMonitor(acmTab, code5);
    }

    public void backToACM6()
    {
        ChangeMonitor(acmTab, code6);
    }

    public void backToACM7()
    {
        ChangeMonitor(acmTab, code7);
    }

    // Methods for activating the corresponding page for each code
    public void Code1()
    {
        //ComputerUI.instance.ChangeMonitor(code1, acmTab);
        ChangeMonitor(code1, acmTab);
    }

    public void Code2()
    {

        ChangeMonitor(code2, acmTab);
    }

    public void Code3()
    {

        ChangeMonitor(code3, acmTab);
    }

    public void Code4()
    {

        ChangeMonitor(code4, acmTab);
    }

    public void Code5()
    {

        ChangeMonitor(code5, acmTab);
    }

    public void Code6()
    {

        ChangeMonitor(code6, acmTab);
    }

    public void Code7()
    {

        ChangeMonitor(code7, acmTab);
    }
}
*/
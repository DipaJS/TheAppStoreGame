using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A script for handling the ACM codes
// Attached to 'ACMStart' in 'GameView'

public class ACMTab : ComputerUI
{

    //private static ACMTab _instance;
    public GameObject acmTab;
    public GameObject code1;
    public GameObject code2;
    public GameObject code3;
    public GameObject code4;
    public GameObject code5;
    public GameObject code6;
    public GameObject code7;




    // Methods for activating the corresponding page for each code
    public void Code1()
    {
        //ComputerUI.instance.ChangeMonitor(code1, acmTab);
        ChangeMonitor(code1, acmTab);
    }

    // Method for returning to the main ACM page (temporary)
    public void backToACM()
    {

        ChangeMonitor(acmTab, code1);

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

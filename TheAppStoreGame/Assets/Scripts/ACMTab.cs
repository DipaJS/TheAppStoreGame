using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACMTab : MonoBehaviour
{
    public GameObject code1;
    public GameObject acmTab;

    public void Code1()
    {
        ComputerUI.instance.ChangeMonitor(code1, acmTab);
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Do we need this? seems excessive 

public class ComputerUI : MonoBehaviour
{
    public GameObject activeScreen;
    public GameObject screenSaver;
    private static ComputerUI _instance;

    public static ComputerUI instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("GameManager is NULL");
            }
            return _instance;
        }
    }
    public void ChangeMonitor(GameObject activate, GameObject inactivate)
    {
        activate.SetActive(true);
        inactivate.SetActive(false);
    }

    public void SetActiveTab(GameObject activate){
        activate.SetActive(true);
    }

    public void SetInactiveTab(GameObject inactivate){
        inactivate.SetActive(false);
    }
}

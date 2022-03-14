using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerUI : MonoBehaviour
{
    public GameObject activeScreen;
    public GameObject screenSaver;

    public void ChangeMonitor(GameObject activate, GameObject inactivate)
    {
        activate.SetActive(true);
        inactivate.SetActive(false);
    }
}

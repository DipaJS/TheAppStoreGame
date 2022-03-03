using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerUI : MonoBehaviour
{
    public GameObject activeScreen;
    public GameObject screenSaver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMonitor(GameObject activate, GameObject inactivate)
    {
        activate.SetActive(true);
        inactivate.SetActive(false);
    }
}

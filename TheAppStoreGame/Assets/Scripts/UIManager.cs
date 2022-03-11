using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JsonHandler;

public class UIManager : MonoBehaviour
{
	public GameObject acceptButton;
	public GameObject rejectButton;
	private Text descriptionField;
	private Text titleField;
	public GameObject imageField;
    private Apps currentApp;
   
    // Start is called before the first frame update
    void Start()
    {
        titleField = GameObject.Find("Title").GetComponent<Text>();
        descriptionField = GameObject.Find("Description").GetComponent<Text>();

        currentApp = (Apps)GameManager.instance.apps.Dequeue();

        setApp(currentApp);
    }

    public void Accept()
    {
        Debug.Log("Accepted!");

        GameManager.instance.AppChoice(currentApp, true); // Saves currentApp to GameManager
        if (GameManager.instance.apps.Count == 0)
        {
           SceneManager.LoadScene("EndScreen");
        }
        else
        {
            currentApp = (Apps)GameManager.instance.apps.Dequeue(); // Sets the next App as currentApp
            GameManager.instance.newspaperDisplay();
            setApp(currentApp); // Updates the screen with the new currentApp
        } 
    }

    public void Reject()
    {
        Debug.Log("Rejected!");

        GameManager.instance.AppChoice(currentApp, false);
        if (GameManager.instance.apps.Count == 0)
        {
            SceneManager.LoadScene("EndScreen");
        }
        else
        {
            currentApp = (Apps)GameManager.instance.apps.Dequeue();
            GameManager.instance.newspaperDisplay();
            setApp(currentApp); // Updates the screen with the new currentApp
        }

    }
    
    









// Update is called once per frame


/*
void Update()
{
    if (Input.GetMouseButtonDown(0))
    {
        // If app accepted
        if (controller.ifClicked(acceptButton))
        {
            Debug.Log("Accepted!");
            GameManager.instance.AppChoice(currentApp, true); // Saves currentApp to GameManager
            currentApp = ((App)GameManager.instance.apps.Dequeue()); // Sets the next App as currentApp
            setApp(currentApp); // Updates the screen with the new currentApp
        }

        // If app rejected
        if (controller.ifClicked(rejectButton))
        {
            Debug.Log("Rejected!");
            GameManager.instance.AppChoice(currentApp, false);
            currentApp = ((App)GameManager.instance.apps.Dequeue());
            setApp(currentApp);
        }

    }
}
*/


    // Loads an app to the main screen
        // Apps app - the app to be uploaded
    public void setApp(Apps app){
        titleField.text = app.Title;
        descriptionField.text = app.Description;
        imageField.GetComponent<Image>().sprite = Resources.Load<Sprite>(app.Images[0]);
    }
}

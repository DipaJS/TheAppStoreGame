using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JsonHandler;
using TMPro;

//A script for player interaction with the computer screen. 
//Attached to 'Computer Screen' in 'GameView'

public class UIManager : MonoBehaviour
{
    //Gameobjects that are present on the screen in 'GameView'
	public GameObject acceptButton;
	public GameObject rejectButton;
	public TextMeshProUGUI descriptionField;
	public Text titleField;
	public GameObject imageField;
    public GameObject standardView;
    public GameObject noApplicationsView;
    //public GameObject ACM; Keep me 


    //The app that is currently being reviewed
    private Apps currentApp;
   
    // Start is called before the first frame update
        //Loads the first application from apps-queue to the main screen
    void Start()
    {
        currentApp = (Apps)GameManager.instance.apps.Dequeue();
        setApp(currentApp);
    }

    //Saves the players choice to accept the application for publication and loads a new application to screen

    public void Evaluate(bool accepted)
    {
        currentApp.Status = accepted;
        GameManager.instance.AppChoice(currentApp, accepted); // Saves currentApp to GameManager
        GameManager.instance.LoadConsequences();
        if (GameManager.instance.apps.Count == 0)
        {
           NoApplications();
        }
        else
        {
            currentApp = (Apps)GameManager.instance.apps.Dequeue(); // Sets the next App as currentApp
            //GameManager.instance.newspaperDisplay();
            setApp(currentApp); // Updates the screen with the new currentApp
        } 
    }

    // Loads an app to the main screen
        // Apps app - the app to be uploaded
    public void setApp(Apps app){
        titleField.text = app.Title;
        descriptionField.text = app.Description;
        imageField.GetComponent<Image>().sprite = Resources.Load<Sprite>(app.Images[0]);
    }

    public void NoApplications()
    {
        noApplicationsView.SetActive(true);
        standardView.SetActive(false);
    }
    //Loads the scene with the current code.
    //OnClick() in the code buttons in the ACM window
    /* Not used at the moment
    public void LoadCode(int nr)
    {
        SceneManager.LoadScene("Code " + nr);

    }
    */








}

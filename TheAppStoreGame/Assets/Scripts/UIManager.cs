using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JsonHandler;
using Newtonsoft;
using System.IO;

public class UIManager : MonoBehaviour
{
	public GameObject acceptButton;
	public GameObject rejectButton;
	private Text descriptionField;
	private Text titleField;
	public GameObject imageField; 
    private Sprite image;
    public App app1;
    public App app2;
    private App currentApp;
    private PlayerController controller;
    private Apps[] testApps;
    private Apps testApp;
    public Queue appsQueue; 
    private Apps newCurrentApp;
   
    // Start is called before the first frame update

    /* OBS! Current methods currently using the old class for applications,
    new methods will be implemented or are already implemented but out-commented
    in order for the game to work with full functionality. */

    void Start()
    {
        controller = new PlayerController();
        
        //Loads the json-file and creates an array with applications.
        StreamReader r = new StreamReader("jsonString.json");
        string jsonString = r.ReadToEnd();
        testApps = Apps.FromJson(jsonString);

        appsQueue = new Queue(testApps);

        titleField = GameObject.Find("Title").GetComponent<Text>();
        descriptionField = GameObject.Find("Description").GetComponent<Text>();


        //GameManager.instance.Awake(); 
        currentApp = ((App)GameManager.instance.apps.Dequeue());
        newCurrentApp = (Apps)appsQueue.Dequeue(); 
        //newCurrentApp will replace currentApp when all methods work with the new Apps-class

        setApp(currentApp);
        //setApp2(newCurrentApp); //will replace setApp
    }

    public void Accept()
    {
        Debug.Log("Accepted!");

        /*newCurrentApp = (Apps)appsQueue.Dequeue(); 
        setApp2(newCurrentApp);*/ 

        GameManager.instance.AppChoice(currentApp, true); // Saves currentApp to GameManager
        if (GameManager.instance.apps.Count == 0)
        {
           SceneManager.LoadScene("EndScreen");
        }
        else
        {
            currentApp = ((App)GameManager.instance.apps.Dequeue()); // Sets the next App as currentApp
            GameManager.instance.newspaperDisplay();
            setApp(currentApp); // Updates the screen with the new currentApp
        } 
    }

    public void Reject()
    {
        Debug.Log("Rejected!");
        
        /* newCurrentApp = (Apps)appsQueue.Dequeue();
        setApp2(newCurrentApp); */

        GameManager.instance.AppChoice(currentApp, false);
        if (GameManager.instance.apps.Count == 0)
        {
            SceneManager.LoadScene("EndScreen");
        }
        else
        {
            currentApp = ((App)GameManager.instance.apps.Dequeue());
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

    public void setApp(App app){
        titleField.text = app.getTitle();
        descriptionField.text = app.getDescripton();
        imageField.GetComponent<Image>().sprite = app.getImage();
    }

    //will replace setApp
    public void setApp2(Apps app){
        titleField.text = app.Title;
        descriptionField.text = app.Description;
        imageField.GetComponent<Image>().sprite = Resources.Load<Sprite>(app.Images[0]);
    }



}

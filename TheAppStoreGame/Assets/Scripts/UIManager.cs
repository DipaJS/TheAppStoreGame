using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
   
    // Start is called before the first frame update
    void Start()
    {
        controller = new PlayerController();

        titleField = GameObject.Find("Title").GetComponent<Text>();
        descriptionField = GameObject.Find("Description").GetComponent<Text>();

        currentApp = ((App)GameManager.instance.apps.Dequeue());
        setApp(currentApp);
    }

    // Update is called once per frame
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

    public void setApp(App app){
        titleField.text = app.getTitle();
        descriptionField.text = app.getDescripton();
        imageField.GetComponent<Image>().sprite = app.getImage();
    }
}

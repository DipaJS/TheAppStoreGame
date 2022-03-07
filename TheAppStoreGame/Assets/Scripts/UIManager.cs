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
    private Queue apps;
    public App app1;
    public App app2;
    public List<App> acceptedApps;
    public List<App> rejectedApps;
    private App currentApp;
    private PlayerController controller;
   
    // Start is called before the first frame update
    void Start()
    {
        controller = new PlayerController();
        apps = new Queue();
        acceptedApps = new List<App>();
        rejectedApps = new List<App>();
        app1 = new App("App 1", "Text för app 1", Resources.Load<Sprite>("ework"), "Konsekvens för app1");
        app2 = new App("App 2", "Text för app 2", Resources.Load<Sprite>("PAWsitive"), "Konsekvens för app2");
        apps.Enqueue(app1);
        apps.Enqueue(app2);

        titleField = GameObject.Find("Title").GetComponent<Text>();
        descriptionField = GameObject.Find("Description").GetComponent<Text>();

        currentApp = ((App)apps.Dequeue());
        setApp(currentApp);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Open computer/zoom in
            if (controller.ifClicked(acceptButton))
            {
                Debug.Log("Accepted!");
                acceptedApps.Add(currentApp);
                currentApp = ((App)apps.Dequeue());
                setApp(currentApp);
            }

            //Close window/zoom out
            if (controller.ifClicked(rejectButton))
            {
                Debug.Log("Rejected!");
                rejectedApps.Add(currentApp);
                currentApp = ((App)apps.Dequeue());
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

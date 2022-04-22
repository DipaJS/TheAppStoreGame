using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JsonHandler;
using UnityEngine.UI;
using TMPro; // TextMeshPro package
using System.IO;

//A script for managing the consequences the player will experience in the game depending on their choices

public class ConsequenceManager : MonoBehaviour
{
    public static ConsequenceManager instance;

    // Components and objects for the news popup, set in the Inspector
    public GameObject titleField;
    public GameObject descriptionField1;
    public GameObject descriptionField2;
    public Image imageField;
    public GameObject newsPopup;
    public GameObject newspaperModel;

    // Components and objects for the email
    public GameObject emailNotification;
    public GameObject textMail;
    public GameObject nameMail;
    public GameObject emailPrefab;
    public List<EmailConsequence> emailList;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        emailList = new List<EmailConsequence>();
    }

    // Adds an app to evaluatedApps Queue and sets the status to either accepted (true) or rejected (false)
    // Also activates the newspaper model
    //  App app         - the App to be added
    //  bool accepted   - true if the App is to be accepted, false if it is rejected
    public void AppChoice(Apps app, bool accepted)
    {
        app.Status = accepted;
        GameManager.instance.evaluatedApps.Enqueue(app);
        GameManager.instance.allEvaluatedApps.Add(app);
    }

    /* Uses the most recently evaluated application and checks if there are any consequences that should be 
    displayed, if there are - this method calls for the corresponding Display-method (e.g. NewspaperDisplay) */
    // Method called in UIManager.Evaluate
    public void LoadConsequences()
    {
        Apps app;
        Consequence[] consequences;
        Consequence newsPaperConsequence = null;
        Consequence emailConsequence = null;

        if (GameManager.instance.evaluatedApps.Count != 0)
        {
            app = (Apps)GameManager.instance.evaluatedApps.Dequeue(); //app is the most recently reviewed application

            //Checks if the application was accepted or rejected and loads the corresponding consqequences to variable         
            if (app.Status) { consequences = app.Accepted.Consequences; }
            else { consequences = app.Rejected.Consequences; }

            //Checks where each consequence should be displayed and saves them in the corresponding variable
            //Implemented as a switch method so it is easy to add more display locations in future development
            foreach (Consequence c in consequences)
            {
                switch (c.DisplayLocation)
                {
                    case 1: newsPaperConsequence = c; break;
                    case 2: emailConsequence = c; break;
                }
                Debug.Log("Test: " + newsPaperConsequence.TextToDisplay);
            }
            //Calls for the corresponding Display-method if there are any new consequences to display in that location
            if (newsPaperConsequence != null) { NewspaperDisplay(newsPaperConsequence, app); }
            //if (emailConsequence != null) { EmailDisplay(emailConsequence); }
        }
    }
    // Loads the newspaper with consquence text and title+image for the corresponding application
    public void NewspaperDisplay(Consequence c, Apps app)
    {
        Debug.Log(app.Name);

        string[] descriptions = StringSplit(c.TextToDisplay);

        titleField.GetComponent<TextMeshProUGUI>().text = c.Header;
        descriptionField1.GetComponent<TextMeshProUGUI>().text = descriptions[0];
        descriptionField2.GetComponent<TextMeshProUGUI>().text = descriptions[1];
        imageField.sprite = Resources.Load<Sprite>(Path.Combine("wireframes", app.Logo));
    }

    private string[] StringSplit(string str)
    {
        int mid = 550;//tr.Length / 2;
        while (str[mid] != ' ')
        {
            mid++;
        }
        Debug.Log(mid);
        string[] output = new string[] { str.Substring(0, mid), str.Substring(mid + 1, str.Length - mid - 1) };
        return output;
    }


    // Keep! not fully implemented yet
    // Loads the email with consquence text and name for the corresponding application
    /*public void EmailDisplay(Consequence c)
    {
        //Load the parameters of consequence c to a new Email in the Email-tab

        emailNotification.GetComponent<CanvasGroup>().alpha = 1;
        nameMail.GetComponent<TextMeshProUGUI>().text = c.Sender;
        textMail.GetComponent<TextMeshProUGUI>().text = c.TextToDisplay;

        // Keep below
        //emailList.Add(new EmailConsequence(c, newEmail(), "Date"));
    }

    // Keep me - work in process
    /*public GameObject newEmail()
    {
        GameObject mail = Object.Instantiate(emailPrefab, /*parent*//*);
        return mail;
    }*/
}

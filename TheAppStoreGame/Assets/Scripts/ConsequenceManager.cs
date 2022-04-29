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

    public GameObject interactMessage;
    public Animator Popup;

    // Components and objects for the news popup, set in the Inspector
    public GameObject titleField;
    public GameObject descriptionField1;
    public GameObject descriptionField2;
    public Image imageField;
    public GameObject newsPopup;
    public GameObject newspaperModel;

    // Components and objects for the email
    public Image[] emailTabs;
    public GameObject emailPrefab;
    public GameObject emailScrollView;
    public List<EmailConsequence> emailList;
    public int unreadEmails;
    public TextMeshProUGUI[] emailComponents;   //Subject, Sender, Date, Content
    public GameObject notificationAudio;

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
        
        interactMessage.SetActive(false);
        Apps app;
        Consequence[] consequences;
        Consequence newsPaperConsequence = null;
        List<Consequence> emailConsequence = new List<Consequence>();

        if (GameManager.instance.evaluatedApps.Count != 0)
        {
            Popup.transform.GetChild(0).gameObject.SetActive(false); //Disables gameObject for popup
            Popup.ResetTrigger("Popup");                            // Resets the trigger parameter for the animation, to be able to retrigger it again later

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
                    case 2: emailConsequence.Add(c); break;
                }
            }
            //Calls for the corresponding Display-method if there are any new consequences to display in that location
            if (newsPaperConsequence != null) 
            { 
                NewspaperDisplay(newsPaperConsequence, app);
                newspaperModel.SetActive(true);
            }
            if (emailConsequence != null) 
            { 
                foreach(Consequence c in emailConsequence)
                {
                    EmailDisplay(c); 
                }
            }
        }
    }
    // Loads the newspaper with consquence text and title+image for the corresponding application
    public void NewspaperDisplay(Consequence c, Apps app)
    {
        Debug.Log(app.Name);
        Popup.transform.GetChild(0).gameObject.SetActive(true); // Set popup to active
        Popup.SetTrigger("Popup");                              // Triggers the animation

        string[] descriptions = StringSplit(c.TextToDisplay);

        titleField.GetComponent<TextMeshProUGUI>().text = c.Header;
        descriptionField1.GetComponent<TextMeshProUGUI>().text = descriptions[0];
        descriptionField2.GetComponent<TextMeshProUGUI>().text = descriptions[1];
        imageField.sprite = Resources.Load<Sprite>(Path.Combine("wireframes", app.Logo));
    }

    // Splits the newspaper content to fít around the image
        // string str - The newspaper content
        // Returns an array with two string
            // 0: string meant for the first text field
            // 1: string meant for the second text field
    private string[] StringSplit(string str)
    {
        int mid = 550;
        while (str[mid] != ' ')
        {
            mid++;
        }
        Debug.Log(mid);
        string[] output = new string[] { str.Substring(0, mid), str.Substring(mid + 1, str.Length - mid - 1) };
        return output;
    }


    // Loads the email with consquence text and name for the corresponding application
    // Uses UpdateNotifications to update notifications
        // Consequence c - the details of the email to be displayed
    public void EmailDisplay(Consequence c)
    {
        EmailConsequence tempMail = new EmailConsequence();
        GameObject tempMailObject = NewEmail(tempMail);
        tempMail.SetEmail(c, tempMailObject, "");
        emailList.Add(tempMail);
        unreadEmails++;
        UpdateNotifications();
        notificationAudio.SetActive(false);
        notificationAudio.SetActive(true);
    }

    // Creates a new email object
        // EmailConsequence e - the EmailConsequence the mail is meant to represent
    public GameObject NewEmail(EmailConsequence e)
    {
        GameObject mail = Object.Instantiate(emailPrefab, emailScrollView.transform);
        mail.GetComponent<Button>().onClick.AddListener(delegate { OpenEmail(e); });
        mail.transform.SetAsFirstSibling();
        return mail;
    }

    // Opens an email to the content panel, and updates it if it was unread
        // EmailConsequence mail - the mail being opened
    public void OpenEmail(EmailConsequence mail)
    {
        if (!mail.read)
        {
            mail.read = true;
            unreadEmails--;
            UpdateNotifications();
            mail.mail.GetComponent<Image>().sprite = Resources.Load<Sprite>(Path.Combine("UI Components/UIComps", "OpenedEmail"));
        }

        emailComponents[0].text = mail.subject.text;
        emailComponents[1].text = mail.sender.text;
        emailComponents[2].text = mail.date.text;
        emailComponents[3].text = mail.content.text;
    }

    // Checks for unread emails, and updates the tabs notifications accordingly
    public void UpdateNotifications()
    {
        if(unreadEmails > 0)
        {
            emailTabs[0].sprite = Resources.Load<Sprite>(Path.Combine("UI Components/UIComps", "inactiveTabNotification"));
            emailTabs[1].sprite = Resources.Load<Sprite>(Path.Combine("UI Components/UIComps", "activeTabNotification"));
            emailTabs[2].sprite = Resources.Load<Sprite>(Path.Combine("UI Components/UIComps", "inactiveTabNotification"));
        } 
        else
        {
            emailTabs[0].sprite = Resources.Load<Sprite>(Path.Combine("UI Components/UIComps", "inactiveTab"));
            emailTabs[1].sprite = Resources.Load<Sprite>(Path.Combine("UI Components/UIComps", "activeTab"));
            emailTabs[2].sprite = Resources.Load<Sprite>(Path.Combine("UI Components/UIComps", "inactiveTab"));
        }
    }
}

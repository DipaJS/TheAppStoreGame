using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JsonHandler;
using UnityEngine.UI;
using TMPro; // TextMeshPro package

//A class for Email objects
public class EmailConsequence
{
    public GameObject mail { get; set; }

    public TextMeshProUGUI sender { get; set; }
    public TextMeshProUGUI subject { get; set; }
    public TextMeshProUGUI content { get; set; }
    public TextMeshProUGUI date { get; set; }

    public bool read { get; set; }

    // Constructor
        // Consequence c - the contents for the email
        // GameObject mailObject - the GameObject holding the email
        // string date - the date displayed on the email
    public EmailConsequence(Consequence c, GameObject mailObject, string date)
    {
        mail            = mailObject;
        sender          = mail.transform.Find("Sender").gameObject.GetComponent<TextMeshProUGUI>();
        subject         = mail.transform.Find("Subject").gameObject.GetComponent<TextMeshProUGUI>();
        content         = mail.transform.Find("Content Preview").gameObject.GetComponent<TextMeshProUGUI>();
        this.date       = mail.transform.Find("Date").gameObject.GetComponent<TextMeshProUGUI>();
        read = false;

        sender.text     = c.Sender;
        subject.text    = c.Header;
        content.text    = c.TextToDisplay;
        this.date.text  = date;
    }

    // Constructor for an empty email
    public EmailConsequence(){}

    // Method to set all the variables of the email
        // Consequence c - the contents for the email
        // GameObject mailObject - the GameObject holding the email
        // string date - the date displayed on the email
    public void SetEmail(Consequence c, GameObject mailObject, string date)
    {
        mail = mailObject;
        sender = mail.transform.Find("Sender").gameObject.GetComponent<TextMeshProUGUI>();
        subject = mail.transform.Find("Subject").gameObject.GetComponent<TextMeshProUGUI>();
        content = mail.transform.Find("Content Preview").gameObject.GetComponent<TextMeshProUGUI>();
        this.date = mail.transform.Find("Date").gameObject.GetComponent<TextMeshProUGUI>();
        read = false;

        sender.text = c.Sender;
        subject.text = c.Header;
        content.text = c.TextToDisplay;
        this.date.text = date;
    }
}

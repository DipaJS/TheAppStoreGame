using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JsonHandler;
using UnityEngine.UI;
using TMPro; // TextMeshPro package

//A script for managing the Email-tab 
    //Will be attached to 'MailTabActive' in 'GamePlayView'
public class EmailConsequence
{
    public GameObject mail { get; set; }

    public TextMeshProUGUI sender { get; set; }
    public TextMeshProUGUI subject { get; set; }
    public TextMeshProUGUI content { get; set; }
    public TextMeshProUGUI date { get; set; }
    public GameObject notification { get; set; }
    public Image emailIcon { get; set; }

    public EmailConsequence(Consequence c, GameObject mailObject, string date)
    {
        mail            = mailObject;
        sender          = mail.transform.Find("Sender").gameObject.GetComponent<TextMeshProUGUI>();
        subject         = mail.transform.Find("Subject").gameObject.GetComponent<TextMeshProUGUI>();
        content         = mail.transform.Find("Content Preview").gameObject.GetComponent<TextMeshProUGUI>();
        this.date       = mail.transform.Find("Date").gameObject.GetComponent<TextMeshProUGUI>();
        notification    = mail.transform.Find("Notification").gameObject;
        emailIcon       = mail.transform.Find("Email Icon").gameObject.GetComponent<Image>();

        sender.text     = c.Sender;
        subject.text    = c.Header;
        content.text    = c.TextToDisplay;
        this.date.text  = date;
    }
}

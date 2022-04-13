using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JsonHandler;

public class EmailConsequence
{
    public string sender { get; set; }
    public string subject { get; set; }
    public string content { get; set; }
    public GameObject mail { get; set; }

    public EmailConsequence(Consequence consequence, GameObject mailObject)
    {
        sender = consequence.Sender;
        subject = consequence.Subject;
        content = consequence.Subject;
        mail = mailObject;
    }
}

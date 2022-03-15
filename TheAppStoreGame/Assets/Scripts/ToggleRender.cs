using UnityEngine;
using System.Collections;

//A script for attaching a "blinking" effect on a game object
//attached to 'newspaperModel' in 'GameView'

//Lack of comments in this script due to copy paste from https://forum.unity.com/threads/how-do-we-make-a-blinking-objects.92108/

public class ToggleRender : MonoBehaviour
{
    public float Duration = 3f;
    public bool State = true;  
    public bool Repeat = false;
    public int RepeatTime = 0;
 
        int repeatTime = 0;
   
    void OnEnable()
    {
        if(!GetComponent<Renderer>())
        {
            enabled = false;
            return;
        }
 
               // make sure we dont have negative counter set
        RepeatTime = Mathf.Abs(RepeatTime);
 
               // store RepeatTime for reset
        repeatTime = RepeatTime;
       
        GetComponent<Renderer>().enabled = State;
        if(!Repeat)
            Invoke("Activate", Duration);
        else
            InvokeRepeating("ActivateRepeating", Duration, Duration);
    }
   
    void Activate()
    {
        GetComponent<Renderer>().enabled = !State;
        enabled = false;
    }
   
    void ActivateRepeating()
    {
        State = !State;
        GetComponent<Renderer>().enabled = State;
       
        if(CheckCount())
        {
            CancelInvoke();
                        RepeatTime = repeatTime;
            enabled = false;
        }
    }
   
    bool CheckCount()
    {
        RepeatTime --;
       
        if(RepeatTime == 0)
            return true;
        else
            return false;
    }
}

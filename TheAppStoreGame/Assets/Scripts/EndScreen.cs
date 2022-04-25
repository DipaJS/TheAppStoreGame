using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using JsonHandler;
using TMPro;
using System.IO;
public class EndScreen : MonoBehaviour
{
    //An array with the final scores for each code
    private int[] finalScores;
    private int[] totalFollowed;
    private int[] totalBroken;

    private int[] test;

    private string interactedAcm;

    public TextMeshProUGUI[] honoredCodes;

    public TextMeshProUGUI learnMore;

    public GameObject learnMorePanel;

    public GameObject centerPart;

    //start is called before the first frame update
    void Start(){
        finalScores = GetFinalScores();
        totalBroken = GetTotalBroken();
        totalFollowed = GetTotalFollowed();
        test = new int[]{1,2,3,4,5,6,7};
        //honoredCodes = new TextMeshProUGUI[7];
        UpdateCodes();
    }

    //FinalScores uses AddArrays to add all scores together for each code so that we can present a final score to the player
    public int[] GetFinalScores(){
        int[] scores = new int[]{0,0,0,0,0,0,0};

        foreach (Apps app in GameManager.instance.allEvaluatedApps)
        {
            if (app.Status)
            {
                scores = AddArrays(scores, (AddArrays(app.Accepted.Acm.PositiveCodeScores, app.Accepted.Acm.NegativeCodeScores)));
            }
        }
        return scores;
    }
    
    public string UpdateAcmInteractions(int i){
        string s ="";
        foreach (Apps app in GameManager.instance.allEvaluatedApps){
            if(app.Accepted.Acm.PositiveCodeScores[i] > 0){s+=("Accepted " + app.Name + " : " +finalScores[i] + "\n");
            }
        }
        return s;
    }
    public void SetLearnMoreText(int i){
        learnMore.text = UpdateAcmInteractions(i);
        learnMorePanel.SetActive(true);
        centerPart.SetActive(false);
    }
    public int[] GetTotalFollowed(){
        int[] scores = new int[]{0,0,0,0,0,0,0};

        foreach (Apps app in GameManager.instance.allEvaluatedApps)
        {
            if (app.Status)
            {
                scores = AddArrays(scores, app.Accepted.Acm.PositiveCodeScores);
            }
        }
        return scores;
    }

    public int[] GetTotalBroken()
    {
        int[] scores = new int[]{0,0,0,0,0,0,0};

        foreach (Apps app in GameManager.instance.allEvaluatedApps)
        {
            if (app.Status)
            {
                scores = AddArrays(scores, app.Accepted.Acm.NegativeCodeScores);
            }
        }
        return scores;
    }

    public void UpdateCodes(){
        int i=0;
        foreach(TextMeshProUGUI code in honoredCodes){
            code.text = "1."+(i+1)+" honored on " + totalFollowed[i] + " instances";
            i++;
        }
    }
    //Returns the score for the specific code given by index (note code 1 is index 0, code 2 index 1 etc.)
    public int GetScore(int index){
        return finalScores[index];
    }

    //Sums the individual values of two arrays together 
        //[a,b,c] + [d,e,f] = [a+d,b+e,c+f] 
    public static int[] AddArrays(int[] a, int[] b)

    {
        return a.Zip(b, (x,y) => x+y).ToArray();
    }

}

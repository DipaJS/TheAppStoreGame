using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using JsonHandler;

public class EndScreen : MonoBehaviour
{
    //An array with the final scores for each code
    public int[] finalScores;

    //start is called before the first frame update
    void Start(){
        finalScores = FinalScores();
    }

    //FinalScores uses AddArrays to add all scores together for each code so that we can present a final score to the player
    public int[] FinalScores(){
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

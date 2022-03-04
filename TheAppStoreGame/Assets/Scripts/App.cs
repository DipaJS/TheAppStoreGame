using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App //: MonoBehaviour
{
    private string title; 
    private string descripton; 
    private string consequence;
    private Sprite image; 
    

    public App(string AppTitle, string AppDescripton, Sprite AppImage, string AppConsequence){
    	title = AppTitle;
    	descripton = AppDescripton;
    	image = AppImage;
        consequence = AppConsequence;
    }

    public string getTitle(){
    	return title; 
    }

    public string getDescripton(){
    	return descripton;
    }

    public Sprite getImage(){
    	return image;
    }

    public string getConsequence(){
        return consequence;
    }
}

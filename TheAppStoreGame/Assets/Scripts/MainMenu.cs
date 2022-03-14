using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


//A script to add funtionality to the Main Menu in the game
//Attached to 'MainMenu' in 'StartScreen'
public class MainMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    //Loads the disclaimer scene to the game which is the first scene in the gameloop
    public void StartGame()
    {
        SceneManager.LoadScene("Disclaimer");  
    }

    //Loads a scene with information on how to play the game
    public void GoToHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }


    public void ExitGame()
    {
        Debug.Log("Exit"); 
        Application.Quit();
    }


    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }


    public void GoToStartScreen()
    {
        SceneManager.LoadScene("StartScreen");
    }


    public void GoToGameView()
    {
        SceneManager.LoadScene("GameView");
    }
}

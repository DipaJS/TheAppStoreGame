using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public void StartGame()
    {
        SceneManager.LoadScene("GameView");  
    }

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



    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}

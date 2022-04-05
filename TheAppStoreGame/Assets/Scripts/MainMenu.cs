using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


// A script to add funtionality to the Main Menu in the game
    // Attached to 'MainMenu' in 'StartScreen'
    // Attached to 'Disclaimer' in 'Disclaimer'
    // Attached to 'How to Play' in 'HowToPlay'
    // Attached to 'Blue Box' in 'EndScreen'
public class MainMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    // Loads a new scene based on the input string
        // string scene - the name of the scene to be loaded
        // Called with "HowToPlay" by 'HowToPlayButton' in 'StartScreen'
        // Called with "StartScreen" by 'AgreeButton' in 'Disclaimer'
        // Called with "StartScreen" by 'GotItButton' in 'HowToPlay'
        // Called with "StartScreen" by 'RestartButton' in 'EndScreen'
        // Called with "EndScreen" by 'End session' in 'GameView'
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    // Closes the game
        // Called by 'DeclineButton' in 'Disclaimer'
        // Called by 'QuitButton' in 'StartScreen'
        // Called by 'QuitButton' in 'EndScreen'
    public void ExitGame()
    {
        Debug.Log("Exit"); 
        Application.Quit();
    }

    // Moves to the PlayerDetails scene, or to GameView if the player details are already filled
        // Called by 'PlayButton' in 'StartScreen'
    public void startGame()
    {
        string scene;
        if (GameManager.instance.playerDetailsFilled)
        {
            scene = "GameView";
        }
        else
        {
            scene = "PlayerDetails";
        }

        ChangeScene(scene);
    }


    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}

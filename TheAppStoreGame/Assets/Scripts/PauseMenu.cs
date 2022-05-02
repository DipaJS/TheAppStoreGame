using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public static bool PauseGame = false;
	public GameObject PauseMenuUI;
	public GameObject PlayerOfficeObject;


    // Update is called once per frame
    void Update()
    {	
        if (Input.GetKeyDown(KeyCode.Escape)){
			if(PauseGame){
				Resume();
			}
			else{
			Pause();
		}
    }
}

public void Resume(){
	PlayerOfficeObject.GetComponent<Collider>().enabled = true;
	PauseMenuUI.SetActive(false);
	PauseGame = false;
	Debug.Log("Resumed");
}
void Pause() {
	Debug.Log("Paused");
	PlayerOfficeObject.GetComponent<Collider>().enabled = false;
	PauseMenuUI.SetActive(true);
	PauseGame = true;
}
public void QuitGame(){
	Debug.Log("Quit");
	Application.Quit();
}
}


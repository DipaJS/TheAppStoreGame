using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class TypeWriterEffect : MonoBehaviour
{

	public float delay = 0.05f;
	public string fullText;
	private string currentText = "";

	// Use this for initialization
	void Start()
	{
		StartCoroutine(ShowText());
	}

	IEnumerator ShowText()
	{
		for (int i = 0; i < fullText.Length +1 ; i++)
		{
			currentText = fullText.Substring(0, i);
			this.GetComponent<Text>().text = currentText;
			yield return new WaitForSeconds(delay);
		}
		SceneManager.LoadScene("GameView");
	}
}

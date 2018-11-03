using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {	
	
	//Method to load scene "Name" on click of button
	public void LoadTheScene(string name){
		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}
	
	//Method to quit the game when button of quit is clicked
	public void QuitTheGame(){
		Application.Quit();
	}


}

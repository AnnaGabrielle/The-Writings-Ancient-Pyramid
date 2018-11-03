using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinController : MonoBehaviour {
	[SerializeField] State secretWinState;
	[SerializeField] State winWithoutStatueState;
	[SerializeField] State winWithStatueState;
	[SerializeField] State winState;
	public GameObject secretWinGameObject;
	public GameObject winWithoutStatueGameObject;
	public GameObject winWithStatueGameObject;

	public Text textComponent; 

	// Use this for initialization
	void Start () {
		CheckWin();
	}

	private void CheckWin(){
		//GameObject gameManager = GameObject.Find("GamePlay");
		//GameMechanic gameMechanic = gameManager.GetComponent<GameMechanic>();
		State currentState = GameMechanic.currentState;
		bool statue = GameMechanic.statueInventory;
		if(currentState == secretWinState){
			secretWinGameObject.SetActive(true);
			winWithStatueGameObject.SetActive(false);
			winWithoutStatueGameObject.SetActive(false);
			textComponent.text = currentState.GetStateStory();
		}
		else if(currentState== winState && statue == true){
			secretWinGameObject.SetActive(false);
			winWithStatueGameObject.SetActive(true);
			winWithoutStatueGameObject.SetActive(false);
			textComponent.text = winWithStatueState.GetStateStory();			
		}
		else{
			secretWinGameObject.SetActive(false);
			winWithStatueGameObject.SetActive(false);
			winWithoutStatueGameObject.SetActive(true);	
			textComponent.text = winWithoutStatueState.GetStateStory();		
		}
	}

}

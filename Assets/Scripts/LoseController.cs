using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoseController : MonoBehaviour {
	[SerializeField] State loseForceExitState;
	[SerializeField] State loseHandInHoleState;
	[SerializeField] State losePushButtonState;
	[SerializeField] State loseTouchMummy;

	public GameObject forceExitGameObject;
	public GameObject handInHoleGameObject;
	public GameObject pushButtonGameObject;
	public GameObject touchMummyGameObject;

	public Text textComponent; 

	// Use this for initialization
	void Start () {
		CheckLose();
	}
	
	private void CheckLose(){
		//GameObject gameManager = GameObject.Find("GamePlay");
		//GameMechanic gameMechanic = gameManager.GetComponent<GameMechanic>();
		State currentState = GameMechanic.currentState;
		if(currentState == loseForceExitState){
			forceExitGameObject.SetActive(true);
			handInHoleGameObject.SetActive(false);
			pushButtonGameObject.SetActive(false);
			touchMummyGameObject.SetActive(false);
			textComponent.text = currentState.GetStateStory();
		}

		else if(currentState == loseHandInHoleState){
			forceExitGameObject.SetActive(false);
			handInHoleGameObject.SetActive(true);
			pushButtonGameObject.SetActive(false);
			touchMummyGameObject.SetActive(false);
			textComponent.text = currentState.GetStateStory();
		}
		else if(currentState == losePushButtonState){
			forceExitGameObject.SetActive(false);
			handInHoleGameObject.SetActive(false);
			pushButtonGameObject.SetActive(true);
			touchMummyGameObject.SetActive(false);
			textComponent.text = currentState.GetStateStory();
		}
		else{
			forceExitGameObject.SetActive(false);
			handInHoleGameObject.SetActive(false);
			pushButtonGameObject.SetActive(false);
			touchMummyGameObject.SetActive(true);
			textComponent.text = currentState.GetStateStory();
		}

	}


}

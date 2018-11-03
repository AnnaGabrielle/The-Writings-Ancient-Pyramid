using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DiceScript : MonoBehaviour {

	[SerializeField] State exitState;
	[SerializeField] State loseExitState;
	[SerializeField] string LoseScene;
	public void DiceRoll()
	{
		GameObject gameManager = GameObject.Find("GamePlay");
		GameMechanic gameMechanic = gameManager.GetComponent<GameMechanic>();

		int diceValue;
		diceValue = Random.Range(1,7);
		if(diceValue>2){ 
			GameMechanic.currentState = exitState; 
			gameMechanic.textComponent.text = GameMechanic.currentState.GetStateStory();
		}
		else{
			GameMechanic.currentState = loseExitState;
			SceneManager.LoadScene(LoseScene);
		}

	}


}

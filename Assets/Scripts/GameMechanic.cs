using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameMechanic : MonoBehaviour {

	[SerializeField] string WinScene;
	[SerializeField] string LoseScene;

	public Text textComponent; //public so it can be used in other scripts
	[SerializeField] State startState;
	static public State currentState = null; //public so it can be used in other scripts

	//states to get objects
	[SerializeField] State stateForMap;
	[SerializeField] State stateForStone;
	[SerializeField] State stateForStatue;
	[SerializeField] State stateForButton;
	[SerializeField] State stateAfterButton;
	[SerializeField] State stateReadWall;


 	//GameObjects for the inventory
	public GameObject inventoryStone;
	public GameObject inventoryMap;
	public GameObject inventoryStatue;
	public GameObject inventoryButton;

	//GameObjects for secret texts and image that show only in specific times
	public GameObject hiddenTextEntrance;
	public GameObject hiddenTextCorridor;
	public GameObject hiddenTextButton;
	public GameObject hiddenTextExit;
	public GameObject hiddenTextSarcophagusRoom;
	public GameObject hiddenTextPushButton;
	public GameObject hiddenAlienBackground;

	//variable to verify if the button was already pushed
	bool sarcophagusRoom;

	//variables to verify if the player read the walls
	bool wallReadOnChamber;

	//variable to verify if player got the statue
	public static bool statueInventory;



	//States affected by inventory
	[SerializeField] State stateAffectedByMap;
	[SerializeField] State stateAffectedByStone;
	[SerializeField] State stateAffectedByButton;
	[SerializeField] State stateBeforeButton;
	[SerializeField] State stateAffectedByWallRead;

	//State in which specific image will be shown
	[SerializeField] State stateOfAlien;




	void Awake(){
		inventoryButton.SetActive(false);
		inventoryMap.SetActive(false);
		inventoryStatue.SetActive(false);
		inventoryStone.SetActive(false);
		hiddenAlienBackground.SetActive(false);
		sarcophagusRoom=false;
		statueInventory = false;
		hiddenTextCorridor.SetActive(false);
		hiddenTextEntrance.SetActive(false);
		hiddenTextSarcophagusRoom.SetActive(false);
		hiddenTextExit.SetActive(false);
		hiddenTextButton.SetActive(false);
		hiddenTextPushButton.SetActive(false);

	}

	// Use this for initialization
	void Start () 
	{
		currentState = startState;
		textComponent.text = currentState.GetStateStory();		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//CheckWinLoseStates();
		CheckHiddenStates();
		ManageState();
		CheckForInventory();
		CheckHiddenText();
		
	}

    private void ManageState()
    {
        var nextStates = currentState.GetNextStates();

		for(int index = 0; index<nextStates.Length;index++){
			if(Input.GetKeyDown(KeyCode.Alpha1 + index)){
				currentState = nextStates[index];
			}
		}
		CheckWinLoseStates();
		//textComponent.text = currentState.GetStateStory();
    }

	private void ManageHiddenState(State onState)
	{	//manage the states that depend on others
		var nextStates = currentState.GetNextStates();
		int lengthnextStates = nextStates.Length;
		var nextHiddenState = onState.GetHiddenState();
		for(int index=0; index<nextHiddenState.Length; index++){
			if(Input.GetKeyDown(KeyCode.Alpha1 + lengthnextStates + index)){
				currentState = nextHiddenState[index];
			}
		}
		textComponent.text = currentState.GetStateStory();
	}


	private void CheckForInventory(){
		if(currentState == stateForMap){
			inventoryMap.SetActive(true);
		}
		else if(currentState == stateForStatue){
			inventoryStatue.SetActive(true);
			statueInventory = true;
		}
		else if(currentState == stateForStone){
			inventoryStone.SetActive(true);
		}
		else if(currentState == stateForButton){
			inventoryButton.SetActive(true);
			hiddenTextPushButton.SetActive(true);
			sarcophagusRoom=true;
		}
		else if(currentState == stateAfterButton){
			inventoryButton.SetActive(false);
			hiddenTextPushButton.SetActive(false);
		}
		else if(currentState == stateReadWall){
			wallReadOnChamber = true;
		}

	}

	private void CheckHiddenStates(){
		//check if the gameObject is active
		if(inventoryMap.activeInHierarchy==true && currentState==stateAffectedByMap){
			ManageHiddenState(stateAffectedByMap);
		}
		if(inventoryStone.activeInHierarchy == true && currentState==stateAffectedByStone){
			ManageHiddenState(stateAffectedByStone);
		}
		if(sarcophagusRoom == true && currentState == stateAffectedByButton){
			ManageHiddenState(stateAffectedByButton);
		}
		if(currentState == stateBeforeButton && sarcophagusRoom == false){
			ManageHiddenState(stateBeforeButton);
		}
		if(currentState == stateAffectedByWallRead && wallReadOnChamber == true){
			ManageHiddenState(stateAffectedByWallRead);
		}
	}

	private void CheckHiddenText(){
		//Check if conditions are met to the hidden text appear or disappear
		if(inventoryMap.activeInHierarchy==true)
		{
			if(currentState == stateAffectedByMap){
				hiddenTextEntrance.SetActive(true);
			}
			else{
				hiddenTextEntrance.SetActive(false);
			}
		}
		if(inventoryStone.activeInHierarchy==true)
		{
			if(currentState == stateAffectedByStone){
				hiddenTextExit.SetActive(true);
			}
			else{
				hiddenTextExit.SetActive(false);
			}
		}
		if(sarcophagusRoom==true)
		{
			if(currentState == stateAffectedByButton){
				hiddenTextSarcophagusRoom.SetActive(true);
			}
			else{
				hiddenTextSarcophagusRoom.SetActive(false);
			}
		}
		if(currentState == stateBeforeButton){
			if(sarcophagusRoom == false){
				hiddenTextButton.SetActive(true);
			}
			else{
				hiddenTextButton.SetActive(false);
			}
		}
		else{
			hiddenTextButton.SetActive(false);
		}
		if(wallReadOnChamber == true){
			if(currentState == stateAffectedByWallRead){
				hiddenTextCorridor.SetActive(true);
			}
			else{
				hiddenTextCorridor.SetActive(false);
			}
			if(currentState == stateOfAlien){
				hiddenAlienBackground.SetActive(true);
			}
			else{
				hiddenAlienBackground.SetActive(false);
			}
		}
	}

	private void CheckWinLoseStates(){
		var typeOfState = currentState.GetTypeOfState();
		switch(typeOfState)
		{
			case TypeOfState.Win:
				SceneManager.LoadScene(WinScene);
				break;
			case TypeOfState.Lose:
				SceneManager.LoadScene(LoseScene);
				break;
			default:
				textComponent.text = currentState.GetStateStory();
				break;

		}
		
	}
}

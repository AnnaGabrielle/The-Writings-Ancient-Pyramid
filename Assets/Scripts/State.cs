using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfState{Normal, Win, Lose};
[CreateAssetMenu(menuName="State")]

public class State : ScriptableObject {

	[TextArea(10,14)][SerializeField] string storyText;
	[SerializeField] State[] nextStates;
	[SerializeField] State[] hiddenStates;

	public TypeOfState stateType;

	public string GetStateStory()
	{
		return storyText;
	}


	public State[] GetNextStates()
	{
		return nextStates;
	}
	
	public State[] GetHiddenState()
	{
		return hiddenStates;
	}

	public TypeOfState GetTypeOfState(){
	 	return stateType;
	 }

}

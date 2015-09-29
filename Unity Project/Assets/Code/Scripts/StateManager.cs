using UnityEngine;
using Assets.Code.States;
using Assets.Code.Interfaces;	// where IStateBase is

public class StateManager : MonoBehaviour
{
	private IStateBase activeState;	// what the states inherit from

	private static StateManager instanceRef;

	void Awake()
	{
		if(instanceRef == null)
		{
			instanceRef = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			DestroyImmediate(gameObject);
		}
	}

	void Start()
	{								// this = manageRef
		activeState = new BeginState(this);
		Debug.Log("This object is of type: " + activeState);
	}

	void Update()
	{
		if(activeState != null)
		{
			activeState.StateUpdate();
		}
	}

	public void SwitchState(IStateBase newState)
	{
		activeState = newState;
	}


	// this method is caled every frame
	// for displaying graphics, text, and buttons
	void OnGUI()
	{
		if(activeState != null)
		{
			activeState.ShowIt();
		}
	}
}
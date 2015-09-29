using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
	public class WonState : IStateBase
	{
		private StateManager manager;

		public WonState(StateManager manageRef)	// Constructor
		{
			manager = manageRef;
			Debug.Log("Constructing WonState");
		}

		public void StateUpdate()
		{
			if(Input.GetKeyUp(KeyCode.Space))
			{
				manager.SwitchState(new BeginState(manager));
				Application.LoadLevel("Beginning State");
			}
		}

		public void ShowIt()
		{
			
		}
	}
}
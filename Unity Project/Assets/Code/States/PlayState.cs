using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
	public class PlayState : IStateBase
	{
		private StateManager manager;

		public PlayState(StateManager manageRef)	// Constructor
		{
			manager = manageRef;
			Debug.Log("Constructing PlayState");
		}

		public void StateUpdate()
		{
			if(Input.GetKeyUp(KeyCode.Space))
			{
				manager.SwitchState(new WonState(manager));
				Application.LoadLevel("BeginningScene");
			}

			if(Input.GetKeyUp(KeyCode.Return))
			{
				manager.SwitchState(new LostState(manager));
			}
		}

		public void ShowIt()
		{
			
		}
	}
}
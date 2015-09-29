using UnityEngine;
using Assets.Code.Interfaces;

namespace Assets.Code.States
{
	public class BeginState : IStateBase
	{
		// new object: type: StateManger, name: manager
		private StateManager manager;
		private float futureTime = 0;
		private int countDown = 0;
		private float screenDuration = 8;

		public BeginState(StateManager manageRef)	// Constructor
		{
			manager = manageRef;
			futureTime = screenDuration + Time.realtimeSinceStartup;
			Debug.Log("Constructing BeginState");
			Time.timeScale = 1;
		}

		public void StateUpdate()
		{
			float rightNow = Time.realtimeSinceStartup;
			countDown = (int)futureTime - (int)rightNow;

			if(Input.GetKeyUp(KeyCode.Space) || countDown <= 0)
			{
				Switch();
			}
		}

		public void ShowIt()
		{						// 10,10 = position; 150,100 = size; "Press to Play" = words
			if(GUI.Button(new Rect(10,10,150,100), "Press to Play"))
			{
				Switch();
			}

			if(GUI.Button(new Rect(10,120,150,100), "Pause"))
			{
				Time.timeScale = 0;
			}

			GUI.Box (new Rect (Screen.width - 60,10,50,25), countDown.ToString());
		}

		void Switch()
		{
			Time.timeScale = 1;
			Application.LoadLevel("Unity Project");		// name of scen save file
			manager.SwitchState(new PlayState(manager));
		}
	}
}
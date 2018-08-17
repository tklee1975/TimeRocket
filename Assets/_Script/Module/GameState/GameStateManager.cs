using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kencoder
{		

	public class GameStateManager : MonoBehaviour {
		
		#region State Control
		private BaseGameState mLastState = null;
		private BaseGameState mCurrentState;

		public BaseGameState State
		{
			get { return mCurrentState; }
		}

		public BaseGameState LastState
		{
			get { return mLastState; }
		}


		//Changes the current game state
		public BaseGameState SetState(System.Type newStateType)
		{
			if (mCurrentState != null)
			{
				mCurrentState.OnExit();
			}
			mLastState = mCurrentState;

			mCurrentState = GetComponentInChildren(newStateType) as BaseGameState;
			//Debug.Log("Change to newState: " + newStateType + " stateObj=" + mCurrentState);
			if (mCurrentState != null)
			{
				mCurrentState.OnEnter();
			}

			return mCurrentState;
		}

		void Update()
		{			
			if (mCurrentState != null)
			{
				mCurrentState.OnUpdate();
			}
		}
		#endregion
	}
}
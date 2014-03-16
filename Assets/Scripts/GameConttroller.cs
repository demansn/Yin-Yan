using UnityEngine;
using System.Collections;

public class GameConttroller : MonoBehaviour {

	public CharacterControll characterControll;
	public float pauseTime = 1;
	public float backwardMoveTime = 1;

	public void StartMoveBackward(){
		SetPauseMove (true);

		Invoke ("MoveBackward", pauseTime);
	}

	public void SetPauseMove(bool isPause){

		MovementController[] movementControllers = MonoBehaviour.FindObjectsOfType<MovementController> ();
		
		foreach (MovementController movementController in movementControllers) {			
			
			movementController.isPause = isPause;
			
		}
		
		characterControll.isPause = isPause;
	}

	public void MoveBackward(){


		MovementController[] movementControllers = MonoBehaviour.FindObjectsOfType<MovementController> ();
		
		foreach (MovementController movementController in movementControllers) {			
			
			movementController.BackwardMove(backwardMoveTime);
			
		}

		characterControll.BackwardMove (backwardMoveTime);

		SetPauseMove (false);

	}
}

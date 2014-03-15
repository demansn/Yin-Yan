using UnityEngine;
using System.Collections;

public class GameConttroller : MonoBehaviour {

	public CharacterControll characterControll;
	public int mainCircle;

	public void MoveBackward(){

		float backwardMoveTime = 3f;

		MovementController[] movementControllers = MonoBehaviour.FindObjectsOfType<MovementController> ();
		
		foreach (MovementController movementController in movementControllers) {			
			
			movementController.BackwardMove(backwardMoveTime);
			
		}

		characterControll.BackwardMove (backwardMoveTime);

	}
}

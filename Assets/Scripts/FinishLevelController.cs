using UnityEngine;
using System.Collections;

public class FinishLevelController : MonoBehaviour {

	public int nextLevelIndex;
	private GameConttroller gameController;
	
	void Start () {
		gameController = GameObject.FindWithTag("GameController").GetComponent<GameConttroller>();
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player" && gameController != null){
			gameController.CurrentLevelFinished();

		}
	}
}

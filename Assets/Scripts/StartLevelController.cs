using UnityEngine;
using System.Collections;

public class StartLevelController : MonoBehaviour {

	private CameraControll cameraController;
	private GameConttroller gameController;

	void Start () {

		if(Camera.main != null){
			cameraController = Camera.main.GetComponent<CameraControll>();
		}

		gameController = GameObject.FindWithTag("GameController").GetComponent<GameConttroller>();
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player" && cameraController && gameController){
			cameraController.isMove = true;
			gameController.StartMoveBlocks();		
		}
	
	}

}

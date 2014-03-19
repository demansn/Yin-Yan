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


	void OnTriggerStay(Collider other){

		if(other.tag == "Player" && other.transform.position.y >= transform.position.y){

			cameraController.isMove = true;
			gameController.StartMoveBlocks();
			Destroy(gameObject);	

		}		
	}
}
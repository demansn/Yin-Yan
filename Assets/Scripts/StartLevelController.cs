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
		gameController.SetStart(gameObject);

	}


	void OnTriggerStay(Collider other){

		if(other.tag == "Player"){

			if(gameController.isStartedGame){

				if(other.transform.position.y >= transform.position.y){
										
					gameController.StartLevel();
					Destroy(gameObject);	
				}

			} else {

				if(other.transform.position.y <= transform.position.y){

					gameController.StartLevel();
					Destroy(gameObject);	
				}

			}

		}		
	}


}
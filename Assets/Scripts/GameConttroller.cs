using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameConttroller : MonoBehaviour {

	protected int GAME_OBJECT_LAYER_INDEX = 9;
	public CharacterControll characterControll;
	public float pauseTime = 1;
	public float backwardMoveTime = 1;
	public bool isStartedGame = false;
	public bool isPauseGame = false;
	public GameObject player;
	public CameraControll cameraController;
	private GameObject start;
	private int currentLevelIndex = 0;
	private AsyncOperation async;

	void Start(){
		

	}

	public void StartGame(){
		isStartedGame = true;
	}

	public void SetStart(GameObject newStart){

		if(start != null){
			Destroy(start);
			start = null;
		}

		start = newStart;

		if(start != null){

			characterControll.startPosition = start.transform.position;

		}
	
	}

	public void SetPauseGame(bool isPause){
		isPauseGame = isPause;
	}

	void StartLoadNextLevel(){

		GameObject[] gameObjects = FindGameObjectsWithLayer(GAME_OBJECT_LAYER_INDEX);
		
		foreach (GameObject go in gameObjects) {
			
			Destroy(go);
			
		}

		player.SetActive(false);

		cameraController.ResetPosition();
		characterControll.ResetPosition();
		characterControll.isAccelerated = false;

		currentLevelIndex += 1;

		Invoke("LoadLevel", 1);
	}

	public void LoadLevel(){

		Application.LoadLevelAdditive(currentLevelIndex);
		characterControll.isAccelerated = true;
		player.SetActive(true);

	}

	public void CurrentLevelFinished() {
		cameraController.isMove = false;

		Invoke("StartLoadNextLevel", 2);
		 
	}
	
	public void StartMoveBackward(){

		if(!characterControll.isPause){
			SetPauseMove (true);

			Invoke ("MoveBackward", pauseTime);
		}
	}

	public void StartMoveBlocks(){

		MovementController[] movementControllers = MonoBehaviour.FindObjectsOfType<MovementController> ();
		
		foreach (MovementController movementController in movementControllers) {			
			
			movementController.isPause = false;
			
		}
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

	GameObject[] FindGameObjectsWithLayer(int layer){

		GameObject[] goArray = GameObject.FindObjectsOfType<GameObject>();
	
		List<GameObject> goList = new List<GameObject>();

		for (var i = 0; i < goArray.Length; i++) {
			if (goArray[i].layer == layer) {
				goList.Add(goArray[i]);
			}
		}

		return goList.ToArray();

	}

	void Update(){
		
		
	}
}

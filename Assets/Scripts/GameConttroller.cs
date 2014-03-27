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
	private Edelweiss.DecalSystem.Example.collisionDetect collDetect;
	private Edelweiss.DecalSystem.Example.collisionDetect2 collDetect2;
	private CameraControll cameraControll;

	void Start(){
		collDetect = MonoBehaviour.FindObjectOfType<Edelweiss.DecalSystem.Example.collisionDetect>();
		collDetect2 = MonoBehaviour.FindObjectOfType<Edelweiss.DecalSystem.Example.collisionDetect2>();
		cameraControll = MonoBehaviour.FindObjectOfType<CameraControll>();
	}

	public void StartLevel(){

		isStartedGame = true;
		cameraController.isMove = true;
		StartMoveBlocks();
	
	}

	public void SetStart(GameObject newStart){

		
		characterControll.startPosition = newStart.transform.position;

		start = newStart;		
	
	
	}

	public void SetPauseGame(bool isPause){
		SetPauseMove(isPause);

		if(isPause){
			cameraControll.MoveToMenu();
		} else {
			cameraControll.MoveBack();
		}

	}

	public void StartLoadLevel(int levelIndex){

		currentLevelIndex = levelIndex;

		DestroyLevelObjects();		

		Application.LoadLevelAdditive(levelIndex + 1);	

		collDetect.CreateDecals();
		collDetect2.CreateDecals();		
	}

	void StartLoadNextLevel(){

		currentLevelIndex += 1;

		DestroyLevelObjects();

		player.SetActive(false);

		cameraController.ResetPosition();
		characterControll.ResetPosition();
		characterControll.isAccelerated = false;

		Invoke("LoadLevel", 1);
	}

	void LoadLevel(){

		Application.LoadLevelAdditive(currentLevelIndex + 1);
		//characterControll.isAccelerated = true;
		player.SetActive(true);
		collDetect.CreateDecals();
		collDetect2.CreateDecals();
	}

	public void CurrentLevelFinished() {
		cameraController.isMove = false;
		characterControll.isAccelerated = true;
		Invoke("StartLoadNextLevel", 2);
		 
	}
	
	public void StartMoveBackward(){

		if(!characterControll.isPause){
			SetPauseMove (true);

			Invoke ("MoveBackward", pauseTime);
		}
	}

	public void StartMoveBlocks(){

		Debug.Log("Call startMoveBlocks");

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

		Debug.Log("call MoveBackward");


		MovementController[] movementControllers = MonoBehaviour.FindObjectsOfType<MovementController> ();
		
		foreach (MovementController movementController in movementControllers) {			
			
			movementController.BackwardMove(backwardMoveTime);

		}

		characterControll.BackwardMove (backwardMoveTime);

		if(!characterControll.isGameState){
			characterControll.isGameState = true;	
		}

		SetPauseMove (false);

	}

	void DestroyLevelObjects(){

		GameObject[] gameObjects = FindGameObjectsWithLayer(GAME_OBJECT_LAYER_INDEX);
		
		foreach (GameObject go in gameObjects) {
			
			Destroy(go);
			
		}
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
}

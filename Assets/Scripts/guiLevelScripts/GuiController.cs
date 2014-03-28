using UnityEngine;
using System.Collections;

public class GuiController : MonoBehaviour {

	private MainMenu mainMenu;
	private CameraControll cameraControll;
	private BackButton backButton;
	private StartButton startButton;
	private GameConttroller gameController;
	private PauseButton pauseButton;
	private CharacterControll characterControll;

	private GameObject headerText;

	private bool hideMainMenu = false;
	private bool canExit = true;
	public bool escape = true;

	// Use this for initialization
	void Start () {
		mainMenu = MonoBehaviour.FindObjectOfType<MainMenu>();
		cameraControll = MonoBehaviour.FindObjectOfType<CameraControll>();
		backButton = MonoBehaviour.FindObjectOfType<BackButton>();
		startButton = MonoBehaviour.FindObjectOfType<StartButton>();
		gameController = MonoBehaviour.FindObjectOfType<GameConttroller>();
		pauseButton = MonoBehaviour.FindObjectOfType<PauseButton>();
		characterControll = MonoBehaviour.FindObjectOfType<CharacterControll>();

		headerText = GameObject.FindGameObjectWithTag("HeaderText");
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.platform == RuntimePlatform.Android)			
		{	
			if(escape){
				if (Input.GetKeyUp(KeyCode.Escape))				
				{	
					if(hideMainMenu){
						HideMainMenu();
					} else {
						if(canExit){
							Application.Quit();
						}
					  }

				}
			} else {
				if (Input.GetKeyUp(KeyCode.Escape)){
					if(canExit){
						Application.Quit();
					}
						PauseGame();
				}
			}
		}
	}

	public void ShowMainMenu(){
		cameraControll.MoveToMenu();
		mainMenu.MenuAtCenter();
		hideMainMenu = true;
		canExit = false;
	}

	public void HideMainMenu(){
		cameraControll.MoveBack();
		mainMenu.MenuOut();
		startButton.Invoke("MakeActive", 1f);
		hideMainMenu = false;
		canExit = true;
	}

	public void StartGame(int levelId){
		cameraControll.MoveBack();
		cameraControll.Invoke("StartGame",1f);
		mainMenu.MenuOut();
		gameController.StartLoadLevel(levelId);
		gameController.Invoke("MoveBackward", 1f);
		pauseButton.Enable();
		backButton.firstStart = true;
		escape = false;
		canExit = false;
	}

	public void PauseGame(){
		pauseButton.Disable();
		cameraControll.MoveToMenu();
		ShowMainMenu();
		gameController.SetPauseGame(true);
		canExit = true;

		MovementController[] movementControllers = MonoBehaviour.FindObjectsOfType<MovementController> ();		
		foreach (MovementController movementController in movementControllers) {	
			movementController.Pause();
		}
	}

	public void ResumeGame(){
		pauseButton.Invoke("Enable",1f);
		mainMenu.MenuOut();
		cameraControll.MoveBack();
		cameraControll.Invoke("StartGame",1f);
		characterControll.Invoke("Resume", 1f);
		canExit = false;
		MovementController[] movementControllers = MonoBehaviour.FindObjectsOfType<MovementController> ();		
		foreach (MovementController movementController in movementControllers) {	
			movementController.Invoke("Resume", 1f);
		}
	}

}

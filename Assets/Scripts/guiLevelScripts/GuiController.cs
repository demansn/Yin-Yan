using UnityEngine;
using System.Collections;

public class GuiController : MonoBehaviour {

	private MainMenu mainMenu;
	private CameraControll cameraControll;
	private BackButton backButton;
	private StartButton startButton;

	private GameObject headerText;

	private bool hideMainMenu = false;
	private bool canExit = true;

	// Use this for initialization
	void Start () {
		mainMenu = MonoBehaviour.FindObjectOfType<MainMenu>();
		cameraControll = MonoBehaviour.FindObjectOfType<CameraControll>();
		backButton = MonoBehaviour.FindObjectOfType<BackButton>();
		startButton = MonoBehaviour.FindObjectOfType<StartButton>();
		headerText = GameObject.FindGameObjectWithTag("HeaderText");
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.platform == RuntimePlatform.Android)			
		{			
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

}

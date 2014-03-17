using UnityEngine;
using System.Collections;

public class Gui : MonoBehaviour {

	public GUIStyle upperText;
	public GUIStyle customButton;

	private bool removeGui;
	private bool moveMenu = false;

	public CharacterControll cc;
	public CameraControll camC;

	private Rect upperTextRect;
	private Rect mainMenuRect;
	private Rect menuBgRect;
	private Rect playButtonRect;
	private Rect levelOneRect;

	public Texture playButton;
	public Texture choseLevelOne;

	public GUIStyle customMenu;

	private int plus;

	// Use this for initialization
	void Start () {
		upperTextRect = new Rect(Screen.width*5/100, Screen.height*5/100, Screen.width*95/100, Screen.height*40/100);
		playButtonRect = new Rect(Screen.width*1.2f, Screen.height*1.45f, Screen.width*40/100, Screen.width*40/100);
		mainMenuRect = new Rect(Screen.width*2, Screen.height/Screen.height, Screen.width*3, Screen.height*2);
		menuBgRect = new Rect(Screen.width*2, Screen.height/Screen.height, Screen.width*3, Screen.height*2);

		removeGui = true;
	}

	void OnGUI(){
		if(removeGui){
			GUI.Label(upperTextRect, "YING YANG", upperText);
			if(GUI.Button(playButtonRect,playButton,customButton)){
				removeGui = false;
				moveMenu = true;
				camC.MoveToMenu();
			}
		}


		if(moveMenu){
			plus = 3;
			mainMenuRect.x = mainMenuRect.x - plus;
		}

		if(mainMenuRect.x < Screen.width/3){
			moveMenu = false;
		}

		GUI.Box(mainMenuRect, "Chose Level", customMenu);
	}

}

using UnityEngine;
using System.Collections;

public class Gui : MonoBehaviour {

	public GUIStyle upperText;
	public GUIStyle customButton;

	private float levelButtonWidth;

	private bool removeGui;
	private bool moveMenu = false;

	public CharacterControll cc;
	public CameraControll camC;

	private Rect upperTextRect;
	private Rect mainMenuRect;
	private Rect menuBgRect;
	private Rect playButtonRect;
	private Rect levelOneRect;
	private Rect levelTwoRect;
	private Rect levelThreeRect;
	private Rect levelFourRect;
	private Rect levelFiveRect;
	private Rect levelSixRect;
	private Rect scrollRect;

	public Texture playButton;
	public Texture chooseLevelOne;
	public Texture chooseLevelTwo;
	public Texture chooseLevelThree;
	public Texture chooseLevelFour;
	public Texture chooseLevelFive;
	public Texture chooseLevelSix;

	public GUIStyle customMenu;

	private int plus;
	public Vector2 scrollPosition = Vector2.zero;


	// Use this for initialization
	void Start () {
		scrollRect = new Rect(Screen.width*2, Screen.height/Screen.height, Screen.width*3, Screen.height*2);
		levelButtonWidth = scrollRect.width*8.5f/100;

		upperTextRect = new Rect(Screen.width*5/100, Screen.height*5/100, Screen.width*95/100, Screen.height*40/100);
		playButtonRect = new Rect(Screen.width*1.2f, Screen.height*1.45f, Screen.width*40/100, Screen.width*40/100);
		mainMenuRect = new Rect(0, Screen.height/Screen.height, Screen.width*3, Screen.height*2);

		levelOneRect = new Rect(scrollRect.width*7/100, scrollRect.height*5/100,levelButtonWidth,levelButtonWidth);
		levelTwoRect = new Rect(scrollRect.width*18/100, scrollRect.height*5/100,levelButtonWidth,levelButtonWidth);
		levelThreeRect = new Rect(scrollRect.width*29/100, scrollRect.height*5/100,levelButtonWidth,levelButtonWidth);
		levelFourRect = new Rect(scrollRect.width*7/100, scrollRect.height*15/100,levelButtonWidth,levelButtonWidth);
		levelFiveRect = new Rect(scrollRect.width*18/100, scrollRect.height*15/100,levelButtonWidth,levelButtonWidth);
		levelSixRect = new Rect(scrollRect.width*29/100, scrollRect.height*15/100,levelButtonWidth,levelButtonWidth);

		removeGui = true;
	}

	void OnGUI(){

		scrollPosition = GUI.BeginScrollView(scrollRect, scrollPosition, new Rect(0, 0, 220, 200));
		GUI.Box(mainMenuRect, "Choose Level", customMenu);
		if(GUI.Button(levelOneRect,chooseLevelOne,customButton)){
		}
		if(GUI.Button(levelTwoRect,chooseLevelTwo,customButton)){
		}
		if(GUI.Button(levelThreeRect,chooseLevelThree,customButton)){
		}
		if(GUI.Button(levelFourRect,chooseLevelFour,customButton)){
		}
		if(GUI.Button(levelFiveRect,chooseLevelFive,customButton)){
		}
		if(GUI.Button(levelSixRect,chooseLevelSix,customButton)){
		}
		GUI.EndScrollView();

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
			scrollRect.x = scrollRect.x - plus;
			Debug.Log(mainMenuRect.x);
		}

		if(scrollRect.x < Screen.width/3){
			moveMenu = false;
		}


	}

}

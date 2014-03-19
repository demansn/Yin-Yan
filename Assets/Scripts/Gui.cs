using UnityEngine;
using System.Collections;

public class Gui : MonoBehaviour {

	public GUIStyle upperText;
	public GUIStyle customButton;

	private float levelButtonWidth;

	private bool removeGui = true;

	public CharacterControll cc;
	public CameraControll camC;
	public MainMenu MM;

	private Rect upperTextRect;
	private Rect playButtonRect;

	public Texture playButton;	

	// Use this for initialization
	void Start () {
		upperTextRect = new Rect(Screen.width*5/100, Screen.height*5/100, Screen.width*95/100, Screen.height*40/100);
		playButtonRect = new Rect(Screen.width*1.2f, Screen.height*1.45f, Screen.width*40/100, Screen.width*40/100);
	}

	void OnGUI(){

		if(removeGui){
			GUI.Label(upperTextRect, "YING YANG", upperText);
			if(GUI.Button(playButtonRect,playButton,customButton)){
				removeGui = false;
				camC.MoveToMenu();
				MM.MenuAtCenter();
			}
		}

	}

}

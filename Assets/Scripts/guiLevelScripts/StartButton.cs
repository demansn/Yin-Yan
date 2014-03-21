using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	public CharacterControll cc;
	public CameraControll camC;
	public MainMenu MM;
	public GameObject header;	

	private void OnMouseUp(){
		
		camC.MoveToMenu();
		MM.MenuAtCenter();
		gameObject.SetActive(false);
		header.SetActive(false);
	
	}

	public void MakeActive(){
		gameObject.SetActive(true);
		header.SetActive(true);
	}

}

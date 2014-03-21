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
		Debug.Log("dsdf");
	}

}

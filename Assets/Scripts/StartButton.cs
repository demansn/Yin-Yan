using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	public CharacterControll cc;
	public CameraControll camC;
	public MainMenu MM;

	public GameObject header;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void OnMouseUp(){
		camC.MoveToMenu();
		MM.MenuAtCenter();
		gameObject.SetActive(false);
		header.SetActive(false);
	}

}

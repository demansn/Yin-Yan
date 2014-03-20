using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	private StartButton SB;
	private MainMenu MM;
	private CameraControll CamControll;

	private Vector3 startScale;

	// Use this for initialization
	void Start () {
		SB = MonoBehaviour.FindObjectOfType<StartButton>();
		MM = MonoBehaviour.FindObjectOfType<MainMenu>();
		CamControll = MonoBehaviour.FindObjectOfType<CameraControll>();

		startScale = transform.localScale;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnMouseDown(){
		transform.localScale = new Vector3(0.18f,0.1f,0.12f);
	}

	private void OnMouseUp(){
		transform.localScale = startScale;
		SB.MakeActive();
		MM.MenuOut();
		CamControll.MoveBack();
	}

}

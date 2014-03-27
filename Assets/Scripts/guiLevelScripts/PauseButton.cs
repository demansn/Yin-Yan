using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {

	private GuiController guiController;

	// Use this for initialization
	void Start () {
		gameObject.SetActive(false);
		guiController = MonoBehaviour.FindObjectOfType<GuiController>();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void Enable(){
		gameObject.SetActive(true);
	}

	public void Disable(){
		gameObject.SetActive(false);
	}

	private void OnMouseDown(){

	}

	private void OnMouseUp(){
		guiController.PauseGame();
	}

}

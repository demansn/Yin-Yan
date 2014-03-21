using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	private GameObject header;
	private GuiController guiController;
	// Use this for initialization
	void Start () {
		guiController = MonoBehaviour.FindObjectOfType<GuiController>();
		header = GameObject.FindGameObjectWithTag("HeaderText");
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void OnMouseUp(){

		guiController.ShowMainMenu();
		gameObject.SetActive(false);
		header.SetActive(false);

	}

	public void MakeActive(){
		gameObject.SetActive(true);
		header.SetActive(true);
	}

}

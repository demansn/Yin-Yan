using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	private GuiController guiController;

	private Vector3 startScale;
	// Use this for initialization
	void Start () {
		guiController = MonoBehaviour.FindObjectOfType<GuiController>();
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
		guiController.HideMainMenu();
	}
}

using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	private bool moveMenu = false;
	private bool moveBack = false;
	private Vector3 oldPosition;
	private Vector3 menuTransform;

	void Start () {
		oldPosition = transform.position;
	}	

	void Update () {

		if(moveMenu){
			menuTransform = new Vector3(0.1f,0,0);
			transform.position -= menuTransform;
		}

		if(transform.position.x < 5.6f){
			moveMenu = false;
		}

		if(moveBack){
			menuTransform = new Vector3(0.1f,0,0);
			transform.position += menuTransform;
		}

		if(transform.position.x > oldPosition.x){
			moveBack = false;
			transform.position = oldPosition;
		}

	}

	public void MenuAtCenter(){
		moveMenu = true;
	}

	public void MenuOut(){
		moveBack = true;
	}

}

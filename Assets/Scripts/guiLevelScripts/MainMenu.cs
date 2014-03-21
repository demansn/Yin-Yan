using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	private bool moveMenu = false;
	private bool moveBack = false;
	private Vector3 oldPosition;
	private Vector3 menuTransform;
	private Vector3 moveSpeed;
	public GameConttroller gameController;

	void Start () {
		oldPosition = transform.position;
		moveSpeed = new Vector3(0.1f,0,0);

	}	

	void Update () {

		if(moveMenu){
		
			transform.position -= moveSpeed;

			if(transform.position.x < 5.6f){
				moveMenu = false;
			}
		}


		if(moveBack){
	
			transform.position += moveSpeed;

			if(transform.position.x > oldPosition.x){
				moveBack = false;
				transform.position = oldPosition;

				OnHid();
			}
		}


	}

	public void MenuAtCenter(){
		moveMenu = true;
	}

	public void MenuOut(){
		moveBack = true;
	}

	void OnHid(){
		gameController.MoveBackward();
	}

}

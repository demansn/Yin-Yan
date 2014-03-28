using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	private bool moveMenu = false;
	private bool moveBack = false;
	private Vector3 oldPosition;
	private Vector3 menuTransform;
	private Vector3 moveSpeed;
	private Vector3 moveToCamera;
	private CameraControll cameraControll;
	public GameConttroller gameController;

	void Start () {
		cameraControll = MonoBehaviour.FindObjectOfType<CameraControll>();
		oldPosition = transform.position;
		moveSpeed = new Vector3(0.15f,0,0);

	}	

	void Update () {
		moveToCamera = new Vector3(transform.position.x,cameraControll.transform.position.y,transform.position.z);
		transform.position = moveToCamera;
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
			//gameController.MoveBackward();		
	}

}

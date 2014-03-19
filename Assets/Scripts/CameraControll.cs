using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
	private Vector3 oldPosition;
	private Vector3 moveCamera;

	public bool isMove = false;
	private bool startGame = true;
	private bool callMenu = false;
	private bool moveBack = false;

	void Start () {
		offset = transform.position;
		oldPosition = transform.position;
	}	

	void LateUpdate () {

		if(startGame && isMove){
				
			offset.y = player.transform.position.y + 3;
			transform.position = offset;
		}

		if(callMenu){
			moveCamera = new Vector3(0.1f, 0,0);
			transform.position +=  moveCamera;
		}

		if(transform.position.x > Screen.width/100){
			callMenu = false;
		}

		if(moveBack){
			moveCamera = new Vector3(0.1f, 0,0);
			transform.position -=  moveCamera;
		}

		if(transform.position.x < oldPosition.x){
			moveBack = false;
		}
	} 

	public void ResetPosition(){
		offset.y = 0;
		transform.position = offset;
	}

	public void MoveToMenu(){
		callMenu = true;
	}

	public void MoveBack(){
		moveBack = true;
	}

	public void StartGame(){
		startGame = true;
	}

}

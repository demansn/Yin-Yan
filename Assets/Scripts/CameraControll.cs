using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
	private Vector3 oldPosition;

	private Vector3 moveCamera;

	private bool startGame = false;
	private bool callMenu = false;
	private bool moveBack = false;



	void Start () {
		offset = transform.position;
		oldPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(startGame){
			offset.y = player.transform.position.y + 3f;
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

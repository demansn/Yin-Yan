using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

	private Vector3 moveCamera;
	public bool isMove = false;
	private bool startGame = true;
	private bool callMenu = false;
	private float vel;

	void Start () {
		offset = transform.position;
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

	} 

	public void ResetPosition(){
		offset.y = 0;
		transform.position = offset;
	}

	public void MoveToMenu(){
		callMenu = true;
	}
	public void StartGame(){
		startGame = false;
	}

}

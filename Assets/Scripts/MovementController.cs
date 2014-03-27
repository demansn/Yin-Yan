using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{


	public float moveSpeed = 0;
	public float rotateSpeed = 0;
	public bool isLeftRotate = false;
	public bool isUpMove = false;
	public bool isRotate = false;
	public bool isPause = false;

	private float backwardMoveTime;
	private Vector3 startPosition;
	private Vector3 backwardDeltaMove;
	private bool isBackwardMove = false;

		
	void Start (){

		startPosition = transform.position;

	}

	public void BackwardMove (float time){

		isBackwardMove = true;
		backwardMoveTime = time;
		float distance = Vector3.Distance (transform.position, startPosition);
		backwardDeltaMove = new Vector3 (0, distance / (backwardMoveTime / 0.02f), 0);
		
	}

	
	void FixedUpdate(){
		
		if(!isPause && isBackwardMove){	
			transform.position += backwardDeltaMove;
		}
		
	}	

	void Update (){
		if (!isPause) {
			if (isBackwardMove) {
				
				if (transform.localPosition.y >= startPosition.y) {
						isBackwardMove = false;
						transform.localPosition = startPosition;
						Debug.Log(transform.position.y + " >= " + startPosition.y);
				}

			} else {

				Vector3 deltaPosition;

				if (isUpMove) {
					deltaPosition = Vector3.up * moveSpeed;
				} else {
					deltaPosition = Vector3.down * moveSpeed;
				}

				transform.position += deltaPosition * Time.deltaTime;
			
				if(isRotate){

					Vector3 deltaRotation;

					if(isLeftRotate){
						deltaRotation = Vector3.forward * rotateSpeed;
					} else {
						deltaRotation = Vector3.back * rotateSpeed;
					}

					transform.Rotate(deltaRotation);
				}
			}
		}
	}

	public void Resume(){
		isPause = false;
	}

	public void Pause(){
		isPause = true;
	}


}

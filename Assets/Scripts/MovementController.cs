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
	private Quaternion startRotation;
	private Vector3 backwardDeltaMove;
	private Vector3 backwardDeltaRotation;
	private bool isBackwardMove = false;
	public Vector3 angleCounter = Vector3.zero;

		
	void Start (){

		startPosition = transform.position;
		startRotation = transform.rotation;

	}

	public void BackwardMove (float time){

		isBackwardMove = true;
		backwardMoveTime = time;

		float distance = Vector3.Distance (transform.position, startPosition);
		
	
		backwardDeltaRotation = new  Vector3 (0, 0, angleCounter.z   / (backwardMoveTime  / 0.02f));
		backwardDeltaMove = new Vector3 (0, distance / (backwardMoveTime / 0.02f), 0);
		
		isBackwardMove = true;
		
	}

	
	void FixedUpdate(){
		
		if(!isPause && isBackwardMove){	
			transform.position += backwardDeltaMove;
			transform.Rotate(backwardDeltaRotation);

			if (transform.position.y >= startPosition.y) {
				isBackwardMove = false;
				transform.localPosition = startPosition;
				transform.rotation = startRotation;
				angleCounter = Vector3.zero;
			}
		}
		
	}	

	void Update (){
		if (!isPause) {
			if (!isBackwardMove) {

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
						angleCounter += Vector3.forward * rotateSpeed;
					} else {
						deltaRotation = Vector3.back * rotateSpeed;
						angleCounter += Vector3.back * rotateSpeed;
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

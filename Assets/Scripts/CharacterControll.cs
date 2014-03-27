﻿using UnityEngine;
using System.Collections;

public class CharacterControll : MonoBehaviour

{

		public bool isGameState = false;	
		public bool isPause = false;
		public bool isUpMove = false;
		public bool isAccelerated = false;
		public GameObject redCircle;
		public GameObject blueCircle;
		public float moveSpeed = 0;
		public float acceleration = 0;
		public float rotateSpeed = 3.5f;
		private float backwardMoveTime = 0;
		public Vector3 startPosition;
		private float currentRotation;
		private Vector3 deltaPosition;
		private Vector3 backwardDeltaMove;
		public Vector3 deltaRotation;
		private Vector3 speedRotation;
		private bool isBackwardMove = false;

		void Start (){

			

			speedRotation = new Vector3 (0, 0, rotateSpeed);			
	
			if (isUpMove) {
					deltaPosition = Vector3.up * moveSpeed;
			} else {
					deltaPosition = Vector3.down * moveSpeed;
			}	
		}

		public void ResetPosition(){

			transform.position = new Vector3(transform.position.x, startPosition.y, transform.position.z);
		
		}
	
		public void BackwardMove (float time)
		{
			backwardMoveTime = time;
			currentRotation = transform.eulerAngles.z;

			float angle = transform.eulerAngles.z + 180;
		
			if (angle < 360) {
				angle = 360 - (angle - 360);
			} else if(angle > 360){
				angle = 360 - angle;
			}
		
			angle = angle - 180;	
		
			

			float ds = Vector3.Distance (transform.position, startPosition);
			Debug.Log("DS = " + ds);
			float distance = (startPosition.y - transform.position.y);
			Debug.Log("DS = " + distance);
			backwardDeltaMove = new Vector3 (0, 0.2f, 0);
			deltaRotation = new  Vector3 (0, 0, currentRotation/distance*backwardDeltaMove.y);
			
			isBackwardMove = true;
			redCircle.collider.enabled = false;
			blueCircle.collider.enabled = false;
		}

	void OnMovedToStartPosition(){

	}


	void FixedUpdate(){

		if(!isPause && isBackwardMove){

			transform.Rotate(deltaRotation);
			transform.position -= backwardDeltaMove;

			if (transform.position.y <= startPosition.y) {

				isBackwardMove = false;	

				redCircle.collider.enabled = true;
				blueCircle.collider.enabled = true;

				redCircle.SetActive (true);
				blueCircle.SetActive (true);

				OnMovedToStartPosition();
			} 
		}

	}

	void Update () {
			
		if(isGameState){
			if (!isPause && !isBackwardMove) {										
		
				if (Input.touchCount > 0) {
					Touch touch = Input.GetTouch(0);
		
					Vector3 v = Camera.main.ScreenToViewportPoint(new Vector3 (touch.position.x,touch.position.y, 0) );					 

					if(v.x > 0.5f){
						transform.Rotate (speedRotation);
					} else {
						transform.Rotate (-speedRotation);		
					}
				} else {
					if (Input.GetMouseButton (0)) {
						transform.Rotate (speedRotation);
					}
					if (Input.GetMouseButton (1)) {
						transform.Rotate (-speedRotation);		
					}
				}
	
				if (isUpMove) {
					if(isAccelerated){
						transform.position += Vector3.up * (moveSpeed + acceleration) * Time.deltaTime;
					} else {
						transform.position += Vector3.up * moveSpeed * Time.deltaTime;
					}										
				} else {
						transform.position += Vector3.down * moveSpeed * Time.deltaTime;
				}
			}			

		} else {
			transform.Rotate (speedRotation);
		}		

	}

	public void Resume ()
	{
		isPause = false;
	}

}

	



using UnityEngine;
using System.Collections;

public class CharacterControll : MonoBehaviour
{		
		public GUIText debugText;
		public bool isPause = false;
		public bool isUpMove = false;
		public GameObject redCircle;
		public GameObject blueCircle;
		public float moveSpeed = 0;
		public float rotateSpeed = 3.5f;

		private float backwardMoveTime = 0;
		private Vector3 startPosition;
		private Vector3 deltaPosition;
		private Vector3 backwardDeltaMove;
		private Vector3 deltaRotation;
		private Vector3 speedRotation;
		private bool isBackwardMove = false;

		void Start ()
		{
				startPosition = transform.position;
				speedRotation = new Vector3 (0, 0, rotateSpeed);			
		
				if (isUpMove) {
						deltaPosition = Vector3.up * moveSpeed;
				} else {
						deltaPosition = Vector3.down * moveSpeed;
				}
	
		}
	
		public void BackwardMove (float time)
		{
				backwardMoveTime = time;

		float angle = transform.eulerAngles.z + 180;
		
		if (angle < 360) {
			angle = 360 - (angle - 360);
		} else if(angle > 360){
			angle = 360 - angle;
		}
		
		angle = angle - 180;	
		
				deltaRotation = new  Vector3 (0, 0, angle   / (time  / 0.02f));

			float distance = Vector3.Distance (transform.position, startPosition);
				backwardDeltaMove = new Vector3 (0, distance / (backwardMoveTime / 0.02f), 0);
		
						
				isBackwardMove = true;
				redCircle.collider.enabled = false;
				blueCircle.collider.enabled = false;
		}



	void FixedUpdate(){

		if(!isPause && isBackwardMove){
			transform.Rotate( deltaRotation);
			transform.position -= backwardDeltaMove;
		}

	}

		void Update ()
		{
				
				if (!isPause) {
						if (isBackwardMove) {
	
								if (transform.position.y <= startPosition.y) {

										isBackwardMove = false;	

										redCircle.collider.enabled = true;
										blueCircle.collider.enabled = true;
				
										redCircle.SetActive (true);
										blueCircle.SetActive (true);
								} 
				
						} else {

			
								
		
				if (Input.touchCount > 0) {
					Touch touch = Input.GetTouch(0);
		
					Vector3 v = Camera.main.ScreenToViewportPoint(new Vector3 (touch.position.x,touch.position.y, 0) );
					 

					if(v.x > 0.5f){
						transform.Rotate (speedRotation);
						debugText.text = "right";
					} else {
						transform.Rotate (-speedRotation);		
						debugText.text = "left";
					}
				} else {
					debugText.text = "button";
					if (Input.GetMouseButton (0)) {
						transform.Rotate (speedRotation);
					}
					if (Input.GetMouseButton (1)) {
						transform.Rotate (-speedRotation);		
					}
				}
				
				if (isUpMove) {
										transform.position += Vector3.up * moveSpeed * Time.deltaTime;
								} else {
										transform.position += Vector3.down * moveSpeed * Time.deltaTime;
								}
						}
				}
		
		}


		

}




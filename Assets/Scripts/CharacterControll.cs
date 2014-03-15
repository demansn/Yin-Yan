using UnityEngine;
using System.Collections;

public class CharacterControll : MonoBehaviour
{		
		public bool isPause = false;
		public bool isUpMove = false;
		public GameObject redCircle;
		public GameObject blueCircle;
		public float moveSpeed = 0;
		public float rotateSpeed = 3.5f;
		private float backwardMoveSpeed = 0;
		private float backwardMoveTime = 0;
		private Vector3 startPosition;
		private Vector3 deltaPosition;
		private Vector3 deltaRotation;
		private Quaternion startRotation;
		private bool isBackwardMove = false;
	
		void Start ()
		{
				startPosition = transform.position;
				deltaRotation = new Vector3 (0, 0, rotateSpeed);
				startRotation = Quaternion.Euler (0, 180, -720);
		
				if (isUpMove) {
						deltaPosition = Vector3.up * moveSpeed;
				} else {
						deltaPosition = Vector3.down * moveSpeed;
				}
		}
	
		public void BackwardMove (float time)
		{

				backwardMoveTime = time;
						
				isBackwardMove = true;
				redCircle.collider.enabled = false;
				blueCircle.collider.enabled = false;
		}
	
		// Update is called once per frame
		void Update ()
		{
				Debug.Log (transform.rotation.ToString ());
				if (!isPause) {
						if (isBackwardMove) {

								transform.position = Vector3.Lerp (transform.position, startPosition, Time.deltaTime * backwardMoveTime);
								transform.rotation = Quaternion.Lerp (transform.rotation, startRotation, Time.deltaTime * backwardMoveTime);
								
								if (transform.position.y <= startPosition.y + 0.5) {
										isBackwardMove = false;						
										redCircle.collider.enabled = true;
										blueCircle.collider.enabled = true;
				
										redCircle.SetActive (true);
										blueCircle.SetActive (true);
								} 
				
						} else {

			
								if (Input.GetMouseButton (0)) {
										transform.Rotate (deltaRotation);
								}
								if (Input.GetMouseButton (1)) {
										transform.Rotate (-deltaRotation);		
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




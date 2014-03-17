using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{

		// Use this for initialization
		public float moveSpeed = 0;
		public bool isUpMove = false;
		private float backwardMoveSpeed = 0;
		private float backwardMoveTime;
		private Vector3 startPosition;
		private Vector3 deltaPosition;
		private Vector3 backwardDeltaMove;
		private bool isBackwardMove = false;
		public bool isPause = false;

		
		void Start ()
		{
				startPosition = transform.position;

				if (isUpMove) {
						deltaPosition = Vector3.up * moveSpeed;
				} else {
						deltaPosition = Vector3.down * moveSpeed;
				}
		}

		public void BackwardMove (float time)
		{
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

		void Update ()
		{
				if (!isPause) {
						if (isBackwardMove) {
							
								if (transform.position.y >= startPosition.y) {
										isBackwardMove = false;
								}

						} else {
								if (isUpMove) {
										transform.position += Vector3.up * moveSpeed * Time.deltaTime;
								} else {
										transform.position += Vector3.down * moveSpeed * Time.deltaTime;
								}
						}
				}
	
		}
}

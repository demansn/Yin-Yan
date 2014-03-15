using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{

		// Use this for initialization
		public float moveSpeed = 0;
		public bool isUpMove = false;
		private float backwardMoveSpeed = 0;
		private Vector3 startPosition;
		private Vector3 deltaPosition;
		private bool isBackwardMove = false;
		private float backwardMoveTime;
		
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
		}
	
		// Update is called once per frame
		void Update ()
		{

				if (isBackwardMove) {

						float newPosition = Mathf.MoveTowards (transform.position.y, startPosition.y, backwardMoveTime * Time.deltaTime);

						//float newPosition = Mathf.SmoothDamp (transform.position.y, startPosition.y, ref backwardMoveTime, Time.deltaTime);
						if (transform.position.y == startPosition.y) {
								isBackwardMove = false;
						} else {
								transform.position = new Vector3 (transform.position.x, newPosition, transform.position.z);
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

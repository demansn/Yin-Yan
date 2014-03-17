using UnityEngine;
using System.Collections;

public class ActiveBlockController : MonoBehaviour {

	public bool isMoveDown = false;
	public float moveDownSpeed = 0;

	private Vector3 deltaPosition;
	private Vector3 startPosition;
	private Vector3 deltaBackwardPosition;
	private float backwardMoveTime = 0;

	private bool isActive = false;
	private bool isBackwardMove = false;

	void Start () {
		startPosition = transform.position;
		deltaPosition = new Vector3 (0, -moveDownSpeed, 0);
	}

	public void StartAction(){
		isActive = true;
		Debug.Log ("start action");
	}

	public void MoveBackward(float time){

		float dy = transform.position.y - startPosition.y / time; 
		backwardMoveTime = time;
		deltaBackwardPosition = Vector3.up * dy;
	}
	

	void Update () {

		if (isBackwardMove) {
			//float newPosition = Mathf.SmoothDamp(transform.position.y, startPosition.y, ref backwardMoveTime, Time.deltaTime);
			float newPosition =    Mathf.MoveTowards (transform.position.y, startPosition.y, backwardMoveTime * Time.deltaTime );
				transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);

			}

				if (isActive) {
						transform.position += deltaPosition * Time.deltaTime;
				}
		}
}

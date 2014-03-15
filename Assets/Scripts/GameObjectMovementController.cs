using UnityEngine;
using System.Collections;

public class GameObjectMovementController : MonoBehaviour {

	public bool freezeX = false;
	public bool freezeY = false;
	public bool freezeZ = false;
	public GameObject player;
	private Vector3 offset;

	void Start () {
		offset = transform.position;
	}

	void LateUpdate () {

		Vector3 newPosition = player.transform.position + offset;

		if (freezeX) {
			newPosition.x = offset.x;
		}
		
		if (freezeY) {
			newPosition.y = offset.y;			
		}
		
		if (freezeZ) {
			newPosition.z = offset.z;
		}

		transform.position =   newPosition;
	}
}

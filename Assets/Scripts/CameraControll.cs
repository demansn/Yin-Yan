using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

	void Start () {
		offset = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		offset.y = player.transform.position.y + 3f;
		transform.position = offset;
	}
}

using UnityEngine;
using System.Collections;

public class BoundaryController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {	

		if (other.tag == "ActiveBlock") {
			ActiveBlockController controller = other.gameObject.GetComponent<ActiveBlockController>();
			controller.StartAction();
		}
	}

	void OnTriggerStay (Collider other) {
	//	Debug.Log ("Boundary.OnTriggerStay");
	}

	void OnTriggerExit (Collider other) {
		Debug.Log ("Boundary.OnTriggerExit");
	}
}

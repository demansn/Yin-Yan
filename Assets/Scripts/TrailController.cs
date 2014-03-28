using UnityEngine;
using System.Collections;

public class TrailController : MonoBehaviour {
	
	private GameObject targetObject;
	private Vector3 previousPosition;
	private Quaternion previousRotation;
	private Vector3 previusScale;
	private int stepCounter = 0;

	public void SetProperty(GameObject target, float alpha){
		targetObject = target;
		renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, alpha);
		previousPosition = new Vector3(targetObject.transform.position.x, targetObject.transform.position.y, transform.position.z);
		previousRotation = targetObject.transform.rotation;
		previusScale = targetObject.transform.localScale;
	}

	void LateUpdate () {

		transform.position = previousPosition;
		transform.rotation = previousRotation;
		transform.localScale = previusScale;
		previousPosition = new Vector3(targetObject.transform.position.x, targetObject.transform.position.y, transform.position.z);
		previousRotation = targetObject.transform.rotation;
		previusScale = targetObject.transform.localScale;
		
	}
}

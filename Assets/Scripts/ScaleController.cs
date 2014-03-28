using UnityEngine;
using System.Collections;

public class ScaleController : MonoBehaviour {

	private bool makeBigger;

	private float maximum = 3f;
	private float minimum = 1f;
	private float step = 0.5f;

	private Vector3 scaling;
	private Vector3 addition;
	private Vector3 startScale;


	// Use this for initialization
	void Start () {

		startScale = transform.localScale;
		Debug.Log(transform.localScale);
		scaling = new Vector3(0.1f,0.5f,1);
		addition = new Vector3(0.01f,0.008f,0);
	}
	
	// Update is called once per frame
	void Update () {
		if(makeBigger){
			transform.localScale += addition;
		} else {
			transform.localScale -= addition;
		}

		if(transform.localScale.x >= startScale.x + scaling.x){
			makeBigger = false;
		}else if(transform.localScale.x <= startScale.x - scaling.x){
			makeBigger = true;
		}


	}
}

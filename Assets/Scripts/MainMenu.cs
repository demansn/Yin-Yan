using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	private bool smoothTransform = false;
	private Vector3 transformToCenter;
	private Vector3 stopTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(smoothTransform){
			transformToCenter = new Vector3(0.01f,0,0);

			transform.position -= transformToCenter;
		}
		stopTransform = new Vector3(-10, 0,0);
		if(transform.position.x < -10){
			smoothTransform = false;
		}
	}

	public void MenuAtCenter(){
		smoothTransform = true;
	}

}

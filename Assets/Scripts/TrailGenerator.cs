using UnityEngine;
using System.Collections;

public class TrailGenerator : MonoBehaviour {

	public GameObject trailPrefab;
	public float startAlpha = 0.1f;
	public int trailLength = 10;

	void Start () {

		GameObject trail;
		GameObject target = gameObject;
		Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
		float deltaAlpha = startAlpha / trailLength;
		float currentAlpha = startAlpha;

		for(int i = 0; i < trailLength; i += 1){	

			trail = (GameObject)Instantiate(trailPrefab, position, transform.rotation);
			trail.transform.localScale = gameObject.transform.localScale;
			trail.GetComponent<TrailController>().SetProperty(target, currentAlpha);

			position.z =+ 1;
			currentAlpha -= deltaAlpha;
			target = trail;

			if(currentAlpha < 0){
				break;
			}
		}
	
	}
}
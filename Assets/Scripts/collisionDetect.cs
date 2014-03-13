using UnityEngine;
using System.Collections;

public class collisionDetect : MonoBehaviour {

	public Collision collision;
	public GameObject circle;

	public GameObject mass;

	public CharacterControll cc;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnCollisionEnter(Collision collision){
		foreach (ContactPoint contact in collision.contacts) {
			Debug.Log(contact.normal);

			Instantiate(mass, contact.point, Quaternion.FromToRotation(Vector3.up, contact.point));

		}

//		cc.Restart();
	}

	public void BeginAgain(){

	}

}

using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	private LevelOneScript[] ld;
	private int unlock;

	// Use this for initialization
	void Start () {
		ld = MonoBehaviour.FindObjectsOfType<LevelOneScript>();

	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i<3; i++){
			UnlockButton(i);
		}
	}

	public void UnlockButton(int i){
		ld[ld.Length - i - 1].SetActive();
		if(unlock != null){
			ld[unlock].Blink();
		}

		unlock = ld.Length - i - 1;
	}
}

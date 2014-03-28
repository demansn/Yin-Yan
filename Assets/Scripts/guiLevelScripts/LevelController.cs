using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	private LevelOneScript[] ld;
	private int unlock;

	// Use this for initialization
	void Start () {
		ld = MonoBehaviour.FindObjectsOfType<LevelOneScript>();

		for(int i =1; i<7; i++){
			UnlockButton(i);
		}

	}
	
	// Update is called once per frame
	void Update () {

		
	}

	public void UnlockButton(int i){

		if(unlock != null){
			ld[unlock].Blink();
		}

		for(int j = 0; j < ld.Length; j++){
			if(ld[j].id == i){
				ld[j].SetActive();
				unlock = j;
			}
		}



	}
}

﻿using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

	private Vector3 moveCamera;

	private bool startGame = true;
	private bool callMenu = false;

	void Start () {
		offset = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(startGame){
			offset.y = player.transform.position.y + 3f;
			transform.position = offset;
		}
		if(callMenu){
			moveCamera = new Vector3(0.1f, 0,0);
			transform.position +=  moveCamera;
		}

		if(transform.position.x > Screen.width/100){
			callMenu = false;
		}

	}

	public void MoveToMenu(){
		callMenu = true;
	}
	public void StartGame(){
		startGame = false;
	}

}

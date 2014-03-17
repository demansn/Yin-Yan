﻿using UnityEngine;
using System.Collections;

public class CharacterControll : MonoBehaviour {

	private Vector3 moveDirection ;
	private Vector3 moveBack;
	private Vector3 rotation;

	private Vector3 startRot;
	private Vector3 startPos;
	
	private float vertical = 0;
	private float rotate = 0;

	private bool restart = true;
	private bool stopSpeed = true;
	private bool startGame = false;

	public GameObject redCircle;
	public GameObject blueCircle;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
		startGame = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!startGame){
			rotate = 3f;
			rotation = new Vector3(0,0,rotate);
			transform.Rotate(-rotation);
		} else {
			if(restart){
				vertical = 0.05f;
				rotate = 3.8f;
				moveDirection = new Vector3(0, vertical, 0);
				rotation = new Vector3(0,0,rotate);

				transform.position += moveDirection;

				if(Input.GetMouseButton(0)){
					transform.Rotate(rotation);
				}
				if(Input.GetMouseButton(1)){
					transform.Rotate(-rotation);		
				}
			} else {
				if(transform.position.y > startPos.y){
					moveBack = new Vector3(0, vertical*5, 0);				
					transform.position -= moveBack;
					transform.Rotate(rotation * 2);
					redCircle.collider.enabled = false;
					blueCircle.collider.enabled = false;
				} else {
					restart = true;	
					redCircle.collider.enabled = true;
					blueCircle.collider.enabled = true;
					stopSpeed = true;
					redCircle.SetActive(true);
					blueCircle.SetActive(true);
				}

			}
		}
	}


	public void Restart(){
		restart = false;
	}
	public void StopGame(){
		stopSpeed = false;
	}

	public void StartGame(){
		startGame = true;
	}

}
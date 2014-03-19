using UnityEngine;
using System.Collections;

public class LevelOneScript : MonoBehaviour {
	
	private Vector3 startScale;
	private Vector3 maxScale;
	private Vector3 minScale;
	private bool isActive = false;
	private bool blink = false;
	private bool makeBigger = true;
	public int id;

	private MainMenu MM;
	private CameraControll CamControll;

	// Use this for initialization
	void Start () {
		startScale = transform.localScale;

		MM = MonoBehaviour.FindObjectOfType<MainMenu>();
		CamControll = MonoBehaviour.FindObjectOfType<CameraControll>();

	}
	
	// Update is called once per frame
	void Update () {
		if(isActive){
			renderer.material.color = new Color(2f,2f,2f);
		}
		if(blink){
			maxScale = new Vector3(0.18f,0,0.18f);
			minScale = new Vector3(0.12f,0,0.12f);

			if(makeBigger){
				transform.localScale += new Vector3(0.003f,0,0.003f);
			} else {
				transform.localScale -= new Vector3(0.003f,0,0.003f);
			}

			if(transform.localScale.x > maxScale.x){
				makeBigger = false;
			} else if(transform.localScale.x < minScale.x){
				makeBigger = true;
			}
		}


	}

	private void OnMouseDown(){
		if(isActive){
			transform.localScale = new Vector3(0.18f,0.1f,0.11f);

				blink = false;
			
		}
	}
	private void OnMouseUp(){
		if(isActive){
			transform.localScale = startScale;
			MM.MenuOut();
			CamControll.MoveBack();
		}
	}

	public void SetActive(){
		isActive = true;
		blink = true;
	}

	public void Blink(){
		blink = false;
	}

}

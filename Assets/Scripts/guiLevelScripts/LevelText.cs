using UnityEngine;
using System.Collections;

public class LevelText : MonoBehaviour {
	
	private Color colorAlpha;
	private string levelText;

	public GUIStyle customText;

	private bool beginLerp = false;
	private bool endLerp = false;
	// Use this for initialization
	void Start () {
		colorAlpha.a = 0;
		colorAlpha = new Color(1,1,1,colorAlpha.a);
	}

	// Update is called once per frame
	void OnGUI () {

		if(beginLerp){
			colorAlpha.a = colorAlpha.a + 0.005f;
		}
		if(endLerp){
			colorAlpha.a = colorAlpha.a - 0.005f;
		}
		if(colorAlpha.a >= 1){
			beginLerp = false;
			Invoke("WaitToHide",5f);
		} else if(colorAlpha.a <= 0){
			endLerp = false;
		}



		GUI.color = colorAlpha;
		customText.fontSize = Screen.currentResolution.width *5 / 100;
		GUI.Label(new Rect(0,Screen.currentResolution.height*35/100,Screen.currentResolution.width,50), levelText, customText);	
	}

	public void PutText(string text){
		levelText = text;
		beginLerp = true;
	}

	private void WaitToHide(){
		endLerp = true;
	}

}

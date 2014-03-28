using UnityEngine;
using System.Collections;

public class LevelText : MonoBehaviour {

	private GUIText testText;
	private Color colorAlpha;
	private string levelText;

	private bool beginLerp = false;
	private bool endLerp = false;
	// Use this for initialization
	void Start () {
		colorAlpha.a = 0;
		colorAlpha = new Color(1,1,1,colorAlpha.a);
		PutText("LOWARA");
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
		GUI.Label(new Rect(Screen.currentResolution.width*30/100,Screen.currentResolution.height*30/100,Screen.currentResolution.width*40/100,Screen.currentResolution.width*20/100), levelText);	
	}

	public void PutText(string text){
		levelText = text;
		beginLerp = true;
	}

	private void WaitToHide(){
		endLerp = true;
	}

}

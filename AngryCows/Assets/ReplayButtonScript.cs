using UnityEngine;
using System.Collections;

public class ReplayButtonScript : MonoBehaviour {
	
	public GUITexture ReplayButton;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	bool HitTest = ReplayButton.HitTest(Input.mousePosition);
		if (HitTest)
		{
		Application.LoadLevel(0); 	
		}
	}
}

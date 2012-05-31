using UnityEngine;
using System.Collections;

public class KingPigScript : MonoBehaviour {
	
	public float kingPigHealth = 10000;
	private float subtract;  
	public GUIText kingHealthGUI;
	public GUITexture youWin;
	public GUITexture replayButton; 
	
	// Use this for initialization
	void Start () {
		 
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		kingPigHealth -= subtract;
		int iValue = (int)kingPigHealth; 
		if (iValue <= 0)
		{
			iValue = 0; 
			this.gameObject.SetActiveRecursively(false); 
			youWin.gameObject.active = true;
			replayButton.gameObject.active = true; 
		}
		kingHealthGUI.guiText.text = iValue.ToString(); 
		
		subtract = 0;
		
	}
	public void OnTriggerEnter (Collider col)
	{
		if (col.transform.CompareTag("Bird"))
		{
			subtract = 500F + col.rigidbody.velocity.magnitude * 10;	
		}
		else
		{
			subtract = 20;	
		}
	}
}

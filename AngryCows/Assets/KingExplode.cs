using UnityEngine;
using System.Collections;

public class KingExplode : MonoBehaviour {
	
	public GameObject Bird;
	public GUIText kinghealth; 
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnTriggerEnter (Collider col)
	{
		
		if (col.transform.CompareTag("KingPig"))
		{
			
				
				int pighealth = int.Parse(kinghealth.guiText.text);
				pighealth -= 500;
				kinghealth.guiText.text = pighealth.ToString(); 
				
			
		}
		
	}
}

using UnityEngine;
using System.Collections;

public class PigScript : MonoBehaviour {
	
	private Vector3 startPos; 
	private float startDistance; 
	public float deathDistance = 5.0F; 
	public int knockScore = 2500; 
	public GUIText LivesGUIText; 
	
	// Use this for initialization
	void Start () {
	startPos = this.transform.position; 
	}
	
	// Update is called once per frame
	void Update () {
	startDistance = Vector3.Distance(this.transform.position, startPos);
	if (startDistance >= deathDistance)
		{
			int score; 
			this.gameObject.SetActiveRecursively(false); 
			score = int.Parse(LivesGUIText.guiText.text.ToString()); 
			score += knockScore;
			LivesGUIText.guiText.text = score.ToString(); 
			score = 0; 
		}
	
	}
	
}

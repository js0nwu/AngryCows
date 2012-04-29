using UnityEngine;
using System.Collections;

public class PigScript : MonoBehaviour {
	
	private Vector3 startPos; 
	private float startDistance; 
	public float deathDistance = 5.0F; 
	private int score; 
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
			this.gameObject.SetActiveRecursively(false); 
			score = int.Parse(LivesGUIText.guiText.text.ToString()); 
			score += 2500;
			LivesGUIText.guiText.text = score.ToString(); 
		}
	
	}
	public void OnTriggerEnter(Collider col)
	{
		if (col.transform.CompareTag("Bird"))
		{
			this.gameObject.SetActiveRecursively(false); 
			score = int.Parse(LivesGUIText.guiText.text.ToString()); 
			score += 5000;
			LivesGUIText.guiText.text = score.ToString(); 
		}
	}
}

using UnityEngine;
using System.Collections;

public class PigAimScript : MonoBehaviour {
	public GameObject BirdPlayer;
	public GameObject projectileTrajectory; 
	public GameObject Egg;
	public int rateOfFire = 1;
	
	// Use this for initialization
	void Start () {
		StartCoroutine(shootTimer());
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.LookAt(BirdPlayer.transform.position); 
	}
	void shootEgg()
	{
		if (BirdPlayer.transform.position.z > 0)
		{
			Transform eggInstance;
			eggInstance = (Transform)Instantiate(Egg.transform, projectileTrajectory.transform.position, Egg.transform.rotation);
			eggInstance.rigidbody.velocity = 69 * projectileTrajectory.transform.forward;
			Destroy(eggInstance.gameObject, 10.0F); 
		}	
	}
	IEnumerator shootTimer()
	{
		while (true)
		{
			shootEgg();
			yield return new WaitForSeconds(rateOfFire);
		}
	}
}

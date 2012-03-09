using UnityEngine;
using System.Collections;

public class MainObjScript : MonoBehaviour {
	public int Multiplier = 20;
	public int sideMultiplier = 69;
	public int verticalMultiplier = 69;
	public Vector3 originalPosition;
	public int CameraMode = 1;
	public GameObject FirstPersonCam;
	public GameObject ReplayCam;
	public GameObject MainCam;
	public bool launched;
	public Vector3 originalCubePosition;
	public GameObject AllCubes;
	public GameObject LivesGUIText;
	public int lives = 5;
	public Texture2D yellowSkin;
	public Texture2D redSkin;
	public Texture2D blackSkin;
	public int birdMode;
	public float yellowSpec = 3;
	public float explosionRadius = 5.0F;
	public float explosionPower = 10.0F;
	
	// Use this for initialization
	void Start () {
	this.rigidbody.useGravity = false;
	//this.rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
	originalPosition = this.transform.position;
		CameraMode = 1;
		MainCam.active = true;
		launched = false;
		originalCubePosition = AllCubes.transform.position;
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
		LivesGUIText.guiText.text = lives.ToString();
		
		if (Input.GetKeyDown(KeyCode.E) == true) 
		{
			
				if (birdMode == 2)
				{
				this.rigidbody.velocity = this.rigidbody.velocity * yellowSpec;
				}
				if (birdMode == 3)
				{
				Vector3 explosionPosition = this.transform.position;
					Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);
					foreach (Collider hit in colliders)
					{						
					if (hit.rigidbody)
						{
						hit.rigidbody.AddExplosionForce(explosionPower, explosionPosition, explosionRadius, 3.0F);
							
						}
					}
				}
		}
		
		if (Input.GetKeyDown(KeyCode.Q) == true)
		{
			if (birdMode == 1)
			{
			this.renderer.material.mainTexture = yellowSkin;
			birdMode = 2;
			}
			else if (birdMode == 2)
			{
			this.renderer.material.mainTexture = blackSkin;
			birdMode = 3;
			}
			else if (birdMode == 3)
			{
			this.renderer.material.mainTexture = redSkin;
			birdMode = 1; 	
			}
		}
		
		if (Input.GetKeyDown(KeyCode.R) == true)
		{
			if (launched == true)
			{
			this.transform.position = originalPosition;
			AllCubes.transform.position = originalCubePosition;
			this.rigidbody.useGravity = false;
			this.rigidbody.velocity = this.transform.position * 0;
			launched = false;
			
			lives = lives - 1;
			}
		}
		
		if (Input.GetKeyDown(KeyCode.C) == true)
		{
			
			if (CameraMode == 1)
			{
				MainCam.active = false;
				FirstPersonCam.active = true;
				
				CameraMode = 2;
			}
			else if (CameraMode == 2)
			{
				FirstPersonCam.active = false;
				ReplayCam.active = true;
				CameraMode = 3;
			}
			else if (CameraMode == 3)
			{
				ReplayCam.active = false;
				MainCam.active = true;
				CameraMode = 1;
			}
		}
		
		
		
		
		if (this.transform.position.z < 0)
		{
		
		if (this.transform.position.x < -2) 
			{
			this.transform.position += new Vector3(1, 0, 0);
			}
		if (this.transform.position.x > 2)
			{
			this.transform.position += new Vector3(-1, 0, 0);	
			}
		if (this.transform.position.y < 1.7)
			{
			this.transform.position += new Vector3(0, 1, 0);	
			}
		if (this.transform.position.y > 6)
			{
			this.transform.position += new Vector3(0, -1, 0);
			}
			
		float sideInput = Input.GetAxis("Horizontal") * Time.deltaTime * sideMultiplier;
		transform.position += new Vector3(sideInput, 0, 0);
		float verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * verticalMultiplier;
		transform.position += new Vector3(0, verticalInput, 0);
	
		if (Input.GetKeyUp(KeyCode.S) == true)
		{
			Vector3 draggedPosition = this.transform.position;
		    Vector3 shootVector = originalPosition - draggedPosition;
			this.rigidbody.velocity = shootVector * Multiplier;

			this.rigidbody.useGravity = true;
			launched = true;
			
		}	
		
		}
	
	    		if (Input.GetKeyDown(KeyCode.S) == true)
		{
			
			
			
			
			float backInput = Input.GetAxis("DrawBack") * Time.deltaTime * -300;
			transform.position += new Vector3(0, 0, backInput);
			
		}
		
		
	}
}

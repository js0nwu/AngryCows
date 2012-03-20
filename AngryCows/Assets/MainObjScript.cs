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
	public GUIText LivesGUIText;
	public int score = 3000;
	public Texture2D yellowSkin;
	public Texture2D redSkin;
	public Texture2D blackSkin;
	public int birdMode;
	public float yellowSpec = 3;
	public float explosionRadius = 5.0F;
	public float explosionPower = 10.0F;
	public bool canSpec;
	public bool canChange;
	public Material BirdType;
	public Camera MainCamera;
	public GameObject ExplodeSmoke;

	
	// Use this for initialization
	void Start () {
		
		BirdType.mainTexture = redSkin;
		score = 3000;
	this.rigidbody.useGravity = false;
	//this.rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
	originalPosition = this.transform.position;
		CameraMode = 1;
		MainCam.active = true;
		launched = false;
		originalCubePosition = AllCubes.transform.position;
		canSpec = true;
		canChange = true;
		ExplodeSmoke.active = false;
	}
	
	// Update is called once per frame
	void Update () {
	    

		if (Input.GetKeyDown(KeyCode.Mouse1) == true)
		{
			MainCamera.fieldOfView = 30;
			
		}
		if (Input.GetKeyUp(KeyCode.Mouse1) == true)
		{
			MainCamera.fieldOfView = 69;
		}

		
		
		if (Input.GetKeyDown(KeyCode.E) == true) 
		{
			if (canSpec == true)
			{
			
				if (birdMode == 2)
				{
				this.rigidbody.velocity = this.rigidbody.velocity * yellowSpec;
				}
				if (birdMode == 3)
				{
				ExplodeSmoke.active = true;
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

				canSpec = false;
				
			}
		}
		
		
		
		if (Input.GetKeyDown(KeyCode.Alpha1) == true)
		{
			if (canChange == true)
			{
			BirdType.mainTexture = redSkin;
			birdMode = 1; 	
			canChange = false;
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha2) == true)
		{
			if (canChange == true)
			{
			BirdType.mainTexture = yellowSkin;
			birdMode = 2;
			canChange = false;
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha3) == true)
		{
			if (canChange == true)
			{
			BirdType.mainTexture = blackSkin;
			birdMode = 3;
			canChange = false;
			}
		}
		
		if (Input.GetKeyDown(KeyCode.R) == true)
		{
			score = score - 1000;
			ExplodeSmoke.active = false;
			canSpec = true;
			canChange = true;
			if (launched == true)
			{
				this.rigidbody.velocity = this.rigidbody.velocity * 0;
				this.rigidbody.useGravity = false;
			this.transform.position = originalPosition;
			AllCubes.transform.position = originalCubePosition;
			this.rigidbody.velocity = this.transform.position * 0;
			launched = false;
			
			
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
		LivesGUIText.text = score.ToString();
		
	}
}
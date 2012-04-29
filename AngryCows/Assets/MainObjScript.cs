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
	private bool launched;
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
	private int subtract; 
	public float touchSensitivity = 0.75F;
	public GameObject CamObject; 
	private Quaternion CamObjRotate; 
	private Vector3 tiltOffset; 
	
	// Use this for initialization
	void Start () {
		
		BirdType.mainTexture = redSkin;
		score = 0;
		LivesGUIText.guiText.text = score.ToString(); 
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
		birdMode = 1;
		CamObjRotate = CamObject.transform.rotation; 
	}
	
	// Update is called once per frame
	void Update () {
		score = int.Parse(LivesGUIText.guiText.text.ToString()); 
		if (this.transform.position.z <= 0)
		{
		canChange = true; 	
		}
	    if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.FlashPlayer || Application.platform == RuntimePlatform.NaCl || Application.platform == RuntimePlatform.WindowsWebPlayer)
		{
		if (Input.GetKey(KeyCode.Mouse1) == true)
		{
			float sideInput = Input.GetAxis("Mouse X") * Time.deltaTime * sideMultiplier * 5;
		float verticalInput = Input.GetAxis("Mouse Y") * Time.deltaTime * verticalMultiplier * 5;
			Vector3 rotateVector = new Vector3(verticalInput, sideInput, 0);
				CamObject.transform.Rotate(rotateVector); 
		}
		if (Input.GetKeyUp(KeyCode.Mouse1) == true)
		{
			CamObject.transform.rotation = CamObjRotate; 
		}
		}
		if (Application.platform == RuntimePlatform.Android )
		{
			if (Input.GetKeyDown(KeyCode.Mouse1)) //2tap start
				{
					if (birdMode == 3)
		{
			if (canChange == true)
			{
			BirdType.mainTexture = redSkin;
			birdMode = 1; 
			}
		}
		else if (birdMode == 2)
		{
			if (canChange == true)
			{
			BirdType.mainTexture = blackSkin;
			birdMode = 3;
			}
		}
		else if (birdMode == 1)
		{
			if (canChange == true)
			{
			BirdType.mainTexture = yellowSkin;
			birdMode = 2;
			}
		}
					
			}		
			//2tap end
			//touchspecstart
			foreach (Touch touch in Input.touches)
			{
				if (touch.phase == TouchPhase.Stationary && this.transform.position.z > 0)
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
				
				
			}
			
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
			
			subtract = 1000;
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
	 	
			if (Application.platform == RuntimePlatform.Android)
			{
				if (Input.GetKey(KeyCode.Escape))
			{
				subtract = 1000;
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
					return; 
				}
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
		
		
		
		//if (Input.GetKeyDown(KeyCode.Mouse0))
		//{
		if (this.transform.position.z <= 0)
		{
			float backInput = Input.GetAxis("DrawBack") * Time.deltaTime * -3;
			transform.position += new Vector3(0, 0, backInput);
		}
		//}
		
		if (Input.GetKeyUp(KeyCode.Mouse0) == true)
		{
			if (this.transform.position.z < 0)
			{
			Vector3 draggedPosition = this.transform.position;
		    Vector3 shootVector = originalPosition - draggedPosition;
			this.rigidbody.velocity = shootVector * Multiplier;

			this.rigidbody.useGravity = true;
			launched = true;
			}
			//camerascript
		}	
		
		if (this.transform.position.z < 0)
		{
		
		if (this.transform.position.x < -2) 
			{
			this.transform.position += new Vector3(0.1F, 0, 0);
			}
		if (this.transform.position.x > 2)
			{
			this.transform.position += new Vector3(-0.1F, 0, 0);	
			}
		if (this.transform.position.y < 1.7)
			{
			this.transform.position += new Vector3(0, 0.1F, 0);	
			}
		if (this.transform.position.y > 6)
			{
			this.transform.position += new Vector3(0, -0.1F, 0);
			}
		if (this.transform.position.z < -7)
			{
			this.transform.position += new Vector3(0, 0, 0.1F);	
			}
		
		if (Application.platform == RuntimePlatform.Android)
			{
		if (Input.touches.Length > 0)
			{
				if (Input.touches[0].phase == TouchPhase.Moved)
				{
					float touchx = Input.touches[0].deltaPosition.x * Time.deltaTime * touchSensitivity;
					float touchy = Input.touches[0].deltaPosition.y * Time.deltaTime * touchSensitivity;
					if (this.transform.position.z < 0)
			{
					transform.Translate(new Vector3(touchx, touchy, 0));
						}
				}
			}
			}
		if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.FlashPlayer || Application.platform == RuntimePlatform.NaCl || Application.platform == RuntimePlatform.WindowsWebPlayer)
			{
		float sideInput = Input.GetAxis("Mouse X") * Time.deltaTime * sideMultiplier;
		transform.position += new Vector3(sideInput, 0, 0);
		float verticalInput = Input.GetAxis("Mouse Y") * Time.deltaTime * verticalMultiplier;
		transform.position += new Vector3(0, verticalInput, 0);
			}
				
		
		}
	 		
	    score = score - subtract; 
		LivesGUIText.text = score.ToString();
		subtract = 0; 
	}
}

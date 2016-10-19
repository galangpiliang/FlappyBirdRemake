using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

	/// <summary>
	/// Unity 3D Flappy Bird Remake Tutorial Indonesia
	/// </summary>

	[SerializeField] float kekuatanLoncat;
	[SerializeField] float kecepatanRotasi;
	[SerializeField] float rotasiTurunKetikaVelY;
	[SerializeField] AudioClip suaraLoncat;
	[SerializeField] AudioClip suaraNabrak;
	[SerializeField] AudioClip suaraPoint;

	Splash SplashScript;
	Rigidbody2D myRigidbody;
	AudioSource[] myAudioSources;
	public bool isGrounded;

	void Awake(){
		myRigidbody = GetComponent<Rigidbody2D> ();
		myAudioSources = GetComponents<AudioSource> ();
		SplashScript = GetComponent<Splash> ();
	}

	void Update(){
		if (isGrounded)
			return;

		aturRotasi ();

		if (Input.GetMouseButtonDown(0) && !GameManager.instance.gameOver)
			loncat();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (GameManager.instance.gameOver)
			return;
		else if (col.CompareTag ("Pipe")) {
			GameManager.instance.gameOver = true;
			mainkanSuara (suaraNabrak,0);
			SplashScript.FlashIt ();
		}
		else if (col.CompareTag("Point")){
			GameManager.instance.Point++;
			mainkanSuara (suaraPoint,1);
			UiManager.instance.updateScore ();
		}

	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.collider.CompareTag ("Ground")) {
			if (!GameManager.instance.gameOver) {
				GameManager.instance.gameOver = true;
				mainkanSuara (suaraNabrak,0);
				SplashScript.FlashIt ();
			}
			GameManager.instance.GameOver ();
			GameManager.instance.gameOver = true;
			isGrounded = true;
		}
	}

	void loncat(){
		Vector3 velocity = myRigidbody.velocity;
		velocity.y = kekuatanLoncat;
		myRigidbody.velocity = velocity;
		mainkanSuara (suaraLoncat,0);
	}

	void mainkanSuara(AudioClip _suara, int ID){
		myAudioSources[ID].clip = _suara;
		myAudioSources[ID].Play();
	}

	void aturRotasi(){		
		myRigidbody.transform.rotation = Quaternion.Euler (Vector3.Lerp (Vector3.forward * -90f, Vector3.forward * 25f,
			(myRigidbody.velocity.y - (rotasiTurunKetikaVelY) + kecepatanRotasi) / kecepatanRotasi));
	}

}

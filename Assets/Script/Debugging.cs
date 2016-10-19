using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Debugging : MonoBehaviour {

	[SerializeField] Rigidbody2D birdRigidbody;
	[SerializeField] Text velocityText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		velocityText.text = " velocity " + birdRigidbody.velocity.ToString ();

		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}

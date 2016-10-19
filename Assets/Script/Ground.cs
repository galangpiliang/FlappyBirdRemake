using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {

	float batasKiriKamera;
	float setengahLebar;

	// Use this for initialization
	void Start () {
		batasKiriKamera = Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect;
		setengahLebar = GetComponent<SpriteRenderer> ().bounds.size.x / 2f;

	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gameOver)
			return;

		if (transform.position.x <= batasKiriKamera-setengahLebar )
			transform.Translate(Vector3.right * ((setengahLebar*4f)-0.04f));

		transform.Translate (Vector3.left * GameManager.instance.kecepatan * Time.deltaTime);
	}
}

using UnityEngine;
using System.Collections;

public class Pipes : MonoBehaviour {

	float batasKananKamera;
	float batasKiriKamera;
	float setengahLebar;

	// Use this for initialization
	void Start () {
		
		batasKananKamera = Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect;
		batasKiriKamera = Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect;
		setengahLebar = GetComponentInChildren<SpriteRenderer> ().bounds.size.x / 2f;
		transform.position = ((Vector3.right * transform.position.x) + (Vector3.up * Random.Range (GameManager.instance.minTinggiPipe,
			GameManager.instance.maxTinggiPipe)));

	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gameOver)
			return;

		if (transform.position.x <= batasKiriKamera-setengahLebar )
			transform.position = (Vector3.right * (batasKananKamera+(setengahLebar*2f)))+(Vector3.up*
				Random.Range(GameManager.instance.minTinggiPipe,GameManager.instance.maxTinggiPipe));

		transform.Translate (Vector3.left * GameManager.instance.kecepatan * Time.deltaTime);
	}
}

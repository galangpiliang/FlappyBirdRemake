using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {

	public static UiManager instance;

	[SerializeField] Text pointText;
	[SerializeField] GameObject IMGGameover;

	void Awake(){
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
	}

	public void updateScore(){
		pointText.text = GameManager.instance.Point.ToString ();
	}

	public void showGameOver(){
		IMGGameover.SetActive (true);
	}

}

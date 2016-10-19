using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	[Header("Game Mechanic")]
	public float kecepatan;
	public float minTinggiPipe;
	public float maxTinggiPipe;
	public bool gameOver = false;

	[Header("Game Stats")]
	public int Point;

	void Awake(){
		if (instance == null)
			instance = this;
		else
			Destroy (this);
	}

	public void GameOver(){
		UiManager.instance.showGameOver ();
	}

}

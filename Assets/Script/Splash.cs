using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Splash : MonoBehaviour {

	[SerializeField] Image splahImage;
	[SerializeField] Color splahColor;
	[SerializeField] float fadeSpeed;

	public void FlashIt(){
		StartCoroutine (Flash());
	}

	IEnumerator Flash(){
		float Transisi = 0f;
		while (Transisi < 1f) {
			splahImage.color = Color.Lerp (splahColor,Color.clear,Transisi);
			Transisi += Time.deltaTime * fadeSpeed;
			yield return null;
		}
	}

}

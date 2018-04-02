using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour {
	public GameObject bloodyScreen;
	public Text healthText;
	public static int playerHealth;

	// Use this for initialization
	void Start () {
		playerHealth = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth <= 0) {
			SceneManager.LoadScene ("GameOver");
		}
		
	}
		
	public void zombieAttack(bool zombieIsThere){
		bloodyScreen.gameObject.SetActive (true);
		StartCoroutine (wait2seconds ());

		playerHealth -= 5;
		string stringHealth = playerHealth.ToString ();
		healthText.text = "" + stringHealth;
	}

	IEnumerator wait2seconds(){
		yield return new WaitForSeconds (2f);
		bloodyScreen.gameObject.SetActive (false);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnController : MonoBehaviour {
	public GameObject demon_small;
	public GameObject demon_large;
	public GameObject demon_normal;
	public Button startBtn;

	// Use this for initialization
	void Start () {
		startBtn.onClick.AddListener (startInvoke);
	}
	
	void startInvoke(){
		InvokeRepeating ("spawn_small", 0f, 5f);
		InvokeRepeating ("spawn_normal", 0f, 10f);
		InvokeRepeating ("spawn_large", 0f, 20f);
	}

	void spawn_small(){
		Vector3 position = new Vector3 (Random.Range (-10f, 10f), Random.Range (0f, 3f), Random.Range (-10f, 10f));
		Instantiate (demon_small, position, Quaternion.Euler (0, 0, 0));
	}

	void spawn_normal(){
		Vector3 position = new Vector3 (Random.Range (-10f, 10f), Random.Range (0f, 3f), Random.Range (-10f, 10f));
		Instantiate (demon_normal, position, Quaternion.Euler (0, 0, 0));
	}

	void spawn_large(){
		Vector3 position = new Vector3 (Random.Range (-10f, 10f), Random.Range (0f, 3f), Random.Range (-10f, 10f));
		Instantiate (demon_large, position, Quaternion.Euler (0, 0, 0));
	}
}

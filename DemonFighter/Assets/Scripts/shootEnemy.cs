using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shootEnemy : MonoBehaviour {

	public Button shootBtn;
	public Camera fpsCam;
	public float damage = 10f;
	public GameObject bloodEffect;

	// Use this for initialization
	void Start () {
		shootBtn.onClick.AddListener (onShoot);

	}
	
	void onShoot(){
		RaycastHit hit;
		if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit)) {
			//destroy enemy
			//instantiate blood
			Enemy target = hit.transform.GetComponent<Enemy> ();
			if (target != null) {
				target.TakeDamage (damage);
				GameObject bloodGO = Instantiate (bloodEffect, hit.point, Quaternion.LookRotation (hit.normal));
				Destroy (bloodGO, 0.2f);
				print ("shoot");
			}
		}
	}
}

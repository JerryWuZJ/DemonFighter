using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shootEnemy : MonoBehaviour {

	public Button shootBtn;
	public Camera fpsCam;
	public float damage = 10f;
	public GameObject bloodEffect;
	public Text ammo1Text;
	public Text ammo2Text;
	public int ammo1;
	public int ammo2;
	public ParticleSystem muzzleFlash;
	private bool ammoIsEmpty;

	// Use this for initialization
	void Start () {
		shootBtn.onClick.AddListener (onShoot);
		ammo1 = 20;
		ammo2 = 100;
	}
	
	void onShoot(){

		if (!ammoIsEmpty) {
			if (ammo1 == 1) {
				ammo1 = 21;
			}
				
			ammo1 -= 1;
			string ammo1String = (ammo1).ToString ();
			ammo1Text.text = ammo1String;
			ammo2 -= 1;
			string ammo2String = (ammo2).ToString ();
			ammo2Text.text = "/" + ammo2String;

			if (ammo2 == 0) {
				ammoIsEmpty = true;
				ammo1 = 0;
				string ammo11String = (ammo1).ToString ();
				ammo1Text.text = ammo11String;
			}

			RaycastHit hit;
			if (Physics.Raycast (fpsCam.transform.position, fpsCam.transform.forward, out hit)) {
				//destroy enemy
				//instantiate blood
				enemy_small target = hit.transform.GetComponent<enemy_small> ();
				if (target != null) {
					target.TakeDamage (damage);
					GameObject bloodGO = Instantiate (bloodEffect, hit.point, Quaternion.LookRotation (hit.normal));
					Destroy (bloodGO, 0.2f);
					print ("shoot");
				}

				Enemy_normal target2 = hit.transform.GetComponent<Enemy_normal> ();
				if (target2 != null) {
					target2.TakeDamage (damage);
					GameObject bloodGO = Instantiate (bloodEffect, hit.point, Quaternion.LookRotation (hit.normal));
					Destroy (bloodGO, 0.2f);
					print ("shoot");
				}

				enemy_hooker target3 = hit.transform.GetComponent<enemy_hooker> ();
				if (target3 != null) {
					target3.TakeDamage (damage);
					GameObject bloodGO = Instantiate (bloodEffect, hit.point, Quaternion.LookRotation (hit.normal));
					Destroy (bloodGO, 0.2f);
					print ("shoot");
				}
			}
			muzzleFlash.Play ();
		}
	}
}

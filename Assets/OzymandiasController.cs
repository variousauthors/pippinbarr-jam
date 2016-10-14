using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OzymandiasController : MonoBehaviour {

	private Animator anim;
	private float originalSpeed;
	private float period = 0.2f;
	private float tic = 0;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		originalSpeed = anim.speed;
	}
	
	// Update is called once per frame
	void Update () {
		tic += Time.deltaTime;

		if (Input.anyKeyDown) {
			tic = 0;
		}

		if (tic > period) {
			anim.speed = 0f;
			anim.Play ("ozymandius-typing", -1, 0);
		} else {
			anim.speed = originalSpeed;			
		}
	}
}

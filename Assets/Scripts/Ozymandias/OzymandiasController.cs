using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OzymandiasController : MonoBehaviour {

	private Animator anim;
	private AudioSource audio;
	private float originalSpeed;
	private float period = 0.2f;
	private float tic = 1f;

	void Awake () {
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();
		originalSpeed = anim.speed;
		audio.Play ();
		audio.Pause ();	
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 0) {
			return;
		}

		tic += Time.deltaTime;

		if (Input.anyKeyDown) {
			tic = 0;
		}

		if (tic > period) {
			anim.speed = 0f;
			anim.Play ("ozymandius-typing", -1, 0);
			audio.Pause ();
		} else {
			anim.speed = originalSpeed;
			audio.UnPause ();
		}
	}
}

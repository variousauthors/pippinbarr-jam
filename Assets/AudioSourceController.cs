using UnityEngine;
using System.Collections;

public class AudioSourceController : MonoBehaviour {

	AudioSource audio;

	void Start() {
		audio = GetComponent<AudioSource>();
		audio.time = Random.Range(0, 10);
		audio.Play ();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Return)) {
			audio.Stop();
			audio.Play();
		}
		Debug.Log(audio.time);
	}
}

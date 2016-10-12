using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	private Vector3 originalCamPos;

	// Use this for initialization
	void Start () {
		originalCamPos = Camera.main.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private bool shouldShake = false;
	public void StopShaking () {
		shouldShake = false;
	}

	public void StartShaking () {
		shouldShake = true;

		StopAllCoroutines ();
		StartCoroutine (Shake());
	}

	private float duration = 0.2f;
	private float magnitude = 2f;
	private IEnumerator Shake() {

		float elapsed = 0.0f;
		float percentComplete = 0f;

		while (percentComplete < 1) {

			if (!shouldShake) { // start fading out
				elapsed += Time.deltaTime;				
			}

			percentComplete = elapsed / duration;
			float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

			// map value to [-1, 1]
			float x = Random.value * 2.0f - 1.0f;
			float y = Random.value * 2.0f - 1.0f;

			x *= magnitude * damper;
			y *= magnitude * damper;

			transform.position = new Vector3(x, y, originalCamPos.z);

			yield return null;
		}

		transform.position = originalCamPos;
	}
}

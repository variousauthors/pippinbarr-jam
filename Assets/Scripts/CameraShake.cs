using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	private Camera thisCamera;
	private Vector3 originalCamPos;
	private float originalCamSize;

	private float shakeDuration = 0.1f;
	private float shakeMagnitude = 1f;
	private float zoomResetDuration = 5f;

	// Use this for initialization
	void Start () {
		thisCamera = this.GetComponent<Camera> ();
		originalCamPos = thisCamera.transform.position;
		originalCamSize = thisCamera.orthographicSize;

	}

	private bool shouldShake = false;
	public void StopShaking () {
		shouldShake = false;
		StartCoroutine (ResetZoom(Time.time));
	}

	public void StartShaking () {
		if (shouldShake == true) {
			return;
		}

		shouldShake = true;

		this.GetComponent<Camera> ().orthographicSize *= 0.5f;

		StopAllCoroutines ();
		StartCoroutine (Shake());
	}

	private IEnumerator ResetZoom (float startTime) {
		// lerp out the zoom
		float startValue = thisCamera.orthographicSize;

		while (thisCamera.orthographicSize < originalCamSize) {
			float progress = (Time.time - startTime) / zoomResetDuration;
			thisCamera.orthographicSize = Mathf.Lerp(startValue, originalCamSize, 1f - Mathf.Cos(progress*progress * Mathf.PI * 0.5f));

			yield return null;
		}
	}
		
	private IEnumerator Shake() {

		float elapsed = 0.0f;
		float percentComplete = 0f;

		while (percentComplete < 1) {

			if (!shouldShake) { // start fading out
				elapsed += Time.deltaTime;				
			}

			percentComplete = elapsed / shakeDuration;
			float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

			// map value to [-1, 1]
			float x = Random.value * 2.0f - 1.0f;
			float y = Random.value * 2.0f - 1.0f;

			x *= shakeMagnitude * damper;
			y *= shakeMagnitude * damper;

			transform.position = new Vector3(x, y, originalCamPos.z);

			yield return null;
		}

		transform.position = originalCamPos;
	}
}

using UnityEngine;
using System.Collections;

public class CodingPixel : MonoBehaviour {

	public float period = 1f;

	private float tic = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		tic += Time.deltaTime;

		if (tic < period) {
			return;
		}

		tic = 0f;
		transform.localPosition += new Vector3 (0, 1, 0);
	}
}

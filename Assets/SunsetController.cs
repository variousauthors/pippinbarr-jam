using UnityEngine;
using System.Collections;

public class SunsetController : MonoBehaviour {

	private int startY = 249;
	private float period = 1f;
	private float tic = 0f;

	// Use this for initialization
	void Start () {
		this.transform.localPosition = new Vector2 (0, startY);
	}
	
	// Update is called once per frame
	void Update () {
		tic += Time.deltaTime;

		if (tic < period) {
			return;
		}

		tic = 0f;

		this.transform.localPosition -= new Vector3 (0, 1, 0);

	}
}

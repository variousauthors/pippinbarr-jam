using UnityEngine;
using System.Collections;

public class CodingEmitter : MonoBehaviour {

	public int monitorWidth = 12;
	public float period = 1f;
	public GameObject pixelPrefab;

	private float tic = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	private bool skip = true;
	void Update () {
		tic += Time.deltaTime;

		if (tic < period) {
			return;
		}

		tic = 0f;
		skip = !skip;

		if (skip) {			
			return;
		}

		int lineWidth = monitorWidth - Random.Range (monitorWidth/4, (int)(monitorWidth * 0.75f));
		float p = 0.7f;
		bool firstChar = true;

		for (int i = 0; i < lineWidth; i++) {
			
			if (Random.value < p) {
				GameObject pixel = Instantiate (pixelPrefab);
				CodingPixel codingPixel = pixel.GetComponent<CodingPixel> ();

				pixel.transform.SetParent (this.transform);
				pixel.transform.localPosition = new Vector3 (i, 0);

				codingPixel.period = period;
				p *= 0.8f; // if this was a letter, the next character is increasingly more likely to be a space
				firstChar = false;
			} else {
				// the first char rule permits the existence of indents
				if (firstChar) {
					lineWidth += 1;
				} else {
					p = 1f; // after a space we get a letter					
				}

			}
		}
	}
}

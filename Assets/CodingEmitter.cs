using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CodingEmitter : MonoBehaviour
{

	public int monitorWidth = 12;
	public float period = 1f;
	public GameObject pixelPrefab;

	public CurtainController curtain;

	private float tic = 0f;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	private bool skip = true;
	private int lineWidth = 0;
	private int pos = 0;
	private List<CodingPixel> pixels = new List<CodingPixel>();
	private float p = 0.7f;
	bool firstChar = true;

	void Update ()
	{
		if (Time.timeScale == 0) {
			return;
		}

		if (!Input.anyKeyDown) {
			return;
		}

		if ((lineWidth - pos) == 0) {
			// start a new line
			lineWidth = monitorWidth - Random.Range (monitorWidth / 4, (int)(monitorWidth * 0.75f));
			p = 0.7f;
			firstChar = true;
			pos = 0;

			curtain.Step ();

			// move all the existing pixels up two
			foreach (CodingPixel pixel in pixels) {
				pixel.Move ();
				pixel.Move ();
			}
		}

		if (Random.value < p) {
			GameObject pixel = Instantiate (pixelPrefab);
			CodingPixel codingPixel = pixel.GetComponent<CodingPixel> ();

			pixel.transform.SetParent (this.transform);
			pixel.transform.localPosition = new Vector3 (pos, 0);
			pixels.Add (codingPixel);

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

		pos++;
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class IntertitleController : MonoBehaviour {

	public List<string> titles;
	public Text text;
	public GameObject spacePrompt;

	private int index = 0;
	private float period = 1f;
	private float tic = 0f;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		text.text = titles [index];
		spacePrompt.SetActive(false);
	}
	
	// Update is called once per frame
	private bool wait = true;
	void Update () {
		if (wait) {
			tic += 0.016f;

			if (tic > period) {
				tic = 0f;
				wait = false;
				spacePrompt.SetActive(true);
			} else {
				return;
			}
		}

		if (!Input.GetKeyDown (KeyCode.Space)) {
			return;
		}

		spacePrompt.SetActive(false);
		index++;

		if (index < titles.Count) {
			text.text = titles [index];
		} else {
			Time.timeScale = 1;
			GameObject.Destroy (this.gameObject);
		}

		wait = true;
	}
}

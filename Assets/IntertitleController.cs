using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class IntertitleController : MonoBehaviour {

	public List<string> titles;
	public Text text;

	private int index = 0;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		text.text = titles [index];
	}
	
	// Update is called once per frame
	void Update () {
		if (!Input.GetKeyDown (KeyCode.Space)) {
			return;
		}

		index++;

		if (index < titles.Count) {
			text.text = titles [index];
		} else {
			Time.timeScale = 1;
			GameObject.Destroy (this.gameObject);
		}
	}
}

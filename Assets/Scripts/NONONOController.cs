﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NONONOController : MonoBehaviour {

	public float calmDownTime = 1f;

	[Range(0, 1)] public float noValueMin = 0.7f;
	[Range(0, 1)] public float noSaturationMin = 0.7f;
	[Range(0, 1)] public float noSizeMin = 0.5f;
	[Range(0, 1)] public float personalSpace = 0.4f;

	public List<GameObject> NOPrefabs;

	private Animator animator;
	private float quietTime = 0f;

	private bool isRapidlyPressingX = false;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}

	private void GenerateNo () {
		Vector2 position = Random.insideUnitCircle;

		while (position.magnitude < personalSpace) {
			position = Random.insideUnitCircle;
		}

		Vector3 screenPosition = Camera.main.ScreenToWorldPoint(
			new Vector3(
				position.x * Screen.width/2 + Screen.width/2, 
				position.y * Screen.width/2 + Screen.height/2, 
				Camera.main.farClipPlane / 2
			)
		);

		int index = Random.Range (0, NOPrefabs.Count);

		GameObject no = Instantiate(NOPrefabs[index], screenPosition, Quaternion.identity) as GameObject;

		no.transform.localScale = new Vector2 (Random.Range(noSizeMin, 1f), Random.Range(noSizeMin, 1f));
		no.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, noSaturationMin, 1f, noValueMin, 1f);
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.X)) {
			quietTime = 0f;
			isRapidlyPressingX = true;

			GenerateNo ();
		} else {
			quietTime += Time.deltaTime;

			if (quietTime > calmDownTime) {
				isRapidlyPressingX = false;
			}

		}

		animator.SetBool ("isRapidlyPressingX", isRapidlyPressingX);
	}
}

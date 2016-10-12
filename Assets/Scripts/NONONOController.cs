using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NONONOController : MonoBehaviour {

	public float calmDownTime = 1f;

	[Range(0, 1)] public float noValueMin = 0.7f;
	[Range(0, 1)] public float noSaturationMin = 0.7f;

	public List<GameObject> NOPrefabs;

	private Animator animator;
	private float quietTime = 0f;

	private bool isRapidlyPressingX = false;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}

	private void GenerateNo () {

		Vector3 screenPosition = Camera.main.ScreenToWorldPoint(
			new Vector3(
				Random.Range(0, Screen.width), 
				Random.Range(0, Screen.height), 
				Camera.main.farClipPlane / 2
			)
		);

		int index = Random.Range (0, NOPrefabs.Count);

		GameObject no = Instantiate(NOPrefabs[index], screenPosition, Quaternion.identity) as GameObject;

		no.transform.localScale = new Vector2 (Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
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

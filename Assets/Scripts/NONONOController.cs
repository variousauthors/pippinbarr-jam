using UnityEngine;
using System.Collections;

public class NONONOController : MonoBehaviour {

	public float calmDownTime = 1f;
	public GameObject NOPrefab;

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

		Instantiate(NOPrefab, screenPosition, Quaternion.identity);
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

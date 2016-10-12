using UnityEngine;
using System.Collections;

public class NONONOController : MonoBehaviour {

	public float calmDownTime = 1f;

	private Animator animator;
	private float quietTime = 0f;

	private bool isRapidlyPressingX = false;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.X)) {
			quietTime = 0f;
			isRapidlyPressingX = true;
		} else {
			quietTime += Time.deltaTime;

			if (quietTime > calmDownTime) {
				isRapidlyPressingX = false;
			}

		}

		animator.SetBool ("isRapidlyPressingX", isRapidlyPressingX);
	}
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EscapeController : MonoBehaviour {

	public RectTransform progressBar;
	public float duration = 5f;
	public GameObject curtain;

	private float tic = 0f;
	private float width;
	private float height;

	// Use this for initialization
	void Start () {
		curtain.SetActive (false);
		width = progressBar.rect.width;
		height = progressBar.rect.height;


		progressBar.sizeDelta = new Vector2 (0, height);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			curtain.SetActive (true);
			Time.timeScale = 0;
		} else if (curtain.activeSelf == true && Input.GetKey (KeyCode.Escape)) {
			tic += 0.016f;

			progressBar.sizeDelta = new Vector2 ((tic/duration) * width, height);

			if (tic > duration) {
				Time.timeScale = 1;
				SceneManager.LoadScene (0);
			}
			// NOP
		} else {
			curtain.SetActive (false);
			Time.timeScale = 1;
			tic = 0f;
			progressBar.sizeDelta = new Vector2 (0, height);

		}
	}
}

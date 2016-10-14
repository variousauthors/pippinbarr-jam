using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMonitor : MonoBehaviour {

	public List<RectTransform> tweets;
	public RectTransform feed;

	private float tweetHeight;
	private int position = 0; // which item are we "at"

	private bool isScrolling = false;

	// Use this for initialization
	void Start () {
		tweetHeight = tweets [0].rect.height;

		// set the position of each tweet in the feed
		for (int i = 0; i < tweets.Count; i++) {
			tweets [i].anchoredPosition += new Vector2 (0, i * -tweetHeight);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			position = Mathf.Min (position + 1, tweets.Count - 1);

			StopAllCoroutines ();
			StartCoroutine (ScrollTo(new Vector2 (0, position * tweetHeight)));
		}

		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			position = Mathf.Max (position - 1, 0);

			StopAllCoroutines ();
			StartCoroutine (ScrollTo(new Vector2 (0, position * tweetHeight)));
		}

		if (Input.GetKeyDown (KeyCode.Space) && !isScrolling) {
			// here we might fade out
			if (position != 0) {
				SceneManager.LoadScene (position);
			}
		}
	}

	IEnumerator ScrollTo (Vector2 endPosition) {
		Vector2 startPosition = feed.anchoredPosition;
		float lerpTime = 0.5f;
		float time = 0f;
		float progress = 0f;

		isScrolling = true;

		while (time < lerpTime) {
			time += Time.deltaTime;
			progress = time / lerpTime;

			feed.anchoredPosition = Vector2.Lerp (startPosition, endPosition,  Mathf.Sin(progress * Mathf.PI * 0.5f));
			yield return null;			
		}

		isScrolling = false;
	}
}

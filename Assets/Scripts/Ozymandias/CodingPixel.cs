using UnityEngine;
using System.Collections;

public class CodingPixel : MonoBehaviour {

	private SpriteRenderer spriteRenderer;
	private Color originalColor;

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		originalColor = spriteRenderer.color;
	}

	public void Move () {
		transform.localPosition += new Vector3 (0, 1, 0);
	}

	public void FadeOut () {
		Color color = spriteRenderer.color;
		color.a *= 0.9f;

		spriteRenderer.color = color;
	}
}

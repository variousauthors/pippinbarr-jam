using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurtainController : MonoBehaviour {

	private Image image;
	private float increment = 0.01f;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image> ();
	}

	public void Step () {
		Color color = image.color;
		color.a += increment;
		increment = 1.1f * increment;

		image.color = color;

		if (image.color.a == 1) {
			
		}
	}
}

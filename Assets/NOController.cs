using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NOController : MonoBehaviour {

	public float lifetimeMax = 4f;
	private float lifetime;

	// Use this for initialization
	void Start () {
		lifetime = Random.Range (0f, lifetimeMax);
	}
	
	// Update is called once per frame
	void Update () {
		lifetime -= Time.deltaTime;

		if (lifetime < 0) {
			GameObject.Destroy (gameObject);
		}
	}
}

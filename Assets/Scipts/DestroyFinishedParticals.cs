using UnityEngine;
using System.Collections;

public class DestroyFinishedParticals : MonoBehaviour {

	private ParticleSystem particaleSystem;

	void Start () {
		particaleSystem = GetComponent <ParticleSystem> ();
	}

	void Update () {
		if (particaleSystem.isPlaying) {
			return;
		}
		Destroy (gameObject);
	}
}

using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour {

	public GameObject Enemy;
	public GameObject deathParticals;
	public GameObject Player;

	public float DeathDistance;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			Destroy (Enemy);
			Instantiate (deathParticals, transform.position, transform.rotation);
		}
	}
}

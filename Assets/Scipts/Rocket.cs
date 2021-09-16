using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

	public int moveSpeed;

	public GameObject exploshion;

	
	// Update is called once per frame
	void Update () {	
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, 0);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Ground") || other.gameObject.CompareTag ("Player")) {
			Destroy (gameObject);
			Debug.Log("Dead");
			Instantiate (exploshion, transform.position, transform.rotation);
		}
	}
}

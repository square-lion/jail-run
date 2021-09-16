using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;
	public GameObject dealthParticals;
	public GameObject respawnParticals;

	public float respawnDelay;

	private PlayerController playerController;
	// Use this for initialization
	void Start () {
		playerController = FindObjectOfType<PlayerController> ();
	}
	public void RespawnPlayer()
	{
		StartCoroutine ("RespawnPlayerCo");
	}
	public IEnumerator RespawnPlayerCo()
	{
		
		Instantiate (dealthParticals, playerController.transform.position, playerController.transform.rotation);
		playerController.enabled = false;
		//playerController.GetComponent<Renderer>().enabled = false;
		playerController.Respawn(false);
		playerController.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		Debug.Log ("Player Respawn");
		yield return new WaitForSeconds (respawnDelay);
		playerController.transform.position = currentCheckpoint.transform.position;
		Instantiate (respawnParticals, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
		playerController.enabled = true;
		//playerController.GetComponent<Renderer>().enabled = true;
		playerController.Respawn(true);
	}
}

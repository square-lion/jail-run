using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	private PlayerController player;
	
	void Start () {
		player = FindObjectOfType<PlayerController>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
		player.key.gameObject.SetActive(true);
		player.hasKey = true;
		gameObject.SetActive(false);
		}
	}
}

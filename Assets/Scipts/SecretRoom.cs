using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretRoom : MonoBehaviour {

	public GameObject blackImage;

	void OnTriggerEnter2D(Collider2D other)
	{
		blackImage.SetActive(false);
	}
}

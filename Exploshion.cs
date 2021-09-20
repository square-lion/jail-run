using UnityEngine;
using System.Collections;

public class Exploshion : MonoBehaviour {
	public float  timeAlive;
	public bool kill = false;

	void Start()
	{
		Invoke ("Destroy", timeAlive);
	}

	void Destroy()
	{
		Destroy (gameObject);
	}


}

using UnityEngine;
using System.Collections;

public class Boss1 : MonoBehaviour {

	public GameObject rocket;
	public GameObject launchPoint;
	public GameObject coin;
	public GameObject exploshion;
	public GameObject present;
	public Transform point1;
	public Transform point2;
	public float startDelay;
	public float shootDelay;
	public float speed;
	public float DealthDelay;
	public float Health;
	public int pointsToGet;
	public bool Winner = false;

	private bool atPoint1;
	private bool atPoint2;
	private bool shooting = true;

	void Start()
	{
		InvokeRepeating ("ShootRockets" ,startDelay, shootDelay);
		transform.position = point1.position;
		atPoint1 = true;
		atPoint2 = false;
	}
	void Update()
	{
		if(transform.position == point2.position)
			{
			atPoint1 = false;
			atPoint2 = true;
		}
		if(transform.position == point1.position)
		{
			atPoint1 = true;
			atPoint2 = false;
		}
		if (atPoint1)
			MovingPlatformUp ();

		if (atPoint2)
			MovingPlatformDown ();
		if (Health == 1) {
			speed = 10f;
			shootDelay = .2f;
		}
		if (Health <= 0)
			Death ();

	}
	public void ShootRockets ()
	{
			if(shooting)
			Instantiate (rocket, launchPoint.transform.position, launchPoint.transform.rotation);
	}
	void MovingPlatformUp()
	{
		transform.position = Vector3.MoveTowards (transform.position, point2.position, Time.deltaTime * speed);	
	}
	void MovingPlatformDown()
	{
		transform.position = Vector3.MoveTowards (transform.position, point1.position, Time.deltaTime * speed);	
	}
	public void Death()
	{
		Destroy (gameObject);
		Instantiate (exploshion, transform.position, transform.rotation);
		Instantiate (present, transform.position, transform.rotation);
		Winner = true;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") {
			Health--;
		}
	}

		

}

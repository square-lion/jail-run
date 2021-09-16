using UnityEngine;
using System.Collections;

public class Cop : MonoBehaviour {

	public float wallCheckRadius;

	public Transform wallCheck;

	public LayerMask whatIsWall;

	private bool hittingWall;


	private Animator anim;
	private Rigidbody2D rb;

	public float speed;

	public bool moveRight;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb= GetComponent<Rigidbody2D>();
	}
	void FixedUpdate()
	{
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);

		if (hittingWall) {
		
			moveRight = !moveRight;
		}
	}
	// Update is called once per frame
	void Update ()
	{
		if (moveRight) {
			rb.velocity = new Vector2 (speed, rb.velocity.y);
		}
		if (!moveRight) {
			rb.velocity = new Vector2 (-speed, rb.velocity.y);
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") {
			anim.SetBool ("HittingPlayer", true);
			Debug.Log ("Dead");
		} else {
			anim.SetBool ("HittingPlayer", false);
		}
	}
}
using UnityEngine;
using System.Collections;

public class Cop : MonoBehaviour {

	public float moveSpeed;
	private float MoveVelocity;
	public bool facingRight;

	public float wallCheckRadius;
	public Transform wallCheck;
	public LayerMask whatIsWall;
	private bool hittingWall;


	public Transform edgeCheck;
	private bool hittingEdge;

	
	

	private Rigidbody2D rb;
	private Animator anim;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		anim.SetBool("IsWalking", true);
	}
	
	// Update is called once per frame
	void Update () {
		MoveVelocity = 0f;
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);
		hittingEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatIsWall);
		if (hittingWall || !hittingEdge)
			facingRight = !facingRight;


		if (facingRight && anim.GetBool("IsWalking")) {
			MoveVelocity = moveSpeed;
			transform.localScale = new Vector3 (-1f, 1f,1f);
		}
		if (!facingRight && anim.GetBool("IsWalking")) {
			MoveVelocity = -moveSpeed;
			transform.localScale = new Vector3 (1f, 1f,1f);
		}
		rb.velocity = new Vector2 (MoveVelocity, rb.velocity.y);
	}
			

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag ("Player")) {
			StartCoroutine ("Attacking");
		} 
	}

	public IEnumerator Attacking()
	{
		anim.SetBool ("HittingPlayer", true);
		anim.SetBool ("IsWalking", false);
		yield return new WaitForSeconds (1);
		anim.SetBool ("HittingPlayer", false);
		anim.SetBool ("IsWalking", true);


	}
}
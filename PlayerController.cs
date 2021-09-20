using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;
	public float groundCheckRadius;
	public float climbSpeed;

	public bool hasKey;
	public GameObject key;

	private float climbVelocity;
	private float moveVelocity;
	private float gravityScore;
	private int ladderDir;

	public Transform groundCheck;

	public LayerMask whatIsGround;

	public bool onLadder;

	private bool grounded;
	private bool doubleJumped;

	private Rigidbody2D rb;
	private Animator anim;

	public GameObject jumpButton;
	public GameObject upButton;
	public GameObject downButton;

	public bool inAnimation;

	[Header("Character Customization")]
	public int outfitID;
	public int skinID;
	public int footwearID;
	public int eyesID;
	public int facialHairID;
	public int hairID;
	public int headwearID;
	public int tHeadwearID;

	public Sprite[] curOutfit;
	public Sprite[] curSkin;
	public Sprite[] curFootwear;
	public Sprite[] curEyes;
	public Sprite[] curFacialHair;
	public Sprite[] curHair;
	public Sprite[] curHeadwear;
	public Sprite[] curTHeadwear;

	public Sprite Empty;
	
	public SpriteRenderer outfitRenderer;
	public SpriteRenderer skinRenderer;
	public SpriteRenderer footwearRenderer;
	public SpriteRenderer eyesRenderer;
	public SpriteRenderer facialHairRenderer;
	public SpriteRenderer hairRenderer;
	public SpriteRenderer headwearRenderer;
	public SpriteRenderer tHeadwearRenderer;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		gravityScore = rb.gravityScale;

		//Outfit
		outfitID = PlayerPrefs.GetInt("Outfit");
		curOutfit = new Sprite[5];
		for(int x = 0; x < 5; x++)
			curOutfit[x] = Resources.LoadAll<Sprite>("0Outfit")[outfitID*5+x];	

		//Skin
		skinID = PlayerPrefs.GetInt("Skin");
		curSkin = new Sprite[5];
		for(int x = 0; x < 5; x++)
			curSkin[x] = Resources.LoadAll<Sprite>("1Skin")[skinID*5+x];

		//Footwear
		footwearID = PlayerPrefs.GetInt("Footwear");
		curFootwear = new Sprite[5];
		if(footwearID == 0){
			for(int x = 0; x < 5; x++)
				curFootwear[x] = Empty;
		}
		else{	
			for(int x = 0; x < 5; x++)
				curFootwear[x] = Resources.LoadAll<Sprite>("2Footwear")[(footwearID-1)*5+x];
		}
		
		//Eyes
		eyesID = PlayerPrefs.GetInt("Eyes");
		curEyes = new Sprite[5];
		for(int x = 0; x < 5; x++)
			curEyes[x] = Resources.LoadAll<Sprite>("3Eyes")[eyesID*5+x];

		//Facial Hair
		facialHairID = PlayerPrefs.GetInt("FacialHair");
		curFacialHair = new Sprite[5];
		if(facialHairID == 0){
			for(int x = 0; x < 5; x++)
				curFacialHair[x] = Empty;
		}
		else{
			for(int x = 0; x < 5; x++)
				curFacialHair[x] = Resources.LoadAll<Sprite>("4FacialHair")[(facialHairID-1)*5+x];
		}

		//Hair
		hairID = PlayerPrefs.GetInt("Hair");
		curHair = new Sprite[5];
		if(hairID == 0){
			for(int x = 0; x < 5; x++)
				curHair[x] = Empty;
		}
		else{	
			for(int x = 0; x < 5; x++)
				curHair[x] = Resources.LoadAll<Sprite>("5Hair")[(hairID-1)*5+x];
		}

		//Headwear
		headwearID = PlayerPrefs.GetInt("Headwear");
		curHeadwear = new Sprite[5];
		if(headwearID == 0){
			for(int x = 0; x < 5; x++)
				curHeadwear[x] = Empty;
		}
		else{	
			for(int x = 0; x < 5; x++)
				curHeadwear[x] = Resources.LoadAll<Sprite>("6Headwear")[(headwearID-1)*5+x];
		}

		//T Headwear
		tHeadwearID = PlayerPrefs.GetInt("THeadwear");
		curTHeadwear = new Sprite[5];
		if(tHeadwearID == 0){
			for(int x = 0; x < 5; x++)
				curTHeadwear[x] = Empty;
		}
		else{	
			for(int x = 0; x < 5; x++)
				curTHeadwear[x] = Resources.LoadAll<Sprite>("7TransparentHeadwear")[(tHeadwearID-1)*5+x];
		}
	}
	void FixedUpdate()
	{
		if(inAnimation)
			grounded = true;
		else
			grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);	
	}
	// Update is called once per frame
	void Update ()
	{
		anim.SetBool("OnLadder", onLadder);

		if (grounded)
			doubleJumped = false;

		if(Input.GetKeyDown(KeyCode.Space) && grounded)
		{
			Jump ();
		}
		if(Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)
		{
			Jump ();
			doubleJumped = true;
		}
		//moveVelocity = moveSpeed * Input.GetAxisRaw ("Horizontal");

		if (onLadder) {
			upButton.SetActive(true);
			downButton.SetActive(true);
			jumpButton.SetActive(false);

			rb.gravityScale = 0f;

			climbVelocity = climbSpeed * ladderDir;

			rb.velocity = new Vector2 (rb.velocity.x, climbVelocity);
		}
		else{
			if(upButton != null){
			upButton.SetActive(false);
			downButton.SetActive(false);
			jumpButton.SetActive(true);
			rb.gravityScale = gravityScore;
			}
		}
		
		anim.SetBool ("Grounded", grounded);
		anim.SetFloat ("Speed", Mathf.Abs(rb.velocity.x));

		if(!inAnimation){
		if (rb.velocity.x > 0) {
			transform.localScale = new Vector3 (-1, 1f, 1f);
		}
		else if (rb.velocity.x <0){
			transform.localScale = new Vector3 (1f, 1f, 1f);
		} 
		
		rb.velocity = new Vector2 (moveVelocity, rb.velocity.y);
		anim.SetFloat ("Speed", Mathf.Abs (rb.velocity.x));
		}
	}
	public void Jump()
	{
		if(grounded)
		rb.velocity = new Vector2 (rb.velocity.x, jumpHeight);	
		if(!grounded && !doubleJumped)
		{
			rb.velocity = new Vector2 (rb.velocity.x, jumpHeight);	
			doubleJumped = true;
		}
	}
	public void Move(int dir)
	{
		moveVelocity = moveSpeed * dir;
	}
	public void Ladder(int dir)
	{
		ladderDir = dir;
	}

	public void Idle(){
		ChangeState(0);
	}
	public void Walking0(){
		ChangeState(1);
	}
	public void Walking1(){
		ChangeState(2);
	}
	public void Jumping(){
		ChangeState(3);
	}
	public void Climbing(){
		ChangeState(4);
	}

	public void ChangeState(int state){
		outfitRenderer.sprite = curOutfit[state];
		skinRenderer.sprite = curSkin[state];
		footwearRenderer.sprite = curFootwear[state];
		eyesRenderer.sprite = curEyes[state];
		facialHairRenderer.sprite = curFacialHair[state];
		hairRenderer.sprite = curHair[state];
		headwearRenderer.sprite = curHeadwear[state];
		tHeadwearRenderer.sprite= curTHeadwear[state];
	}

	public void Respawn(bool death){
		outfitRenderer.enabled = death;
		skinRenderer.enabled = death;
		footwearRenderer.enabled = death;
		eyesRenderer.enabled = death;
		facialHairRenderer.enabled = death;
		hairRenderer.enabled = death;
		headwearRenderer.enabled = death;
		tHeadwearRenderer.enabled = death;
	}
}

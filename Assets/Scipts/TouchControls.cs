using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TouchControls : MonoBehaviour {

	private PlayerController player;
	private int dir;

	public Button retry;
	void Start()
	{
		player = FindObjectOfType<PlayerController>();
		retry.gameObject.SetActive(PlayerPrefs.GetInt("FromLS") == 1);
	}
	void Update(){
		if(Input.GetKey(KeyCode.A))
			MoveLeft();
		if(Input.GetKey(KeyCode.D))
			MoveRight();
		if(Input.GetKey(KeyCode.W))
			MoveUp();
		if(Input.GetKey(KeyCode.S))
			MoveDown();
		if(Input.GetKeyDown(KeyCode.Space))
			Jump();
		if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
			StopMoving();
		if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
			LadderStop();
	}

	public void MoveLeft()
	{
		player.Move(-1);
	}
	public void MoveRight()
	{
		player.Move(1);
	}
	public void StopMoving()
	{
		player.Move(0);
	}
	public void Jump()
	{
		player.Jump();
	}
	public void MoveUp()
	{
		player.Ladder(1);
	}
	public void MoveDown()
	{
		player.Ladder(-1);
	}
	public void LadderStop()
	{
		player.Ladder(0);
	}
	public void Restart(){
		FindObjectOfType<Timer>().yourTime = 0;
		SceneManager.LoadScene("Menu");
	}
}

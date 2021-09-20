using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour {

	public string nextScene;

	public void Go()
	{
		SceneManager.LoadScene(nextScene);
	}
}

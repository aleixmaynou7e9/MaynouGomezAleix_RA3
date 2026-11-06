using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
	public static MySceneManager instance;

	//Singleton
	void Awake() 
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
	//Singleton

	public void StartGame()
	{
		UIManager.instance.ClosePause();
		SceneManager.LoadScene("Level1");
	}

	public void Lose()
	{
		SceneManager.LoadScene("LoseScene");
	}

	public void Win()
	{
		SceneManager.LoadScene("WinScene");
	}

	public void Intro()
	{
		UIManager.instance.ClosePause();
		SceneManager.LoadScene("Home Menu");
	}
}
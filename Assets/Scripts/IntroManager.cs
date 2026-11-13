using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
	public void StartGame()
	{
		SceneManager.LoadScene("Level1");
	}

	public void Intro()
	{
		SceneManager.LoadScene("Home Menu");
	}

	public void Exit()
	{
		Application.Quit();
	}
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
	public static MySceneManager instance;
	public static bool youWin = false;

    //Singleton
    void Awake() 
	{
		if (instance == null)
		{
			instance = this;
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

	public void Level2()
    {
        UIManager.instance.ClosePause();
        SceneManager.LoadScene("Level2");
    }

    public void Level3()
    {
        UIManager.instance.ClosePause();
        SceneManager.LoadScene("Level3");
    }

	public void Level4()
    {
        UIManager.instance.ClosePause();
        SceneManager.LoadScene("Level4");
    }

    public void RestartLevel()
    {
        UIManager.instance.ClosePause();
        Time.timeScale = 1f;
        UIManager.instance.isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void Lose()
	{
		SceneManager.LoadScene("Game Over");
	}

	public static void Win()
	{
        youWin = true;
        SceneManager.LoadScene("Game Over");
	}

	public void Intro()
	{
		UIManager.instance.ClosePause();

        MusicManager.instance.RestartMusic();

        SceneManager.LoadScene("Home Menu");
	}
}
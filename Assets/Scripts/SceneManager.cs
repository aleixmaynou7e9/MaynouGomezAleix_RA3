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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void Lose()
	{
		SceneManager.LoadScene("Game Over");
	}

	public static void Win()
	{
		SceneManager.LoadScene("WinScene");
	}

	public void Intro()
	{
		UIManager.instance.ClosePause();

        if (MusicManager.instance != null)
        {
            MusicManager.instance.RestartMusic();
        }

        SceneManager.LoadScene("Home Menu");
	}
}
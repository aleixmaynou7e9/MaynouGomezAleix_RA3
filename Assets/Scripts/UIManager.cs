using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour, InputSystem_Actions.ICanvasActions
{
	public GameObject pausePanel;
	public bool isPaused = false;
	public static UIManager instance;
	private InputSystem_Actions inputActions;

	//Singleton
	void Awake()
	{
		inputActions = new InputSystem_Actions();
		inputActions.Canvas.SetCallbacks(this);

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

	private void OnEnable()
	{
		inputActions.Enable();
	}

	private void OnDisable()
	{
		inputActions.Disable();
	}

	public void OnPause(InputAction.CallbackContext context)
	{
		if (SceneManager.GetActiveScene().buildIndex!=0 && SceneManager.GetActiveScene().buildIndex != 1) 
		{
            Debug.Log("Scene correct");

            if (context.performed && !isPaused)
			{
				Debug.Log("Pause");
                OpenPause();
			}
			else if (context.performed && isPaused)
			{
				Debug.Log("Resume");
				ClosePause();
			}
		}
	}
	public void OpenPause()
	{
		pausePanel.SetActive(true);
		Time.timeScale = 0f;
		isPaused = true;

        if (MusicManager.instance != null) MusicManager.instance.PauseMusic();
    }
	public void ClosePause()
	{
		pausePanel.SetActive(false);
		Time.timeScale = 1f;
		isPaused = false;

        if (MusicManager.instance != null) MusicManager.instance.PlayMusic();
    }
}

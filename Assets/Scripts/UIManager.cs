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

	void Update()
    {
        
    }

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
		if (SceneManager.GetActiveScene().buildIndex!=1) 
		{
			if (context.performed && !isPaused)
			{
				OpenPause();
			}
			else if (context.performed && isPaused)
			{
				ClosePause();
			}
		}
	}
	public void OpenPause()
	{
		pausePanel.SetActive(true);
		Time.timeScale = 0f;
		isPaused = true;
	}
	public void ClosePause()
	{
		pausePanel.SetActive(false);
		Time.timeScale = 1f;
		isPaused = false;

	}
}

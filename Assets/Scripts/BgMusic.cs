using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
	private static BackgroundMusic instance;
	private AudioSource audioSource;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();

		if (instance != null && instance != this)
		{
			if (audioSource != null)
			{
				audioSource.mute = true;
				audioSource.Stop();
				audioSource.enabled = false;
			}

			gameObject.SetActive(false);

			Destroy(gameObject);
			return;
		}

		instance = this;
		DontDestroyOnLoad(gameObject);

		if (audioSource != null && !audioSource.isPlaying)
		{
			audioSource.Play();
		}
	}
}
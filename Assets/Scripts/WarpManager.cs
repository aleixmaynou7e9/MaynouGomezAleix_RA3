using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpManager : MonoBehaviour
{
    [SerializeField] private AudioClip WarpSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            string currentScene = SceneManager.GetActiveScene().name;

            AudioManager.instance.PlaySFX(WarpSound);

            if (currentScene == "Level1")
            {
                MySceneManager.instance.Level2();
            }
            else if (currentScene == "Level2")
            {
                MySceneManager.instance.Level3();
            }
            else if (currentScene == "Level3")
            {
                MySceneManager.instance.Level4();
            }
            else if (currentScene == "Level4")
            {
                MySceneManager.Win();
            }
        }
    }
}

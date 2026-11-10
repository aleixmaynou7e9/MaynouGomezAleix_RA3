using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            string currentScene = SceneManager.GetActiveScene().name;

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
        }
    }
}
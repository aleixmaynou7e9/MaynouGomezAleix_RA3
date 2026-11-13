using UnityEngine;

public class VoidManager : MonoBehaviour
{
    [SerializeField] private AudioClip VoidDeathSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.PlaySFX(VoidDeathSound);
            PlayerController.Die();
        }
    }
}
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private float lifeTime = 2f;

    [SerializeField] private AudioClip VoidDeathSound;
    private AudioSource audioSource;
    private float lifeTimer;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        lifeTimer = lifeTime;
        transform.SetParent(null);
    }

    public void Init()
    {
        lifeTimer = lifeTime;

        if (rb == null) rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.left * speed;
    }

    private void Update()
    {
        if (rb.linearVelocity == Vector2.zero)
        {
            rb.linearVelocity = Vector2.left * speed;
        }

        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
        {
            ProjectilePool.Instance.ReturnProjectile(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (!gameObject.activeSelf) return;


        if (other.CompareTag("Player"))
        {
            AudioManager.instance.PlaySFX(VoidDeathSound);
            PlayerController.Die();
        }
    }
}
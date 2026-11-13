using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, InputSystem_Actions.IPlayerControlsActions
{

    public static PlayerController instance;
    [SerializeField] float speed = 5f;
	[SerializeField] float rayLength = 0.7f;
	public LayerMask groundLayer;
	private Rigidbody2D rb;
	private SpriteRenderer sp;

	private InputSystem_Actions inputActions;
	private RaycastHit2D hit;
	private float moveInput;
	private Animator animator;
    private bool isDead = false;
    [SerializeField] float deathDelay = 0.775f;

    private void Awake()
	{
        instance = this;
        rb = GetComponent<Rigidbody2D>();
		sp = GetComponent<SpriteRenderer>();
		inputActions = new InputSystem_Actions();
		inputActions.PlayerControls.SetCallbacks(this);
		animator = GetComponent<Animator>();
	}

	void Start()
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

	void Update()
	{
		Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.red);
        if (isDead) return;

        switch (moveInput)
		{
			case > 0:
				sp.flipX = false;
				break;
			case < 0:
				sp.flipX = true;
				break;
			case 0:
				;
				break;
		}
	}

	void FixedUpdate()
	{
        if (isDead) return;

        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
	}

	bool IsGrounded()
	{
		hit = Physics2D.Raycast(transform.position, rb.gravityScale > 0 ? Vector2.down : Vector2.up, rayLength, groundLayer);

		Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.red);

		return hit.collider != null;
	}
	
    public static void Die()
    {
        if (instance != null && !instance.isDead)
        {
            instance.StartCoroutine(instance.DieRoutine());
        }
    }
	
    private IEnumerator DieRoutine()
    {
        isDead = true;
        rb.linearVelocity = Vector2.zero;
        animator.SetBool("die", true);

        yield return new WaitForSeconds(deathDelay);

        MySceneManager.Lose();
    }

    public void OnGravity(InputAction.CallbackContext context)
	{
		if (context.performed && IsGrounded())
		{
			transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
			rb.gravityScale = -rb.gravityScale;
		}
	}

	public void OnMovement(InputAction.CallbackContext context)
	{
		moveInput = context.ReadValue<Vector2>().x;

		animator.SetBool("walk", Mathf.Abs(moveInput) > 0.01f);
	}
	
}


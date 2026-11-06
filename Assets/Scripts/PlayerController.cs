using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour, InputSystem_Actions.IPlayerControlsActions
{
	[SerializeField] float speed = 5f;
	[SerializeField] float rayLength = 0.7f;
	public LayerMask groundLayer;
	private Rigidbody2D rb;
	private SpriteRenderer sp;

	private InputSystem_Actions inputActions;
	private RaycastHit2D hit;
	private float moveInput;
	private Animator animator;

	private void Awake()
	{
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
		rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
	}

	bool IsGrounded()
	{
		hit = Physics2D.Raycast(transform.position, rb.gravityScale > 0 ? Vector2.down : Vector2.up, rayLength, groundLayer);

		Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.red);

		return hit.collider != null;
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

		animator.SetFloat("speed", Mathf.Abs(moveInput));
	}

}

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float speedMultiplier;

    public float speedIncriseMilestone;
    private float speedMilestoneCount;

    public float jumpForce;

    private Rigidbody2D playerRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;

    private Collider2D playerCollider;

    private Animator playerAnimator;

	// Use this for initialization
	void Start () {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        playerAnimator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        grounded = Physics2D.IsTouchingLayers(playerCollider, whatIsGround);

        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncriseMilestone;

            speedIncriseMilestone = speedIncriseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }

        playerRigidbody.velocity = new Vector2(moveSpeed, playerRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if(grounded)
            {
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
            }
        }

        playerAnimator.SetFloat("Speed", playerRigidbody.velocity.x);
        playerAnimator.SetBool("Grounded", grounded);
    }
}

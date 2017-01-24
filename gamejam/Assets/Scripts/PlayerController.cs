using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float speedMultiplier;

    public float speedIncreaseMilestoneStore;
    public float speedIncriseMilestone;
    private float speedMilestoneCount;

    public float jumpForce;

    private Rigidbody2D playerRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    private float moveSpeedStore;
    private float speedMilestoneCountStore;

    private bool attack;
    private float attackTimer = 0;
    private float attackCd = 0.2f;

    public GameManager gameManager;

    private Collider2D playerCollider;
    public Collider2D attackTrigger;

    private Animator playerAnimator;

	// Use this for initialization
	void Start () {
        playerRigidbody = GetComponent<Rigidbody2D>();
       // playerCollider = GetComponent<Collider2D>();
        playerAnimator = GetComponent<Animator>();
        attackTrigger.enabled = false;

        speedMilestoneCount = speedIncriseMilestone;

        moveSpeedStore = moveSpeed;

        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncriseMilestone;
    }
	
	// Update is called once per frame
	void Update () {
        // grounded = Physics2D.IsTouchingLayers(playerCollider, whatIsGround);

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncriseMilestone;

            speedIncriseMilestone = speedIncriseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }

        playerRigidbody.velocity = new Vector2(moveSpeed, playerRigidbody.velocity.y);

        HandleInput();
    }

    void FixedUpdate()
    {
        HandleAttacks();
    //    ResetValues();
    }

    private void HandleAttacks()
    {
        if (attack)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
                gameObject.tag = "attack";
            }
            else
            {
                attack = false;
                attackTrigger.enabled = false;
                gameObject.tag = "player";
            }
        }
        playerAnimator.SetBool("attack", attack);
    }

    //private void ResetValues()
    //{
    //    attack = false;
    //}

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack = true;
            attackTimer = attackCd;

            attackTrigger.enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("Collided");
        if (other.gameObject.tag == "killbox")
        {
            gameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncriseMilestone = speedIncreaseMilestoneStore;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "killbox" && gameObject.tag != "attack")
        {
            gameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncriseMilestone = speedIncreaseMilestoneStore;
        }
    }
}

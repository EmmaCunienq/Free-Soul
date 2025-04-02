using Unity.VisualScripting;
using UnityEngine;

public class PlayerDeplacements : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public float slideSpeed;

    public int jumps = 0;
    private Vector3 velocity = Vector3.zero;
    public bool isGrounded;
    public bool isOnAWall;

    private Rigidbody2D playerRB;
    private Animator animator;

    public float distancePrism;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Jump(Input.GetButtonDown("Jump") && jumps < 2);
    }

    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement);

        UpdateAnimationsParameters();
    }

    void MovePlayer (float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, playerRB.linearVelocityY);
        playerRB.linearVelocity = Vector3.SmoothDamp(playerRB.linearVelocity, targetVelocity, ref velocity, 0.05f);

        

        if (isOnAWall)
        {
            playerRB.AddForce(new Vector2(0f, slideSpeed * (-1)));
        }
    }

    void Jump (bool isJumping)
    {
        if (isJumping)
        {
            playerRB.AddForce(new Vector2(0f, jumpForce));
            jumps++;
        }
    }

    void UpdateAnimationsParameters ()
    {

        animator.SetFloat("HorizontalSpeed", playerRB.linearVelocityX);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isOnAWall", isOnAWall);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (collision.contacts[0].normal.y > 0.5f)
            {
                isGrounded = true;
                jumps = 0;
            }

            if (collision.contacts[0].normal.y < 0.5f)
            {
                isOnAWall = true;
            }
            
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (collision.contacts[0].normal.y > 0.5f)
            {
                isGrounded = true;
                isOnAWall = false;
            }

            if (collision.contacts[0].normal.y < 0.5f)
            {
                isGrounded = false;
                isOnAWall = true;
            }
        }
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            isOnAWall = false;
        }
    }

    public bool isClosePrism (GameObject prism)
    {
        return ((prism.transform.position.x < transform.position.x + distancePrism && prism.transform.position.x > transform.position.x - distancePrism) && (prism.transform.position.y < transform.position.y + distancePrism && prism.transform.position.y > transform.position.y - distancePrism));
    }
}

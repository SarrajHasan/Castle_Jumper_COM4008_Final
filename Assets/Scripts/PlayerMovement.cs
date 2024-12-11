using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    public CoinManager cm;

    
    [SerializeField] private int maxJumps = 2;
    private int jumpsRemaining;

   
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius = 0.2f;
    private bool isGrounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpsRemaining = maxJumps; 
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

        
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        if (isGrounded)
        {
            
            jumpsRemaining = maxJumps;
        }

        
        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
            jumpsRemaining--;
        }

        
        anim.SetBool("Run", Mathf.Abs(horizontalInput) > 0.01f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            cm.coinCount++;
        }
    }
}
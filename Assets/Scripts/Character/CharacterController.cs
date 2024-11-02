using UnityEngine;

public class CharacterController : MonoBehaviour
{
    
    public float movSpeed;
    float speedX, speedY;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxis("Horizontal");
        speedY = Input.GetAxis("Vertical");
        movement = new Vector2(speedX, speedY).normalized;
        animator.SetFloat("x", movement.x);
        animator.SetFloat("y", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);
    }
    
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * (movSpeed * Time.fixedDeltaTime));
    }

    public void FreezeCharacter()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }

    public void UnFreezeCharacter()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}

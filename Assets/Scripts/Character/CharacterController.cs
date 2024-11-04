using System.Collections;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    
    public float movSpeed;
    public bool canMove;
    float speedX, speedY;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        canMove = true;
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
        if (canMove)
        {
            rb.MovePosition(rb.position + movement * (movSpeed * Time.fixedDeltaTime));
        }
    }

    public void FreezeCharacter(float seconds)
    {
        StartCoroutine(TemporalMovementFreeze(seconds));
    }

    private IEnumerator TemporalMovementFreeze(float seconds)
    {
        canMove = false;
        yield return new WaitForSeconds(seconds);
        canMove = true;
    }

    public bool IsMoving()
    {
        return movement != Vector2.zero;
    }
}

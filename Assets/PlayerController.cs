using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public EnemySelect enemySelect;

    Vector2 movementInput;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    Animator animator;
    SpriteRenderer spriteRenderer;
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (canMove) {
            // If movement input is not 0, try to move
            if(movementInput != Vector2.zero) {
                bool success = TryMove(movementInput);
                if (!success) {
                    success = TryMove(new Vector2(movementInput.x, 0));
                    if (!success) {
                        success = TryMove(new Vector2(movementInput.y, 0));
                    }
                }
                animator.SetBool("isMoving", success);
            }
            else {
                animator.SetBool("isMoving", false);
            }
            // flip player based on direction
            if(movementInput.x < 0) {
                spriteRenderer.flipX = true;
            } else if (movementInput.x > 0) {
                spriteRenderer.flipX = false;
            }
        }
        
    }

    private bool TryMove(Vector2 direction) {
        // Check for potential collisions
        enemySelect.SetSelect(false);
        int count = rb.Cast(
                direction, 
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset
            );
        enemySelect.SetSelect(true);
        if(count == 0) {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        } else {
            return false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }


    void OnTriggerEnter2D(Collider2D other) {
        print("Touch enemy in player");
        if (other.tag == "Enemy") {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null) {
                // lock player move
                canMove = false;
                // stop animation moving
                animator.SetBool("isMoving", false);
                // swork attach
                animator.SetTrigger("swordAttach");
                
            }

        }
    }
}

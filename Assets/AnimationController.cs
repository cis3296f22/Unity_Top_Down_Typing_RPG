using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AnimationController : MonoBehaviour
{

    public float moveSpeed = 2f;
    
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector3 playerPosition = new Vector3(-4.78f, -1.91f, 1f);
    private Vector3 enemyPosition = new Vector3(2.96f, 0.31f, 1f);
    private bool isMoving = false;
    private Vector3 location;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition != location)
        {
            transform.localPosition += location * moveSpeed * Time.deltaTime;
        }

    }

    IEnumerator MoveTo(Vector3 position)
    {
        location = position;
        isMoving = true;
        yield return new WaitForSeconds(3f);
        isMoving = false;
    }

    public void PlayerEffectAttach()
    {
        transform.localPosition = playerPosition;
        location = enemyPosition;
    }
}

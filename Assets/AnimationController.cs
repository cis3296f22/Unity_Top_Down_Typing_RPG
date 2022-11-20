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
    private Vector3 playerPosition = new Vector3(-4, -1, 1f);
    private Vector3 enemyPosition = new Vector3(3f, 1f, 1f);
    private Vector3 location;
    private static string MUSHROOM_ANIMATION = "mushroom";
    private static string VOLCANO_ANIMATION = "volcano";


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition != location)
        {
            transform.localPosition += location * moveSpeed * Time.deltaTime;
        }

    }

    IEnumerator PlayerEffectAttachCoroutine()
    {
        spriteRenderer.enabled = true;
        transform.localPosition = playerPosition;
        // move to new location
        location = enemyPosition;
        yield return new WaitForSeconds(1f);
        // move to enemyPosition
        transform.localPosition = enemyPosition;
        // set random player attach animation
        RandomPlayerAnimation();
        animator.SetTrigger(MUSHROOM_ANIMATION);
        yield return new WaitForSeconds(1f);
        spriteRenderer.enabled = false;
    }

    public void PlayerEffectAttach()
    {
        StartCoroutine(PlayerEffectAttachCoroutine());
    }

    private void RandomPlayerAnimation()
    {
        System.Random rand = new System.Random();
        int value = rand.Next(1);
        switch (value)
        {
            case 0:
                animator.SetTrigger(MUSHROOM_ANIMATION);
                break;
            case 1: 
                animator.SetTrigger(VOLCANO_ANIMATION);
                break;
            default:
                animator.SetTrigger(VOLCANO_ANIMATION);
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AnimationController : MonoBehaviour
{

    public float moveSpeed = 2f;
    public PlayerController playerController;
    public Enemy enemy;
    
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector3 playerPosition = new Vector3(-4, -1, 1f);
    private Vector3 enemyPosition = new Vector3(3f, 1f, 1f);
    private Vector3 location;
    private static string MUSHROOM_ANIMATION = "mushroom";
    private static string VOLCANO_ANIMATION = "volcano";
    private static string FLASHLIGHT_ANIMATION = "flashlight";
    private static string FIREEXPLOSION_ANIMATION = "fireexplosion";


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

    IEnumerator PlayerEffectAttackCoroutine()
    {
        playerController.SwordAttack();
        animator.SetBool(FLASHLIGHT_ANIMATION, true);
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
    
    IEnumerator EnemyEffectAttackCoroutine()
    {
        enemy.MoveAttack();
        // change to fire ball
        animator.SetBool(FLASHLIGHT_ANIMATION, false);
        spriteRenderer.enabled = true;
        transform.localPosition = enemyPosition;
        // move to new location
        location = playerPosition;
        yield return new WaitForSeconds(1f);
        // move to player position
        transform.localPosition = playerPosition;
        animator.SetTrigger(FIREEXPLOSION_ANIMATION);
        yield return new WaitForSeconds(1f);
        spriteRenderer.enabled = false;
    }

    public void PlayerEffectAttack()
    {
        StartCoroutine(PlayerEffectAttackCoroutine());
    }

    public void EnemyEffectAttack()
    {
        StartCoroutine(EnemyEffectAttackCoroutine());
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

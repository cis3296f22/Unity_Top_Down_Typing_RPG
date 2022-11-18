using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public float health = 100;
    public float speed = 3000;
    public int isFinish = 0;

    private float time;
    private string word;


    private void Start()
    {
        animator = GetComponent<Animator>();
        isFinish = PlayerPrefs.GetInt("IsFinish");
        if (isFinish == 1)
        {
            
        }
    }

    public float Health {
        set {
            health = value;

            if(health <= 0) {
                Defeated();
            }
        }
        get {
            return health;
        }
    }
    
    public void TakeDamage() {
        animator.SetTrigger("DAMAGE");
    }

    public void Defeated() {
        animator.SetTrigger("DEFEATED");
    }

    public void RemoveEnemy() {
        Destroy(gameObject);
    }

    public string ShowString() {
        time = Time.time * 1000;
        word = "administrator";
        return word;
    }


    public bool GetString(string input) {
        float deltaTime = Time.time * 1000 - time;
        if (deltaTime > speed) {
            return false;
        }
        return word == input;

    }
}

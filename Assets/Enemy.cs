using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public static Enemy Instance;
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

    public float health = 100;
    public float speed = 3000;

    private float time;
    private string word;

    public void TakeDamage(float damage) {
        Health -= damage;
    }

    public void Defeated(){
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

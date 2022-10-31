using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelect : MonoBehaviour
{

    public Collider2D enemySelect;


    public void SetSelect(bool flag) {
        enemySelect.enabled = flag;
    }

    void OnTriggerEnter2D(Collider2D other) {
        print("Touch enemy");
        if (other.tag == "Enemy") {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null) {
                print("Select this enemy");
                string value = enemy.ShowString();
                // show string
                print(value);
                string input = Input.inputString;
                print(input);
            }

        }
    }
}

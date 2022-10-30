using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelect : MonoBehaviour
{

    public Collider2D enemySelect;


    public void SetSelect(bool flag) {
        print(flag);
        enemySelect.enabled = flag;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        print("Touch enemy");
        if (other.tag == "Enemy") {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null) {
                print("Select this enemy");
            }

        }
    }
}

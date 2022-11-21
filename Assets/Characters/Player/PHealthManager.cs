using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PHealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount;
    public KeyBoardInput keyBoardInput;
    // Start is called before the first frame update
    private void Start()
    {
        healthAmount = PlayerPrefs.GetFloat("Health");
        Debug.Log(healthAmount);
        healthBar.fillAmount = healthAmount/100f;
        
    }
    
    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }
    
    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount /100f;
    }
}

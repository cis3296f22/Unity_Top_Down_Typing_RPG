using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    public GameObject textField;

	public KeyBoardInput keyboardInput;
    public GameObject ItemField;

    private void Start()
    {
        Debug.Log("Fight Scene Start");
        ItemField.SetActive(false);
    }
    
    public void ItemHide()
    {
        ItemField.SetActive(false);
    }

    //Creating fight scene button
    public void RunButton()
    {
        PlayerPrefs.SetInt("IsRun", 1);
        PlayerPrefs.SetInt("TimeToLoad",1);
        string value = PlayerPrefs.GetInt("IsWin", 1).ToString();
        Debug.Log("Set isWin of Run " + value);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void FightButton()
    {
        print("Start To fight with the enemy");
        hide();
		keyboardInput.Begin();
    }

    public void ItemButton()
    {
        print("Open Storage");
        ItemField.SetActive(true);
        
    }

    public void DefendButton()
    {
        print("Defend");
    }
    
    public void hide()
    {
        textField.SetActive(false);
    }
    
    public void show()
    {
        textField.SetActive(true);
    }
}

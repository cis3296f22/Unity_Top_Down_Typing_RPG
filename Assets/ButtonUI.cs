using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    //Creating fight scene button
    public void RunButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void FightButton()
    {
        print("Start To fight with the enemy");
    }

    public void ItemButton()
    {
        print("Open Storage");
    }

    public void DefendButton()
    {
        print("Defend");
    }
}

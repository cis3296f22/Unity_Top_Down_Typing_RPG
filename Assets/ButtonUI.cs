using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    public GameObject textField;

	public KeyBoardInput keyboardInput;
    //Creating fight scene button
    public void RunButton()
    {
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

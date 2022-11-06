using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using TMPro;
using System;


public class KeyBoardInput : MonoBehaviour
{
    public TMP_Text text;

    private StringBuilder playerInput = new StringBuilder("");
	private string sentence = "This is the words that users have to type. This is not a realy long word.";
	private int[] compare;
	private string CORRECT_COLOR_OPEN_TAG = "<color=blue>";
	private string INCORRECT_COLOR_OPEN_TAG = "<color=red>";
	private string NOT_TYPING_COLOR_TAG = "<color=grey>";
	private string COLOR_END_TAG = "</color>";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Backspace)) {
			playerInput.Length --;
		}
        else if (Input.anyKeyDown) {
            playerInput.Append(Input.inputString);
            Debug.Log(playerInput.ToString());
            
		}
		CompareInput();
		ShowText();
        
    }

	private void CompareInput() {
		int min = Math.Min(sentence.Length, playerInput.Length);
		int max = Math.Max(sentence.Length, playerInput.Length);
		compare = new int[max];
		for (int i = 0; i < min;i++) {
			if (sentence[i] == playerInput[i]) {
				compare[i] = 1;
			}
			else {
				compare[i] = -1;
			}
		}
		
	}

	private void ShowText() {
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < compare.Length; i++) {
			if (compare[i] == 1) {
				sb.Append(CORRECT_COLOR_OPEN_TAG);
				sb.Append(sentence[i]);
				sb.Append(COLOR_END_TAG);
			}
			else if (compare[i] == -1) {
				sb.Append(INCORRECT_COLOR_OPEN_TAG);
				sb.Append(sentence[i]);
				sb.Append(COLOR_END_TAG);
			}
			else if (compare[i] == 0) {
				sb.Append(NOT_TYPING_COLOR_TAG);
				sb.Append(sentence[i]);
				sb.Append(COLOR_END_TAG);
			}
		}
		text.text = sb.ToString();
	}
}

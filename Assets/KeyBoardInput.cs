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
	private string sentence = "";
	private bool playing = false;
	private int[] compare;
	private string CORRECT_COLOR_OPEN_TAG = "<color=green>";
	private string INCORRECT_COLOR_OPEN_TAG = "<color=red>";
	private string NOT_TYPING_COLOR_TAG = "<color=grey>";
	private string COLOR_END_TAG = "</color>";
	
	private float totalWord;
	private float correctWord;
	private float accuracyWord;

	private int size;
    // Start is called before the first frame update
    void Start()
    {
		WordGenerator.GenerateDict();
    }

    // Update is called once per frame
    void Update()
    {
		if (playing == true) {
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
		
        
    }

	public void Begin() {
		if (!playing) {
			sentence = WordGenerator.GenerateSentence();
			playing = true;
			size = sentence.Length;
		}
	}

	private void CompareInput() {
		int min = Math.Min(sentence.Length, playerInput.Length);
		int max = Math.Max(sentence.Length, playerInput.Length);
		compare = new int[max];
		for (int i = 0; i < min;i++)
		{
			totalWord++;
			if (sentence[i] == playerInput[i]) {
				compare[i] = 1;
				correctWord++;
			}
			else {
				compare[i] = -1;
			}
		}
	}

	private double AccuracyCalculate()
	{
		double result = 0.0;
		 result= ((correctWord *1.0)/ totalWord)*100;
		 print(result);
		 return result;
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

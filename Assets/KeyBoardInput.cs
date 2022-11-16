using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class KeyBoardInput : MonoBehaviour
{
    public TMP_Text text;
    public TMP_Text TimerText;
    public float timeRemaining = 10;
    public HealthManager enemyHealthManager;
    public HealthManager playerHealthManager;
    public ButtonUI buttonUI;
    public ParticleSystem particalSystem;

    public PlayerController playerController;
    public Enemy enemy;
    private StringBuilder playerInput = new StringBuilder("");
	private string sentence = "";
	private bool playing = false;
	private int[] compare;
	private string CORRECT_COLOR_OPEN_TAG = "<color=green>";
	private string INCORRECT_COLOR_OPEN_TAG = "<color=red>";
	private string NOT_TYPING_COLOR_TAG = "<color=grey>";
	private string COLOR_END_TAG = "</color>";
	private string COLOR_TIMER_TAG = "<color=black>";
	
	private float totalChar;
	private float correctChar;
	private float accuracy;
	private int EnemyId;

	private int size;
    // Start is called before the first frame update
    void Start()
    {
		WordGenerator.GenerateDict();
		Debug.Log("Inputplayer Start");
    }

    // Update is called once per frame
    void Update()
    {
		if (playing == true) {
			if (Input.GetKeyDown(KeyCode.Backspace)) {
				// only remove when the player input something
				if (playerInput.Length > 0)
				{
					playerInput.Length --;
				}
				
			}
        	else if (Input.anyKeyDown) {
            	playerInput.Append(Input.inputString);
            	Debug.Log(playerInput.ToString());
            
			}	
			CompareInput();
			ShowText();
			ShowTime();
			
		}
		if (timeRemaining <= 0)
		{
			playing = false;
			Debug.Log("Correct: " + accuracy);
			StartCoroutine(FightTurn());
			//enemyHealthManager.TakeDamage(100);
			if (enemyHealthManager.healthAmount > 0 && playerHealthManager.healthAmount > 0)
			{
				// reset all the status of the game
				Reset();
				StartCoroutine(ResetButton());
			}
			else
			{
				// show result
				if (playerHealthManager.healthAmount > enemyHealthManager.healthAmount)
				{
					//If win, save player data and return back last position with data. 
					Debug.Log("Player win");
					PlayerPrefs.SetInt("IsWin", 1);
					//PlayerPrefs.SetInt("enemyId",EnemyId);
					ShowResult("You Win");
					SwitchScene();

				}
				else
				{
					//If lose, player dead, reset all player data and return back to Starting point
					Debug.Log("Enemy win");
					PlayerPrefs.SetInt("IsWin", 0);
					PlayerPrefs.DeleteKey("p_x");
					PlayerPrefs.DeleteKey("p_y");
					PlayerPrefs.DeleteKey("TimeToLoad");
					ShowResult("You Lose");
					SwitchScene();
				}
			}
		}
		
        
    }

	public void Begin() {
		if (!playing) {
			sentence = WordGenerator.GenerateSentence();
			playing = true;
			size = sentence.Length;
		}
	}
	// Player attack turn
	private void PlayerTurn()
	{
		Debug.Log("Player Turn");
		enemyHealthManager.TakeDamage(10 * accuracy);
		
	}
	//Enemy attack turn.
	private void EmenyTurn()
	{
		Debug.Log("Enemy Turn");
		playerHealthManager.TakeDamage(5);
	}
	
	// control both turn. 
	IEnumerator FightTurn()
	{
		Debug.Log("Wait Turn");
		PlayerTurn();
		yield return new WaitForSeconds(3f);
		EmenyTurn();
	}

	public void Reset()
	{
		sentence = "";
		playerInput = new StringBuilder("");
		compare = new int[0];
		ShowText();
		timeRemaining = 10;
	}

	// Slow show button event.
	IEnumerator ResetButton()
	{
		yield return new WaitForSeconds(5f);
		buttonUI.show();
	}

	private void CompareInput() {
		int min = Math.Min(sentence.Length, playerInput.Length);
		int max = Math.Max(sentence.Length, playerInput.Length);
		compare = new int[max];
		totalChar = max;
		correctChar = 0;
		for (int i = 0; i < min;i++)
		{
			if (sentence[i] == playerInput[i]) {
				compare[i] = 1;
				correctChar++;
			}
			else {
				compare[i] = -1;
			}
		}
		// calculate accuracy based on character
		accuracy = correctChar / totalChar;
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

	public void ShowTime()
	{
		StringBuilder sb = new StringBuilder();
		if (playing && timeRemaining >= 0)
		{
			timeRemaining -= Time.deltaTime;
			float seconds = Mathf.FloorToInt(timeRemaining % 60);
			sb.Append(COLOR_TIMER_TAG);	
			sb.Append(seconds);
			sb.Append(COLOR_END_TAG);
			TimerText.text = sb.ToString();
			// if (timeRemaining == 0)
			// {
			// 	playing = false;
			// }
		}
		if (timeRemaining <= 0)
		{
			sb = new StringBuilder();
			sb.Append(COLOR_TIMER_TAG);	
			sb.Append("0");
			sb.Append(COLOR_END_TAG);
			TimerText.text = sb.ToString();
		}

	}

	public void ShowResult(String result)
	{
		StringBuilder sb = new StringBuilder();
		sb.Append(CORRECT_COLOR_OPEN_TAG);
		sb.Append(result);
		sb.Append(COLOR_END_TAG);
	}
	
	public void SwitchScene()
	{
		StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex -1));
        
	}

	IEnumerator LoadScene(int SceneIndex)
	{
		//play animation
		//transition.SetTrigger("Start");
		//wait
		yield return new WaitForSeconds(2f);
		//load scene
		SceneManager.LoadScene(SceneIndex);
	}
}

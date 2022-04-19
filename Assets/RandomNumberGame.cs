using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomNumberGame : MonoBehaviour
{
    public enum GameStates { Greetings, MainGame, Victory, EndGame, CheckNumber, Hell };
    public GameStates gameState;

    public int currentNumber = 0;
    int playerLives = 3;

    public TextMeshProUGUI speechBubble;

    public TextMeshProUGUI Lives;

    int state = 0;

    int random = 0;

    int min;
    int max;

    public GameObject TryAgainLoseScreen;
    public GameObject TryAgainWinScreen;


    void Start()
    {

        gameState = GameStates.Greetings;
        playerLives = 3;

        min = 1;
        max = Random.Range(5, 10);

        random = Random.Range(min, max + 1);



        TryAgainWinScreen.SetActive(false);
        TryAgainLoseScreen.SetActive(false);
    }

  
    void Update()
    {



        Lives.text = "Tries: " + playerLives;

        switch (gameState)
        {
            case GameStates.Greetings:

                speechBubble.text = "Guess a number between " + min.ToString() + " and " + max.ToString();
                break;


            case GameStates.CheckNumber:
                break;


            case GameStates.MainGame:

                speechBubble.text = currentNumber.ToString();
                break;


            case GameStates.Hell:

                speechBubble.text = "You have lost";
                TryAgainLoseScreen.SetActive(true);
                break;


            case GameStates.Victory:

                speechBubble.text = " You Won";
                TryAgainWinScreen.SetActive(true);
                break;


            case GameStates.EndGame:
                break;


            default:
                // Fehlermeldung
                break;
        }


    }


    public void RestartGame()
    {
        Start();
    }


    public void CheckNumbers()
    {

        gameState = GameStates.CheckNumber;

        playerLives -= 1;

        if (playerLives == 0)
            gameState = GameStates.Hell;


        if (currentNumber < random)
        {
            speechBubble.text = ("You have entered " + currentNumber + " and its higher ");
        }

        if (currentNumber > random)
        {
            speechBubble.text = ("You have entered " + currentNumber + " Its lower ");
        }

        if (currentNumber == random)
        {
            gameState = GameStates.Victory;
        }
    }


    public void NumberInput(string _number)
    {

        currentNumber = int.Parse(_number);
    }

}
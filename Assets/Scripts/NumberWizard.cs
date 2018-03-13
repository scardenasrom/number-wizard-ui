using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

    public int maxGuessesAllowed = 10;
    public Text guessText;

    int max = 1000;
    int min = 1;
    int lastGuess = 0;
    int currentGuess = 0;
    bool gameEnded = false;

	void Start () {
        InitializeGame();
    }

    void InitializeGame() {
        gameEnded = false;
        min = 1;
        max = 1000;
        lastGuess = 0;
        currentGuess = 0;
        MakeGuess();
    }

    void MakeGuess() {
        if (maxGuessesAllowed < 0) {
            SceneManager.LoadScene("Win");
        } else {
            //currentGuess = (min + max) / 2;
            do {
                currentGuess = Random.Range(min, max + 1);
            } while (currentGuess == lastGuess);
            /*if (lastGuess == currentGuess) {
                currentGuess++;
            }*/
            guessText.text = "My guess is " + currentGuess;
            maxGuessesAllowed--;
        }
    }

    public void GuessHigher() {
        lastGuess = currentGuess;
        //min = (min + max) / 2;
        min = currentGuess;
        MakeGuess();
    }

    public void GuessLower() {
        lastGuess = currentGuess;
        //max = (min + max) / 2;
        max = currentGuess;
        MakeGuess();
    }

}

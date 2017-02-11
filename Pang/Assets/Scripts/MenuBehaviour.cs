using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBehaviour : MonoBehaviour {

    public GameObject[] menuPanels;
    public Text scoreText;


	// Use this for initialization
	void Start ()
    {
        scoreText.text = GameManager.targetScore.ToString();
    }

    public void StartMenu()
    {
        foreach (GameObject panels in menuPanels)
        {
            panels.SetActive(false);
        }
        menuPanels[0].SetActive(true);
    }

    public void GameTypeMenu()
    {
        foreach (GameObject panels in menuPanels)
        {
            panels.SetActive(false);
        }
        menuPanels[1].SetActive(true);
    }

    public void OptionsMenu()
    {
        foreach (GameObject panels in menuPanels)
        {
            panels.SetActive(false);
        }
        menuPanels[2].SetActive(true);
    }

    public void Difficulty()
    {
        foreach (GameObject panels in menuPanels)
        {
            panels.SetActive(false);
        }
        menuPanels[3].SetActive(true);
    }

    public void HighScores()
    {
        foreach (GameObject panels in menuPanels)
        {
            panels.SetActive(false);
        }
        menuPanels[4].SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    #region SCORE BUTTONS

    public void Addscore(int value)
    {
        if (GameManager.targetScore + value > 20)
        {
            GameManager.targetScore = 20;
            scoreText.text = GameManager.targetScore.ToString();
        }
        else
        {
            GameManager.targetScore += value;
            scoreText.text = GameManager.targetScore.ToString();
        }
            
    }

    public void MinusScore(int value)
    {
        if (GameManager.targetScore != 5)
        {
            GameManager.targetScore -= value;
            scoreText.text = GameManager.targetScore.ToString();
        }
    }

    #endregion
}

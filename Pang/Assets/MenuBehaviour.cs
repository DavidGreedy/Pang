using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBehaviour : MonoBehaviour {

    public GameObject[] menuPanels;

	// Use this for initialization
	void Start () {
		
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
}

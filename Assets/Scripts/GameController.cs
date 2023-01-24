using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject EightBallPrefab;
    public int Score = 0; 
    public bool gameover = true;
    public int numberOfBalls = 0;
    public int maximumOfBalls = 15;

    public Text ScoreText;
    public Button PlayAgainButton;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AddABall", 1.5F, 1);
    }

	private void Update()
	{
		ScoreText.text = Score.ToString();
	}

	void AddABall()
    {
        if (gameover == false)
        {
            Instantiate(EightBallPrefab);
            numberOfBalls++;
            if (numberOfBalls >= maximumOfBalls)
            {
                gameover= true;
                PlayAgainButton.gameObject.SetActive(true);
            }

        }
    }

    public void ClickedOnBall()
    {
        Score++;
        numberOfBalls--;
        if (Score >= maximumOfBalls)
        {
            gameover= true;
			PlayAgainButton.gameObject.SetActive(true);
		}
    }
    public void StartGame()
    {
        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("GameController"))
        {
            Destroy(ball);
        }
        gameover = false;
        PlayAgainButton.gameObject.SetActive(false);
        Score = 0;
        numberOfBalls = 0;

    }
}

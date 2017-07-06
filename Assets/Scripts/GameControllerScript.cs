using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour {

    public ButtonHandlerScript ButtonDown;
    public ButtonHandlerScript ButtonUp;
    public float ButtonCheckTime=0.2f;


    private float _curentButtonCheckTime=0f;
    

    public float gameSource=0f;
    public float gameTime=0;
    public int coins;

    GameObject sourceL;
    public float timeToEnd = 2f;


    private bool end = false;

    PlaneControllScript planeControll;

    public GameObject GameOverLayer;
    public GameObject CoinsText;
    public GameObject ScoreText;

    // Use this for initialization
    void Start () {
        planeControll = GameObject.Find("Plane").GetComponent<PlaneControllScript>();
        sourceL = GameObject.Find("Score");
    }
	
	// Update is called once per frame
	void Update () {
        gameTime += Time.deltaTime;

        if (end)
        {
            timeToEnd -= Time.deltaTime;
            if (timeToEnd < 0)
            {
                ShowGameOverLayer();
            }
        }
        else
        {
            gameSource += Time.deltaTime * 100;
            sourceL.GetComponent<Text>().text = Math.Round(gameSource) + "";
        }

        if (planeControll != null)
        {
            if (_curentButtonCheckTime < 0)
            {
                if (ButtonDown.IsPressed ^ ButtonUp.IsPressed)
                {
                    if (ButtonDown.IsPressed)
                    {
                        planeControll.Down();
                        _curentButtonCheckTime = ButtonCheckTime;
                    }
                    else
                    {
                        planeControll.Up();
                        _curentButtonCheckTime = ButtonCheckTime;
                    }
                }
            }
            else
                _curentButtonCheckTime -= Time.deltaTime;
        }



    }

    void ShowGameOverLayer()
    {
        CoinsText.GetComponent<Text>().text = "Coins: "+coins;
        ScoreText.GetComponent<Text>().text = "Source: " + Math.Round(gameSource);
        GameOverLayer.SetActive(true);
    }

    public void End()
    {
        end =true;
        planeControll.DestroyPlane();
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Replay()
    {
        SceneManager.LoadScene(1);
    }

    public void AddCoins(int value)
    {
        gameSource += value * 100;
        coins += value;
    }

    public bool getEnd()
    {
        return end;
    }

}

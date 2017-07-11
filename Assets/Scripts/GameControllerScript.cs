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
    

    public float gameScore=0f;
    public float gameTime=0;
    public int coins;

    public GameObject scoreL;
    public float timeToEnd = 2f;


    private bool end = false;
    private bool pause = false;

    PlaneControllScript planeControll;

    public GameObject GameOverLayer;
    public GameObject CoinsText;
    public GameObject ScoreText;

    public GameObject GamePauseLayer;

    private int[] _upgrades = {0,0,0,0,0};
    private int _coins;
    private int _maxResult;

    // Use this for initialization
    void Start ()
    {
        InitValue();
        planeControll = GameObject.Find("Plane").GetComponent<PlaneControllScript>();
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
        else if (!pause)
        {
            gameScore += Time.deltaTime * 100;
            scoreL.GetComponent<Text>().text = Math.Round(gameScore) + "";
        }

        if (planeControll != null)
        {
            if (_curentButtonCheckTime < 0)
            {
                if (ButtonDown.IsPressed ^ ButtonUp.IsPressed)
                {
                    if (ButtonDown.IsPressed)
                    {
                        planeControll.Down(50 + _upgrades[0] * 3f, 2 +_upgrades[0]*0.1f);
                        _curentButtonCheckTime = ButtonCheckTime;
                    }
                    else
                    {
                        planeControll.Up(50 + _upgrades[0] * 3f, 2 + _upgrades[0] * 0.1f);
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
        ScoreText.GetComponent<Text>().text = "Score: " + Math.Round(gameScore);
        GameOverLayer.SetActive(true);
    }

    public void End()
    {
        end =true;
        planeControll.DestroyPlane();
    }

    public void EndGame()
    {
        _coins += coins;
        PlayerPrefs.SetInt("Coins", _coins);
        if ((int)Math.Round(gameScore) > _maxResult)
        {
            _maxResult = (int)Math.Round(gameScore);
            PlayerPrefs.SetInt("MaxResult",_maxResult);
        }
        SceneManager.LoadScene(0);
    }

    public void Replay()
    {
        _coins += coins;
        PlayerPrefs.SetInt("Coins", _coins);
        if ((int)Math.Round(gameScore) > _maxResult)
        {
            _maxResult = (int)Math.Round(gameScore);
            PlayerPrefs.SetInt("MaxResult", _maxResult);
        }
        SceneManager.LoadScene(1);
    }

    public void AddCoins(int value)
    {
        gameScore += (int)Math.Round(value * 100*(1+0.5*_upgrades[2]));
        coins += (int)Math.Round(value * (1 + 0.5 * _upgrades[2])); ;
    }

    public void GamePause()
    {
        if (!end)
        {
            pause = true;
            GamePauseLayer.SetActive(true);
        }
    }

    public void GameResume()
    {
        pause = false;
        GamePauseLayer.SetActive(false);
    }

    public bool getEnd()
    {
        return end;
    }

    public bool getPause()
    {
        return pause;
    }

    public void InitValue()
    {
        if (PlayerPrefs.HasKey("MaxResult"))
        {
            _maxResult = PlayerPrefs.GetInt("MaxResult");
        }
        else
        {
            _maxResult = 0;
            PlayerPrefs.SetInt("MaxResult", _maxResult);
        }

        if (PlayerPrefs.HasKey("Coins"))
        {
            _coins = PlayerPrefs.GetInt("Coins");
        }
        else
        {
            _coins = 0;
            PlayerPrefs.SetInt("Coins", _coins);
        }

        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.HasKey("Upgrade" + i))
            {
                _upgrades[i] = PlayerPrefs.GetInt("Upgrade" + i);
            }
            else
            {
                _upgrades[i] = 0;
                PlayerPrefs.SetInt("Upgrade" + i, _upgrades[i]);
            }
        }
    }

    public int GetUpgrate(int index)
    {
        return _upgrades[index];
    }
}

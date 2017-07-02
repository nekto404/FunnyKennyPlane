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
    GameObject sourceL;
    public float timeToEnd = 2f;

    private bool end = false;

    PlaneControllScript planeControll;


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
                EndGame();
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
                        planeControll.Down(5);
                        _curentButtonCheckTime = ButtonCheckTime;
                    }
                    else
                    {
                        planeControll.Up(5);
                        _curentButtonCheckTime = ButtonCheckTime;
                    }
                }
            }
            else
                _curentButtonCheckTime -= Time.deltaTime;
        }



    }

    public void OnClickDown()
    {
    }

    public void OnClickUp()
    {
    }

    public void End()
    {
        GameObject.Find("GameOver").transform.Translate(new Vector3(0, 0, -25)); 
        end =true;
        planeControll.DestroyPlane();
    }

    void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    public void AddScore(int value)
    {
        gameSource += value * 100;
    }

}

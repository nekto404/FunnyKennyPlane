using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlaneControllScript : MonoBehaviour {

    public int angle;
    public float timeToEnd = 2f;

    private bool end = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float speed = angle * Time.deltaTime/20;
        transform.Translate(new Vector3(0, speed, 0));
        if (end)
        {
            timeToEnd -= Time.deltaTime;
            if (timeToEnd<0)
            {
                EndGame();
            }
        }
	}

    public void Up()
    {
        if (angle < 60)
        {
            transform.GetChild(0).Rotate(new Vector3(0, 0, 20));
            angle += 20;
        }
        Debug.Log(angle);
    }

    public void Down()
    {
        if (angle > -60)
        {
            transform.GetChild(0).Rotate(new Vector3(0, 0, -20));
            angle -= 20;
        }
        Debug.Log(angle); 
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("GameOver").transform.Translate(new Vector3(0, 0, -25));
        end = true;
    }

    void EndGame()
    {
        SceneManager.LoadScene(0);
    }
}

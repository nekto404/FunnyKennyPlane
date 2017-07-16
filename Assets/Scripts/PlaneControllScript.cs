using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControllScript : MonoBehaviour {

    public float angle;
    public GameControllerScript gameControllerScript;
    public GameObject expoSystem;
    public MusicPlayer ExpoMusic;
    public MusicPlayer CoinMusic;

    // Use this for initialization
    void Start () {
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameControllerScript>();
    }
	
	// Update is called once per frame
	void Update () {
        if (gameControllerScript.getEnd() || gameControllerScript.getPause()) return;
        float speed = angle * Time.deltaTime/20;
        transform.Translate(new Vector3(0, speed, 0));
    }

    public void Up(float maxAngle, float stepRotation)
    {
        if (angle < maxAngle)
        {
            transform.GetChild(0).Rotate(new Vector3(0, 0, stepRotation));
            angle += stepRotation;
        }
    }

    public void Down(float maxAngle, float stepRotation)
    {
        if (angle > -maxAngle)
        {
            transform.GetChild(0).Rotate(new Vector3(0, 0, -stepRotation));
            angle -= stepRotation;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ObstacleController obstacle = collision.gameObject.GetComponent<ObstacleController>();
        CointController coint = collision.gameObject.GetComponent<CointController>();
        GrassController grass = collision.gameObject.GetComponent<GrassController>();

        if (obstacle != null)
        {
            angle = -60;
            gameControllerScript.End();
        }
        else if (coint != null)
        {
            gameControllerScript.AddCoins(coint.value);
            coint.desroyCoint();
            CoinMusic.Play();
        }
        else if (grass != null)
        {
            angle = -60;
            gameControllerScript.End();
        }
    }

    public void DestroyPlane()
    {   
       Instantiate(expoSystem, transform.position, Quaternion.identity);
       Destroy(gameObject);
       ExpoMusic.Play();
    }
}

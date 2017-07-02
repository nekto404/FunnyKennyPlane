using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControllScript : MonoBehaviour {

    public float angle;
    public GameControllerScript gameControllerScript;
    public GameObject expoSystem;

   

    // Use this for initialization
    void Start () {
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameControllerScript>();
    }
	
	// Update is called once per frame
	void Update () {
        float speed = angle * Time.deltaTime/20;
        transform.Translate(new Vector3(0, speed, 0));
    }

    public void Up(float rotAngle)
    {
        if (angle < 60)
        {
            transform.GetChild(0).Rotate(new Vector3(0, 0, rotAngle));
            angle += rotAngle;
        }
        Debug.Log(angle);
    }

    public void Down(float rotAngle)
    {
        if (angle > -60)
        {
            transform.GetChild(0).Rotate(new Vector3(0, 0, -rotAngle));
            angle -= rotAngle;
        }
        Debug.Log(angle); 
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
            gameControllerScript.AddScore(coint.value);
            coint.desroyCoint();
        }
        else if (grass != null)
        {
            angle = -60;
            gameControllerScript.End();
        }
    }

    public void DestroyPlane()
    {
        
       GameObject rock = Instantiate(expoSystem, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject);
    }
}

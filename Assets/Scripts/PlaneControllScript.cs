using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControllScript : MonoBehaviour {

    public int angle;
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
        angle = -60;
        gameControllerScript.End();
    }

    public void DestroyPlane()
    {
        GameObject rock = Instantiate(expoSystem, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject);
    }
}

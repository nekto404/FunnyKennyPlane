using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour {


    public float speed;
    public float maxHeight;
    public float minHeight;
    private bool direction=false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float curentStep = Time.deltaTime * speed;
        if (direction)
        {
            if (transform.position.y + curentStep < maxHeight)
            {
                transform.Translate(new Vector3(0, curentStep, 0));
            }
            else
            {
                transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
                direction = false;
            }
        }
        else
        {
            if (transform.position.y - curentStep > minHeight)
            {
                transform.Translate(new Vector3(0, -curentStep, 0));
            }
            else
            {
                transform.position = new Vector3(transform.position.x, minHeight, transform.position.z);
                direction = true;
            }
        }
    }
}

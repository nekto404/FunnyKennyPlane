using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCoinController : MonoBehaviour
{

    public menuConttroller MenuConttroller;
	// Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 10);
            MenuConttroller.InitValue();
            MenuConttroller.ShowInfo();
        }
        if (Input.GetKeyDown("l"))
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 100);
            MenuConttroller.InitValue();
            MenuConttroller.ShowInfo();
        }

        if (Input.GetKeyDown("o"))
        {
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt("Upgrade" + i,0);
            }
           
            MenuConttroller.InitValue();
            MenuConttroller.ShowInfo();
        }
    }
}

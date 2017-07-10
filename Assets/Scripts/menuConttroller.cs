using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuConttroller : MonoBehaviour
{
    public UpgradeElement[] Elements;

    private int[] upgades = {0,0,0,0,0};
    // Use this for initialization
    void Start () {
	    for (int i = 0; i < Elements.Length; i++)
	    {
	        Elements[i].SetValue(upgades[i]);
	    }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartButton ()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void Upgrade(int upgradeIndex)
    {
        upgades[upgradeIndex]++;
        Elements[upgradeIndex].SetValue(upgades[upgradeIndex]);
    }
}

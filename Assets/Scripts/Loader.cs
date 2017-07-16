using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{

    private AsyncOperation _loading;
    public Slider Slider;
    public GameObject Panel;

	void Start ()
	{
	    StartCoroutine(StartLoad());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator StartLoad()
    {
        yield return new WaitForSeconds(0.1f);
        _loading = SceneManager.LoadSceneAsync("test");
        _loading.allowSceneActivation = false;
        while (!_loading.isDone)
        {
            Slider.value = _loading.progress/0.9f;
            if (_loading.progress > 0.89f)
            {
                Panel.SetActive(true);
            }
            yield return null;
        }
       
    }

    public void StartScene()
    {
        _loading.allowSceneActivation = true;
    }
}

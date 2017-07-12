using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuConttroller : MonoBehaviour
{
    public UpgradeElement[] Elements;
    public NumberSpace ScoreSpace;
    public NumberSpace CoinsSpace;

    private int[] _upgrades = new int[5];

    private int _coins;
    private int _maxResult;

    // Use this for initialization
    void Awake ()
    {
        InitValue();
        ShowInfo();
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

    public void Upgrade(int upgradeIndex, int price)
    {
        if (_coins >= price)
        {
            _coins -= price;
            PlayerPrefs.SetInt("Coins",_coins);
            CoinsSpace.Number = _coins;
            CoinsSpace.Show();
            _upgrades[upgradeIndex]++;
            PlayerPrefs.SetInt("Upgrade" + upgradeIndex, _upgrades[upgradeIndex]);
            Elements[upgradeIndex].SetValue(_upgrades[upgradeIndex]);

            for (int i = 0; i < Elements.Length; i++)
            {
                Elements[i].CheckPrice(_coins);
            }
        }
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
            PlayerPrefs.SetInt("MaxResult",_maxResult);
        }

        if (PlayerPrefs.HasKey("Coins"))
        {
            _coins = PlayerPrefs.GetInt("Coins");
        }
        else
        {
            _coins = 0;
            PlayerPrefs.SetInt("Coins",_coins);
        }

        for (int i = 0; i < Elements.Length; i++)
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

    public void ShowInfo()
    {
        CoinsSpace.Number = _coins;
        CoinsSpace.Show();
        ScoreSpace.Number = _maxResult;
        ScoreSpace.Show();
        for (int i = 0; i < Elements.Length; i++)
        {
            Elements[i].SetValue(_upgrades[i]);
            Elements[i].CheckPrice(_coins);
        }
    }
}

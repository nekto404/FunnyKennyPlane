using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public Sprite MusicOn;
    public Sprite MusicOff;

    public Image MusicButton;

    private int _music = 1;

	void Start ()
	{
        Init();
	}
	
    void Init()
    {
        if (PlayerPrefs.HasKey("Music"))
        {
            _music = PlayerPrefs.GetInt("Music");
        }
        else
        {
            PlayerPrefs.SetInt("Music", _music);
        }
        MusicButton.sprite = (_music != 0) ? MusicOn : MusicOff;
    }

    public void ChangeState()
    {
        _music = (_music != 0) ? 0 : 1;
        PlayerPrefs.SetInt("Music", _music);
        MusicButton.sprite = (_music != 0) ? MusicOn : MusicOff;
    }

    public bool GetMusicState()
    {
        return (_music != 0) ? true : false;
    }
}

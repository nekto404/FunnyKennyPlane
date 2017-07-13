using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MusicPlayer : MonoBehaviour {


    private AudioSource _musicPlayer;
    public MusicManager MusicM;
    void Start () {
        _musicPlayer = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!MusicM.GetMusicState())
        {
            _musicPlayer.Stop();
        }
    }

    public void Play()
    {
        if (MusicM.GetMusicState())
        {
            _musicPlayer.Play();
        }
    }


}

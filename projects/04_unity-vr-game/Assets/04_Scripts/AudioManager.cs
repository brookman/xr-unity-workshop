using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip audioStart;
    public AudioClip audioGameOver;

    public void StartGame()
    {
        GetComponent<AudioSource>().clip = audioStart;
        GetComponent<AudioSource>().PlayDelayed(0.1f);
    }

    public void GameOver()
    {
        GetComponent<AudioSource>().clip = audioGameOver;
        GetComponent<AudioSource>().PlayDelayed(0.1f);
    }
}

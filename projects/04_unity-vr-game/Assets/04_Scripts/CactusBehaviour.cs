using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusBehaviour : MonoBehaviour
{
    public AudioClip audioJump;
    public AudioClip audioGetHit;
    public AudioClip audioHit;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void GetHitByPlayer()
    {
        GetComponent<Animator>().Play("GetHit");

        audioSource.clip = audioGetHit;
        audioSource.volume = 1.0f;
        audioSource.pitch = Random.Range(1.8f, 2.1f);
        audioSource.Play();


        //TODO
    }

    public void HitPlayer()
    {
        FindObjectOfType<ScoreManager>().DecreaseHealthPoints(1);

        audioSource.clip = audioHit;
        audioSource.volume = 1.0f;
        audioSource.pitch = Random.Range(0.8f, 1.1f);
        audioSource.Play();
    }

    public void LookAtMe(bool status)
    {
    }

    public void Jump()
    {
        audioSource.clip = audioJump;
        audioSource.volume = 0.5f;
        audioSource.pitch = Random.Range(0.8f, 1.1f);
        audioSource.Play();
    }

    private void Die()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Animator>().Play("Die");

        FindObjectOfType<ScoreManager>().IncreaseScore(1);
    }

    public void DestroyEvent()
    {
        // TODO
    }
}
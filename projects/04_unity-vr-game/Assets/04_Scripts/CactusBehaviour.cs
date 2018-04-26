using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusBehaviour : MonoBehaviour {

    public AudioClip audioJump;
    public AudioClip audioGetHit;
    public AudioClip audioHit;

    private int hitCounter = 0;

    public void GetHitByPlayer()
    {
        hitCounter++;

        GetComponent<Animator>().Play("GetHit");

        GetComponent<AudioSource>().clip = audioGetHit;
        GetComponent<AudioSource>().volume = 1.0f;
        GetComponent<AudioSource>().pitch = Random.Range(1.8f, 2.1f);
        GetComponent<AudioSource>().Play();

        if (hitCounter >= 3)
        {
            Die();
        }
    }

    public void HitPlayer()
    {
        FindObjectOfType<ScoreManager>().DecreaseHealthPoints(1);

        GetComponent<AudioSource>().clip = audioHit;
        GetComponent<AudioSource>().volume = 1.0f;
        GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.1f);
        GetComponent<AudioSource>().Play();
    }

    public void LookAtMe(bool status)
    {

    }

    public void Jump()
    {
        GetComponent<AudioSource>().clip = audioJump;
        GetComponent<AudioSource>().volume = 0.5f;
        GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.1f);
        GetComponent<AudioSource>().Play();
    }

    private void Die()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Animator>().Play("Die");

        FindObjectOfType<ScoreManager>().IncreaseScore(1);
    }

    public void DestroyEvent()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_swap : MonoBehaviour
{
    public AudioSource auds;
    public AudioClip victoryMusic;
    public AudioClip victoryChime;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            auds.Stop();
            auds.PlayOneShot(victoryChime);
            //auds.clip = victoryMusic;
            //auds.Play();
        }
    }

}

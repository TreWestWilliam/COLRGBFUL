using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public Transform nextPlace;

    public AudioSource auds;

    public void Start()
    {
        auds = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            auds.Play();
            collision.GetComponent<playerController>().levelUp();
            collision.transform.position = nextPlace.position;
        }
    }
}

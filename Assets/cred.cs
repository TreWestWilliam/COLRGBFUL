using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cred : MonoBehaviour
{

    public GameObject player;

    public Sprite[] sprites = new Sprite[3];

    public SpriteRenderer SR;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SR.sprite = sprites[ player.layer - 6];

    }
}

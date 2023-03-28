using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody2D PlayerBody;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpPower = 200f;

    [SerializeField] bool isGrounded = false;

    [SerializeField] SpriteRenderer spriteRender;

    [SerializeField] Sprite[] playerSprites = new Sprite[3];

    PlayerState red = new();
    PlayerState green = new();
    PlayerState blue = new();

    public int level;

    PlayerState current;

    public AudioSource JumpSource;
    public AudioClip jumpClip;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        PlayerBody = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();

        red.nextState = green; green.previousState = red; // RED -> GREEN -> BLUE -> RED
        red.previousState = blue; blue.nextState = red;
        green.nextState = blue; blue.previousState = green;

        red.stateLayer = 6;
        blue.stateLayer = 7;
        green.stateLayer = 8;

        red.stateSprite = playerSprites[0];
        green.stateSprite = playerSprites[1];
        blue.stateSprite = playerSprites[2];

        current = red;

        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += Move * Time.deltaTime * moveSpeed;

        if (Input.GetButton("Jump") && isGrounded == true)
        {
            PlayerBody.AddForce(transform.up * jumpPower);
            isGrounded = false;
            JumpSource.PlayOneShot(jumpClip);
        }

        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            SwapState(current.previousState);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            SwapState(current.nextState);
        }

        if (Input.GetAxis("Horizontal") != 0) 
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                sr.flipX = false;
            }
            else 
            {
                sr.flipX = true;
            }
        }

    }

    void SwapState(PlayerState state) 
    {
        current = state;
        spriteRender.sprite = state.stateSprite;
        gameObject.layer = state.stateLayer;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
    }

    public void levelUp() { level++; }
}

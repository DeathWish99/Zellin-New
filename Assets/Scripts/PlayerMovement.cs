using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 100.0f;
    public float jumpForce = 1.0f;
    public float doubleJumpCooldown = 0.1f;
    public int indexScene = 2;
    public Camera cam;
    public GameController gc;


    private float doubleJumpCounter = 0.0f;
    private bool isOnGround = true;
    private bool isDoubleJumping = false;
    
    //private Animator anim;
    private Rigidbody2D rb;

    void Start()
    {
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }

    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(translation, 0, 0);

        //rb.velocity = new Vector2(translation, 0);
        
        if(transform.position.x > 10.8f)
        {
            cam.transform.position = new Vector3(transform.position.x, cam.transform.position.y, -3);
        }
        else
        {
            cam.transform.position = new Vector3(10.8f, cam.transform.position.y, -3);
        }

        if (translation < 0)
        {
            transform.localScale = new Vector3(-12.21469f, 11.1661f, 1);
            GetComponent<Animator>().SetBool("right", true);

        }
        else if (translation > 0)
        {
            transform.localScale = new Vector3(12.21469f, 11.1661f, 1);
            GetComponent<Animator>().SetBool("right", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("right", false);
        }

        //if (translation != 0)
        //{
        //    anim.SetFloat("Player Speed", speed);
        //}
        //else
        //{
        //    anim.SetFloat("Player Speed", 0);
        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround)
            {
                isDoubleJumping = false;
                rb.velocity += jumpForce * Vector2.up;
                isOnGround = false;
            }
            else
            {
                if (isDoubleJumping == false)
                {
                    rb.velocity += jumpForce * Vector2.up;
                    isDoubleJumping = true;
                }
            }
        }

        //Ganti Scene ke try again jika pergi ke alam baka
        if (gc.playerHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(7);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isOnGround = true;
            isDoubleJumping = false;
        }
    }
}

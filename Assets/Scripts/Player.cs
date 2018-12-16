using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {
    //movement :
    public float speed = 100.0f;
    public float jumpForce = 1.0f;
    public float doubleJumpCooldown = 0.1f;
    public int indexScene = 3;
    public Camera cam;
    public GameController gc;

    private float doubleJumpCounter = 0.0f;
    private bool isOnGround = true;
    private bool isDoubleJumping = false;

    private Rigidbody2D rb;

    //attack :
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int damage;


    void Start () {
        // movement :
        rb = GetComponent<Rigidbody2D>();

        //attack :

    }
	
	
	void Update () {
        //movement :

        float translation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(translation, 0, 0);

        if (transform.position.x > 10.8f)
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

        if (gc.playerHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(5);
        }

        //attack :
        if (timeBtwAttack <= 0)
        {

            GetComponent<Animator>().SetBool("isAttacking", false);
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("SWING");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
                GetComponent<Animator>().SetBool("isAttacking", true);
                timeBtwAttack = startTimeBtwAttack;

            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
            GetComponent<Animator>().SetBool("isAttacking", true);
        }

    }
   
    //movement :
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isOnGround = true;
            isDoubleJumping = false;
        }
    }


    //attack :
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}

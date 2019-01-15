using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : UnityEngine.MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int damage;

    // Update is called once per frame
    void Update()
    {

        if (timeBtwAttack <= 0)
        {

            GetComponent<Animator>().SetBool("isAttacking", false);
            if (Input.GetKeyDown(KeyCode.U))
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}